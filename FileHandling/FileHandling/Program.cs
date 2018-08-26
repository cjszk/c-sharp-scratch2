using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace FileHandling {
    class Program {
        static void Main(string[] args) {
            string path = "c:\\myFile.txt";
            //true indicates we want to append the data, without it, it would overwrite data.
            StreamWriter sw = new StreamWriter(path,true);
            sw.WriteLine("It is easy to write to a file.");
            sw.Close();

            //try {
            //    using (StreamReader sr = new StreamReader(path)) {
            //        while (sr.EndOfStream != true) {
            //            Console.WriteLine(sr.ReadLine());
            //        }
            //        sr.Close();
            //    }
            //} catch (FileNotFoundException e) {
            //    Console.WriteLine(e.Message);
            //}

            if (File.Exists(path)) {
                using (StreamReader sr = new StreamReader(path)) {
                    while (sr.EndOfStream != true) {
                        Console.WriteLine(sr.ReadLine());
                    }
                    sr.Close();
                }
            } else {
                Console.WriteLine("Unable to locate file, please check the path.");
            }


            Console.Read();
        }
    }
}
