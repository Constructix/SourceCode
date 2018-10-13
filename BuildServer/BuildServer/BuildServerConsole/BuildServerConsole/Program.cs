////////////////////////////////////////////////////////////////////////////////////////////////////////////////
/// Purpose:    Simulates or should I say, I was thinking how does a Build Server work.
///             So I decided to create this very basic BuildServerConsole.
///             BuildServerDemo is the component that builds the project file, specified
///             From ClientBuildDemo project.
///             It Doesn't use MSBuild API, because
///                 1. Documentation on it from Microsoft is limited.
///                 2. Documentation that exists, when using Version 15 does not work
///                    with VS2017, apprently there are bugs and there is no big
///                     deal to fix it from MS side.
/// 
///             think about creating a simple build server, using MSBuild.
///             Output is directed to an output file and once done, Use RegEx to parse
///             the output log file. Attempted to use the MSBuild API but it was buggy
///             and the documentation on Doc.microsoft was very ordinary. 
/// Date    :   20191013
/// Name    :   Richard Jones
/// 


namespace BuildServerConsole
{
    using System;
    class Program
    {
        static void Main(string[] args)
        {
            
            BuildManager buildManager= new BuildManager();
            ///////////////////////////////////////////////////////////////////////////////////
            /// setup event listener so we can see what is going on.
            buildManager.BuildManagerEvent += BuildManager_BuildManagerEvent;

            ///////////////////////////////////////////////////////////////////////////////////
            /// setup BuildCommand
            /// pass in the location where MSBuild resides.
            /// Pass in the csProj file.
            /// Pass in the outputlog where the buildmanager will retrieve the information
            /// and check that the build has succeeded or failed. If the build fails,
            /// the error list will be returned and displayed in error handler listener method.
            buildManager.AddCommand(new BuildCommand(@"C:\Windows\Microsoft.NET\Framework64\v4.0.30319\msbuild.exe", 
                                                    @"D:\Research\BuildServer\Client\ClientBuildDemo\ClientBuildDemo\ClientBuildDemo.csproj",
                                                    @"D:\temp\results.log"));
            buildManager.AddCommand(new ConsoleCommand(@"D:\temp\results.log"));

             buildManager.Start();
        }

        private static void BuildManager_BuildManagerEvent(object sender, BuildManagerEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
