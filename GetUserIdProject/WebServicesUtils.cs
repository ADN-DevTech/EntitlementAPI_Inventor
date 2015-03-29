using System;
using System.Runtime.InteropServices;
using System.Text;

namespace GetUserIdProject
{
  class WebServicesUtils
  {
    [DllImport("AdWebServices", EntryPoint = "GetUserId", CharSet = CharSet.Unicode)]
    private static extern int AdGetUserId(StringBuilder userid, int buffersize);

    [DllImport("AdWebServices", EntryPoint = "IsWebServicesInitialized")]
    private static extern bool AdIsWebServicesInitialized();

    [DllImport("AdWebServices", EntryPoint = "InitializeWebServices")]
    private static extern void AdInitializeWebServices();

    [DllImport("AdWebServices", EntryPoint = "IsLoggedIn")]
    private static extern bool AdIsLoggedIn();

    [DllImport("AdWebServices", EntryPoint = "GetLoginUserName", CharSet = CharSet.Unicode)]
    private static extern int AdGetLoginUserName(StringBuilder username, int buffersize);

    internal static string _GetUserId()
    {
      int buffersize = 128; //should be long enough for userid
      StringBuilder sb = new StringBuilder(buffersize);
      int len = AdGetUserId(sb, buffersize);
      sb.Length = len;

      return sb.ToString();
    }

    internal static string _GetUserName()
    {
      int buffersize = 128; //should be long enough for username 
      StringBuilder sb = new StringBuilder(buffersize);
      int len = AdGetLoginUserName(sb, buffersize);
      sb.Length = len;

      return sb.ToString();
    }

    public static string GetUserId(out string userName) 
    {
      AdInitializeWebServices();

      if (!AdIsWebServicesInitialized())
        throw new Exception("Could not initialize the web services component.");

      if (!AdIsLoggedIn())
        throw new Exception("User is not logged in.");

      string userId = _GetUserId();
      if (userId == "")
        throw new Exception("Could not get user id.");

      userName = _GetUserName();
      if (userName == "")
        throw new Exception("Could not get user name.");

      return userId;
    }
  }
}
