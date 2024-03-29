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
                beginning+"Newtonsoft.Json-2.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-2.0.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-2.0.4\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-3.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-3.5.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-3.5.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-3.5.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-3.5.4\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-3.5.5\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-3.5.6\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-3.5.7\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-3.5.8\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-4.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-4.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-4.0.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.0.4\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.0.5\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.0.6\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.0.7\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.0.8\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-4.5.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-4.5.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-4.5.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.4\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.5\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.6\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.7\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.8\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.9\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.10\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-4.5.11\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-5.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-5.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-5.0.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-5.0.4\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-5.0.5\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-5.0.6\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-5.0.7\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-5.0.8\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-6.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-6.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-6.0.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-6.0.4\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-6.0.5\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-6.0.6\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-6.0.7\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-6.0.8\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-7.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-8.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-8.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-8.0.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-9.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-10.0.1\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-10.0.2\\Src\\Newtonsoft.Json\\",
                beginning+"Newtonsoft.Json-10.0.3\\Src\\Newtonsoft.Json\\",
                //beginning+"Newtonsoft.Json-11.0.1\\Src\\Newtonsoft.Json\\"
            };

            Metrics[] dataList = new Metrics[VersionList.Length];

            int i;
            for(i = 0; i < VersionList.Length; i++)
            {
                Metrics Analysis = new Metrics();
                Analysis.RunMetrics(VersionList[i], i);
                Analysis.ExtractAndSetData();
                dataList[i] = Analysis;
                Console.Write("\n" + i + ",");
                int num;
                for (num = 0; num < dataList[i].GetAll().Length; num++)
                {
                    if (num == (dataList[i].GetAll().Length - 1))
                    {
                        Console.Write(dataList[i].GetAll()[num]);
                        break;
                    }
                    Console.Write(dataList[i].GetAll()[num] + ",");
                    
                }
            }

            /*

            Preprocessing PP = new Preprocessing(dataList);
            int[] MI_array = PP.GetAll_MI();
            int[] CYC_array = PP.GetAll_CYC();
            int[] CLC_array = PP.GetAll_CLC();
            int[] DI_array = PP.GetAll_DI();
            int[] SL_array = PP.GetAll_SL();
            int[] EL_array = PP.GetAll_EL();

            int num;
            Console.Write("MI: ");
            for (num = 0; num < MI_array.Length; num++)
            {
                Console.Write(MI_array[num] + ",");
                if(num == (MI_array.Length - 1))
                {
                    Console.Write(MI_array[num]);
                    break;
                }
            }
            
            Console.Write("\nCYC: ");
            for (num = 0; num < CYC_array.Length; num++)
            {
                Console.Write(CYC_array[num] + ",");
                if (num == (CYC_array.Length - 1))
                {
                    Console.Write(CYC_array[num]);
                    break;
                }
            }

            Console.Write("\nCLC: ");
            for (num = 0; num < CLC_array.Length; num++)
            {
                Console.Write(CLC_array[num] + ",");
                if (num == (CLC_array.Length - 1))
                {
                    Console.Write(CLC_array[num]);
                    break;
                }
            }

            Console.Write("\nDI: ");
            for (num = 0; num < DI_array.Length; num++)
            {
                Console.Write(DI_array[num] + ",");
                if (num == (DI_array.Length - 1))
                {
                    Console.Write(DI_array[num]);
                    break;
                }
            }

            Console.Write("\nSL: ");
            for (num = 0; num < SL_array.Length; num++)
            {
                Console.Write(SL_array[num] + ",");
                if (num == (SL_array.Length - 1))
                {
                    Console.Write(SL_array[num]);
                    break;
                }
            }

            Console.Write("\nEL: ");
            for (num = 0; num < EL_array.Length; num++)
            {
                Console.Write(EL_array[num] + ",");
                if (num == (EL_array.Length - 1))
                {
                    Console.Write(EL_array[num]);
                    break;
                }
            }
            */
            Console.ReadKey();
        }
    }
}