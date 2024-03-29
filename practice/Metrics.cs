﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Diagnostics;

namespace Project_MJ
{
    class Metrics
    {
        private int MaintainabilityIndex { get; set; }
        private int CyclomaticComplexity { get; set; }
        private int ClassCoupling { get; set; }
        private int DepthOfInheritance { get; set; }
        private int SourceLines { get; set; }
        private int ExecutableLines { get; set; }
        private string Output { get; set; }

        public int [] GetAll()
        {
            int[] allAttributes = {this.MaintainabilityIndex,
                                    this.CyclomaticComplexity,
                                    this.ClassCoupling,
                                    this.DepthOfInheritance,
                                    this.SourceLines,
                                    this.ExecutableLines,
                                    };
            return allAttributes;
        }

        public void RunMetrics(string Version, int num)
        {
            string metrics_dir = "C:\\Users\\mia_d\\.nuget\\packages\\microsoft.codeanalysis.metrics\\2.9.6\\Metrics\\";

            File.Delete("C:\\Users\\mia_d\\Desktop\\reports\\Version_" + num + ".xml");
            string input = Version + "Newtonsoft.Json.csproj";
            this.Output = "C:\\Users\\mia_d\\Desktop\\reports\\Version_" + num + ".xml";
            Process processID = Process.Start("CMD.exe", "/C " + metrics_dir + "Metrics.exe /p:" + input + " /o:" + this.Output);

            while (!processID.HasExited) { }
        }

        public void ExtractAndSetData()
        {
            //"C:\\Users\\mia_d\\Desktop\\reports\\Version_" + num + ".xml"

            XmlTextReader reader = new XmlTextReader(this.Output);

            //reader.MoveToContent();
            reader.ReadToDescendant("Metrics");
            Boolean isFull = false;
            while (reader.Read() && !isFull)
            {
                while (reader.MoveToNextAttribute())
                {
                    if(reader.Value == "MaintainabilityIndex")
                    {
                        reader.MoveToNextAttribute();
                        this.MaintainabilityIndex = Int32.Parse(reader.Value);

                    }

                    if (reader.Value == "CyclomaticComplexity")
                    {
                        reader.MoveToNextAttribute();
                        this.CyclomaticComplexity = Int32.Parse(reader.Value);
                    }

                    if (reader.Value == "ClassCoupling")
                    {
                        reader.MoveToNextAttribute();
                        this.ClassCoupling = Int32.Parse(reader.Value);
                    }

                    if (reader.Value == "DepthOfInheritance")
                    {
                        reader.MoveToNextAttribute();
                        this.DepthOfInheritance = Int32.Parse(reader.Value);
                    }

                    if (reader.Value == "SourceLines")
                    {
                        reader.MoveToNextAttribute();
                        this.SourceLines = Int32.Parse(reader.Value);
                    }

                    if (reader.Value == "ExecutableLines")
                    {
                        reader.MoveToNextAttribute();
                        this.ExecutableLines = Int32.Parse(reader.Value);
                        isFull = true;
                    }

                   
                }
                /*
                if (isFull)
                {
                    break;
                }
                */
                
            }
          

        }


    }
}
