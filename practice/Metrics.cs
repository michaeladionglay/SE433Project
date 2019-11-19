using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_MJ
{
    class Metrics
    {
        public void RunMetrics(string [] dataList)
        {
            string metrics_dir = "C:\\Users\\mia_d\\.nuget\\packages\\microsoft.codeanalysis.metrics\\2.9.6\\Metrics\\";

            int versionCount;
            for(versionCount = 0; versionCount < dataList.Length; versionCount++)
            {
                File.Delete("C:\\Users\\mia_d\\Desktop\\reports\\Version_" + versionCount + ".xml");
                System.Diagnostics.Process.Start("CMD.exe", "/C " + metrics_dir + "Metrics.exe /p:" + dataList[versionCount] + "Newtonsoft.Json.csproj /o:C:\\Users\\mia_d\\Desktop\\reports\\Version_" + versionCount + ".xml");
            }
        }
    }
}
