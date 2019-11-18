using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_MJ
{
    class Metrics
    {
        public void RunMetrics(string [] dataList)
        {
            string metrics_dir = "C:\\Users\\mia_d\\.nuget\\packages\\microsoft.codeanalysis.metrics\\2.9.6\\Metrics\\";

            int versionCount;
            for(versionCount = 0; versionCount <= dataList.Length; versionCount++)
            {
                System.Diagnostics.Process.Start("CMD.exe", "/C " + metrics_dir + "Metrics.exe /p:" + dataList[versionCount] + "Newtonsoft.Json.csproj /o:C:\\Users\\mia_d\\Desktop\\reports\\Version_" + versionCount + ".xml");
            }
        }
    }
}
