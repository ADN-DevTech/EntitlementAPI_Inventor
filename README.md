#EntitlementAPI_Inventor

Shows how to use the **Entitlement API** from an Inventor AddIn. See [blog article](http://adndevblog.typepad.com/manufacturing/2015/03/entitlement-api-in-inventor.html) about it.

##Dependencies

None

##Setup/Usage Instructions

* Compile the project

* Place the [Autodesk.GetUserIdProject.Inventor.addin](GetUserIdProject/Autodesk.GetUserIdProject.Inventor.addin) file in one of the folders that Inventor monitors for AddIn's, e.g. **"C:\ProgramData\Autodesk\ApplicationPlugins"**. More info on this in the [project readme.txt](GetUserIdProject/Readme.txt) 

* In that file modify the information surrounded by the &lt;Assembly&gt;&lt;/Assembly&gt; tags so that it has the correct location of the **GetUserIdProject.dll**

## License

That samples are licensed under the terms of the [MIT License](http://opensource.org/licenses/MIT). Please see the [LICENSE](LICENSE) file for full details.

##Written by 

Adam Nagy

