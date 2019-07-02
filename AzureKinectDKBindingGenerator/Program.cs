using System;
using System.IO;
using CppSharp.AST;
using CppSharp;

namespace AzureKinectDKBindingGenerator
{
    class AzureKinectDKSharp : ILibrary
    {
        public void Setup(Driver driver)
        {
            var sdkroot = @"C:\Program Files\Azure Kinect SDK v1.1.0\sdk";

            var options = driver.Options;
            options.OutputDir = @"C:\AzureKinectDKSharp";

            var module = options.AddModule("AzureKinectDKSharp");
            module.IncludeDirs.Add(Path.Combine(sdkroot, @"include\k4a"));
            module.LibraryDirs.Add(Path.Combine(sdkroot, @"windows-desktop\amd64\release\lib"));
            module.Headers.Add("k4a.hpp");
            module.Libraries.Add("k4a.lib");

            var parserOptions = driver.ParserOptions;
            parserOptions.AddIncludeDirs(Path.Combine(sdkroot, "include"));
            parserOptions.AddArguments("-fcxx-exceptions");
        }

        public void SetupPasses(Driver driver)
        {

        }

        public void Preprocess(Driver driver, ASTContext ctx)
        {
   
        }

        public void Postprocess(Driver driver, ASTContext ctx)
        {

        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ConsoleDriver.Run(new AzureKinectDKSharp());
            Console.WriteLine("Done");
            Console.ReadKey();
        }
    }
}
