#region Namespaces
using System;
using System.Windows.Forms;
#endregion // Namespaces

namespace PlaceInstances
{
  class Util
  {
    /// <summary>
    /// Select a specified file in the given folder.
    /// </summary>
    /// <param name="folder">Initial folder.</param>
    /// <param name="filename">Selected filename on 
    /// success.</param>
    /// <returns>Return true if a file was successfully 
    /// selected.</returns>
    static bool FileSelect(
      string folder,
      string title,
      string filter,
      ref string filename )
    {
      OpenFileDialog dlg = new OpenFileDialog();
      dlg.Title = title;
      dlg.CheckFileExists = true;
      dlg.CheckPathExists = true;
      dlg.InitialDirectory = folder;
      dlg.FileName = filename;
      dlg.Filter = filter;
      bool rc = ( DialogResult.OK == dlg.ShowDialog() );
      filename = dlg.FileName;
      return rc;
    }

    /// <summary>
    /// Select a Revit family file in the given folder.
    /// </summary>
    /// <param name="folder">Initial folder.</param>
    /// <param name="filename">Selected filename on 
    /// success.</param>
    /// <returns>Return true if a file was successfully 
    /// selected.</returns>
    static public bool FileSelectRfa(
      string folder,
      ref string filename )
    {
      return FileSelect( folder,
        "Select Revit family file or Cancel to Exit",
        "Revit Family RFA Files (*.rfa)|*.rfa",
        ref filename );
    }

    /// <summary>
    /// Select a text file in the given folder.
    /// </summary>
    /// <param name="folder">Initial folder.</param>
    /// <param name="filename">Selected filename on 
    /// success.</param>
    /// <returns>Return true if a file was successfully 
    /// selected.</returns>
    static public bool FileSelectTxt(
      string folder,
      ref string filename )
    {
      return FileSelect( folder,
        "Select XYZ coordinate text file or Cancel to Exit",
        "XYZ coordinate text Files (*.txt)|*.txt",
        ref filename );
    }
  }
}
