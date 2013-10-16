#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Autodesk.Revit.DB;
using Form = System.Windows.Forms.Form;
using Group = System.Text.RegularExpressions.Group;
#endregion // Namespaces

namespace PlaceInstances
{
  public partial class PlaceInstancesForm : Form
  {
    /// <summary>
    /// A regular expression to match a 
    /// real number with optional leading sign.
    /// </summary>
    const string _one_real_number_regex
      //= @"[+-]?\d+(\.\d+)?";
      = @"[-+]?[0-9]*\.?[0-9]+";

    /// <summary>
    /// A regular expression to match three occurrences
    /// of a real number with optional leading sign.
    /// We gave up using this, because the greedy .*
    /// gobbles the +- sign away from the Y and Z
    /// coordinates.
    /// </summary>
    const string _xyz_real_number_regex
      = @"(?<X>" + _one_real_number_regex + ")"
      + @".*(?<Y>" + _one_real_number_regex + ")"
      + @".*(?<Z>" + _one_real_number_regex + ")";

    /// <summary>
    /// Static regular expression for 
    /// parsing real numbers.
    /// </summary>
    static Regex _regex = new Regex(
      //_xyz_real_number_regex
      _one_real_number_regex );

    /// <summary>
    /// Read three real numbers from the given string
    /// and return true on success. Parse the string s 
    /// for exactly two or three real numbers 
    /// representing the XY or XYZ placement 
    /// coordinates. Z defaults to 0.
    /// </summary>
    static bool GetThreeRealNumbers(
      string s,
      ref double[] xyz )
    {
      int i = 0; // index in string
      int n = 0; // count real numbers found

      Match m = _regex.Match( s, i );

      // Pure debugging support

      foreach( Group g in m.Groups )
      {
        Debug.Print( g.ToString() );
      }

      // Read all the real numbers we can get
      // and stop if we find too many

      while( 4 > n && m.Success )
      {
        if( 3 > n )
        {
          xyz[n] = double.Parse( m.ToString() );
          i = m.Index + m.Length;
          m = _regex.Match( s, i );

          foreach( Group g in m.Groups )
          {
            Debug.Print( g.ToString() );
          }
        }
        ++n;
      }

      // Add the default Z coordinate in case of need

      if( 2 == n )
      {
        xyz[n++] = 0.0;
      }

      // Return success if we found 2 or 3 real numbers

      return 3 == n;
    }

    /// <summary>
    /// The input document.
    /// </summary>
    Document _doc;

    /// <summary>
    /// The list of coordinate points read 
    /// from the selected text file.
    /// </summary>
    List<XYZ> _pts;

    /// <summary>
    /// Define initial XYZ coordinate 
    /// text file folder.
    /// </summary>
    static string _txt_folder_name
      = Path.GetTempPath();

    /// <summary>
    /// Remember last selected filename for the 
    /// duration of the current session.
    /// </summary>
    static string _filename = string.Empty;

    public PlaceInstancesForm( Document doc )
    {
      InitializeComponent();

      _doc = doc;
      _pts = null;
    }

    private void PlaceInstancesForm_Load(
      object sender,
      EventArgs e )
    {
      List<Family> families = new List<Family>(
        new FilteredElementCollector( _doc )
          .OfClass( typeof( Family ) )
          .Cast<Family>()
          .Where<Family>( f =>
            f.FamilyPlacementType ==
              FamilyPlacementType.OneLevelBased ) );

      cmbFamily.DataSource = families;
      cmbFamily.DisplayMember = "Name";

      txtFilename.Text = _filename;
    }

    private void cmbFamily_SelectedIndexChanged(
      object sender,
      EventArgs e )
    {
      ComboBox cb = sender as ComboBox;

      Debug.Assert( null != cb,
        "expected a combo box" );

      Debug.Assert( cb == cmbFamily,
        "what combo box are you, then?" );

      Family f = cb.SelectedItem as Family;

      FamilySymbolSet symbols = f.Symbols;

      // I have to convert the FamilySymbolSet to a
      // List, or the DataSource assignment will throw 
      // an exception saying "Complex DataBinding 
      // accepts as a data source either an IList or
      // an IListSource.

      List<FamilySymbol> symbols2
        = new List<FamilySymbol>(
          symbols.Cast<FamilySymbol>() );

      cmbType.DataSource = symbols2;
      cmbType.DisplayMember = "Name";
    }

    private void btnBrowseXyz_Click(
      object sender,
      EventArgs e )
    {
      if( Util.FileSelectTxt( _txt_folder_name,
        ref _filename ) )
      {
        txtFilename.Text = _filename;

        _txt_folder_name = Path.GetDirectoryName(
          _filename );
      }
    }

    private void btnOk_Click(
      object sender,
      EventArgs e )
    {
      StreamReader reader = File.OpenText(
        txtFilename.Text );

      string read = reader.ReadToEnd();

      string[] lines = read.Split( '\n' );

      string s;
      double[] xyz = new double[3] { 0, 0, 0 };

      foreach( string line in lines )
      {
        s = line.Trim();

        if( 0 == s.Length || s.StartsWith( "#" ) )
        {
          continue;
        }

        // Parse string s for exactly two or three
        // real numbers representing the XY or XYZ
        // placement coordinates. Z defaults to 0.

        if( GetThreeRealNumbers( s, ref xyz ) )
        {
          XYZ p = new XYZ( xyz[0], xyz[1], xyz[2] );

          if( null == _pts )
          {
            _pts = new List<XYZ>( 1 );
          }
          _pts.Add( p );
        }

        continue;

        #region Regular expression matching all three real numbers at once
        // This approach using the _xyz_real_number_regex
        // gobbles the optional +- sign from the Y and 
        // Z coordinates, so we will use a different 
        // approach.

        Match m = _regex.Match( s );

        foreach( Group g in m.Groups )
        {
          Debug.Print( g.ToString() );
        }

        if( m.Success )
        {
          XYZ p = new XYZ(
            double.Parse( m.Groups["X"].ToString() ),
            double.Parse( m.Groups["Y"].ToString() ),
            double.Parse( m.Groups["Z"].ToString() ) );

          if( null == _pts )
          {
            _pts = new List<XYZ>( 1 );
          }
          _pts.Add( p );
        }
        #endregion // Regular expression matching all three real numbers at once
      }
    }

    //public string FamilyName
    //{
    //  get { return ( cmbFamily.SelectedItem as Family ).Name; }
    //}

    //public string TypeName
    //{
    //  get { return ( cmbType.SelectedItem as FamilySymbol ).Name; }
    //}

    /// <summary>
    /// The selected family.
    /// </summary>
    //public Family Family
    //{
    //  get { return cmbFamily.SelectedItem as Family; }
    //}

    /// <summary>
    /// The selected family symbol to be placed.
    /// </summary>
    public FamilySymbol Type
    {
      get
      {
        return cmbType.SelectedItem as FamilySymbol;
      }
    }

    /// <summary>
    /// The list of coordinate points read 
    /// from the selected text file.
    /// </summary>
    public IList<XYZ> Points
    {
      get
      {
        return _pts;
      }
    }
  }
}
