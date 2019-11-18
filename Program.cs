using System;
using System.IO;

namespace Project_MJ
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] VersionList = {
                "C:\\Users\\mia_d\\Desktop\\Newtonsoft.Json-2.0.1\\Src\\Newtonsoft.Json\\",
                //"C:\\Users\\mia_d\\Desktop\\Newtonsoft.Json-2.0.1\\Src\\Newtonsoft.Json\\",
                //"C:\\Users\\mia_d\\Desktop\\Newtonsoft.Json-2.0.1\\Src\\Newtonsoft.Json\\",
                };

            Metrics Analysis = new Metrics();
            Analysis.RunMetrics(VersionList);
        }
    }
}