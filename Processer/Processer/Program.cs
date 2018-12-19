using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Xml;
using System.Configuration;

namespace Processer
{
    public class ProcSection : IConfigurationSectionHandler
    {
        public object Create(object parent, object configContext, XmlNode section)
        {
            List<Proc> myConfigObject = new List<Proc>();

            foreach (XmlNode childNode in section.ChildNodes)
            {
                //Console.WriteLine(childNode.Attributes[0].Value);
                //Console.WriteLine(childNode.Attributes[1].Value);
                myConfigObject.Add(new Proc() { Location = childNode.Attributes[1].Value, Name = childNode.Attributes[0].Value });

            }
            return myConfigObject;
        }
    }

    public class Proc
    {
        public string Location { get; set; }
        public string Name { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        { 
            Process[] processlist = Process.GetProcesses();

            //Console.WriteLine("Running processes:"); 
            //foreach (Process theprocess in processlist)
            //{
            //    Console.WriteLine("Process: {0} ID: {1}", theprocess.ProcessName, theprocess.Id);
            //}

            Console.WriteLine("Processes to kill:"); 
            List<Proc> Procs = ConfigurationManager.GetSection("KillTheProc") as List<Proc>; 
            foreach (Proc dir in Procs)
            {
                 Console.WriteLine("Name: {0}", dir.Name);
            }

            Console.WriteLine("Processes to run:");
            Procs = ConfigurationManager.GetSection("RunTheProc") as List<Proc>;

            foreach (Proc dir in Procs)
            {
                Console.WriteLine("Name: {0} Location: {1}", dir.Name, dir.Location);
            }

            Console.ReadKey();
        }
    }
}
