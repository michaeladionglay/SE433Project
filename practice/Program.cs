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
            string[] VersionList = 
            {
                beginning+"Newtonsoft.Json-2.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.3\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.4\\Src\\Newtonsoft.Json\\"
            };

            Metrics[] dataList = new Metrics[VersionList.Length];

            int i;
            for(i = 0; i < VersionList.Length; i++)
            {
                Metrics Analysis = new Metrics();
                Analysis.RunMetrics(VersionList[i], i);
                Analysis.ExtractAndSetData();
                dataList[i] = Analysis;
            }



            Preprocessing PP = new Preprocessing(dataList);
            int[] MI_array = PP.GetAll_MI();
            int[] CYC_array = PP.GetAll_CYC();
            int[] CLC_array = PP.GetAll_CLC();
            int[] DI_array = PP.GetAll_DI();
            int[] SL_array = PP.GetAll_SL();
            int[] EL_array = PP.GetAll_EL();

            
        }
    }
}