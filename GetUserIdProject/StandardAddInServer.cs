using System;
using System.Runtime.InteropServices;
using Autodesk.WebServices;
using Inventor;
using Microsoft.Win32;
using MsgBox = System.Windows.Forms.MessageBox;

namespace GetUserIdProject
{
  /// <summary>
  /// This is the primary AddIn Server class that implements the ApplicationAddInServer interface
  /// that all Inventor AddIns are required to implement. The communication between Inventor and
  /// the AddIn is via the methods on this interface.
  /// </summary>
  [GuidAttribute("dc8b7679-62eb-4a59-8e9a-a17c4d4c382a")]
  public class StandardAddInServer : Inventor.ApplicationAddInServer
  {
    // Inventor application object.
    private Inventor.Application m_inventorApplication;

    public StandardAddInServer()
    {
    }

    #region ApplicationAddInServer Members

    public void Activate(Inventor.ApplicationAddInSite addInSiteObject, bool firstTime)
    {
      // This method is called by Inventor when it loads the addin.
      // The AddInSiteObject provides access to the Inventor Application object.
      // The FirstTime flag indicates if the addin is loaded for the first time.

      // Initialize AddIn members.
      m_inventorApplication = addInSiteObject.Application;

      // TODO: Add ApplicationAddInServer.Activate implementation.
      // e.g. event initialization, command creation etc.

      CWebServicesManager mgr = new CWebServicesManager();
      bool isInitialized = mgr.Initialize();

      if (isInitialized)
      {
        try
        {
          string userId = "";
          mgr.GetUserId(ref userId);
          string userName = "";
          mgr.GetLoginUserName(ref userName);
          MsgBox.Show(
            "User ID = '" + userId + "\n" +
            "User Name = '" + userName + "'");
        }
        catch (Exception ex)
        {
          MsgBox.Show(ex.Message);
        }
      }

    }

    public void Deactivate()
    {
      // This method is called by Inventor when the AddIn is unloaded.
      // The AddIn will be unloaded either manually by the user or
      // when the Inventor session is terminated

      // TODO: Add ApplicationAddInServer.Deactivate implementation

      // Release objects.
      m_inventorApplication = null;

      GC.Collect();
      GC.WaitForPendingFinalizers();
    }

    public void ExecuteCommand(int commandID)
    {
      // Note:this method is now obsolete, you should use the 
      // ControlDefinition functionality for implementing commands.
    }

    public object Automation
    {
      // This property is provided to allow the AddIn to expose an API 
      // of its own to other programs. Typically, this  would be done by
      // implementing the AddIn's API interface in a class and returning 
      // that class object through this property.

      get
      {
        // TODO: Add ApplicationAddInServer.Automation getter implementation
        return null;
      }
    }

    #endregion

  }
}
