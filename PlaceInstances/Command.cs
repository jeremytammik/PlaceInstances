#region Namespaces
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Structure;
using Autodesk.Revit.UI;
using Autodesk.Windows;
#endregion

namespace PlaceInstances
{
  [Transaction( TransactionMode.Manual )]
  public class Command : IExternalCommand
  {
    public Result Execute(
      ExternalCommandData commandData,
      ref string message,
      ElementSet elements )
    {
      IWin32Window revit_window
        = new JtWindowHandle(
          ComponentManager.ApplicationWindow );

      UIApplication uiapp = commandData.Application;
      UIDocument uidoc = uiapp.ActiveUIDocument;
      Document doc = uidoc.Document;

      PlaceInstancesForm f
        = new PlaceInstancesForm( doc );

      if( (DialogResult.OK == f.ShowDialog( revit_window ))
        && (null != f.Points) )
      {
        using( Transaction t = new Transaction( 
          doc ) )
        {
          t.Start( "Place Instances" );

          Autodesk.Revit.Creation.Document 
            creation_doc = doc.Create;

          StructuralType st
            = StructuralType.NonStructural;

          foreach( XYZ p in f.Points )
          {
            creation_doc.NewFamilyInstance(
              p, f.Type, st );
          }

          t.Commit();
        }
      }
      return Result.Succeeded;
    }
  }
}
