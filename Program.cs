using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ProcKill.MODEL;

namespace ProcKill
{
    class Program
    {
        static ProcessList _list;

        static void Main(string[] args)
        {
            LoadFile();
            _list.Items.ForEach(
                delegate(ProcessItem pi)
                {
                    if (pi != null)
                    {
                        Process[] p = Process.GetProcessesByName(pi.Name);
                        Array.ForEach<Process>(p, 
                            delegate(Process pInfo)
                            {
                                try
                                {
                                    pInfo.Kill();
                                    Console.WriteLine("The process {0} was killed", pInfo.ProcessName);
                                }
                                catch
                                {
                                    Console.WriteLine("The process {0} can not was killed", pInfo.ProcessName);
                                }
                            }
                        );
                    }
                }
            );
            Console.ReadLine();
        }

        private static void LoadFile()
        {
            string xmlFileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ProcessList.xml");
            if (File.Exists(xmlFileName))
            {
                XmlSerializer s = new XmlSerializer(typeof(ProcessList));
                TextReader r = new StreamReader(xmlFileName);
                _list =(ProcessList) s.Deserialize(r);
                r.Close();
            }
        }
    }
}