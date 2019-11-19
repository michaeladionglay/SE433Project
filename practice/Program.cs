using System;
using System.IO;

namespace Project_MJ
{
    class Program
    {
        static void Main(string[] args)
        {
            string workingDirectory = Environment.CurrentDirectory;
            string beginning = Directory.GetParent(workingDirectory).Parent.FullName+"\\newtonsoft_Vers\\";
            string[] VersionList = {

                beginning+"Newtonsoft.Json-2.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.3\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.4\\Src\\Newtonsoft.Json\\"
                };

            Metrics Analysis = new Metrics();
            Analysis.RunMetrics(VersionList);
            //Console.ReadKey();
        }
    }
}