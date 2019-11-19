using System;
using System.IO;

namespace Project_MJ
{
    class Program
    {
        static void Main(string[] args)
        {
            string beginning = "C:\\Users\\mia_d\\Desktop\\Newtonsoft_Vers\\";
            string[] VersionList = {
                beginning+"Newtonsoft.Json-2.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.3\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.4\\Src\\Newtonsoft.Json\\"
                };
            
            
            Metrics Analysis = new Metrics();
            Analysis.RunMetrics(VersionList);
        }
    }
}