﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Lab1
{
    class Program
    {
        static string[] SearchDirectory(string path)
        {
            string[] resultSearch = Directory.GetDirectories(path);
            return resultSearch;
        }

        static string[] SearchFiles(string path, string pattern)
        {
            string[] resultSearch = Directory.GetFiles(path, pattern, SearchOption.AllDirectories);
            return resultSearch;
        }

        static void WriteResult(string resultFile, List<string> all_files)
        {
            List<string> resultText = new List<string>();
            foreach (string file in all_files)
            {
                resultText.AddRange(File.ReadAllLines(file));

            }

            File.WriteAllLines(resultFile, resultText);
        }

        static List<string> FoundFiles(string[] res, string path_for_search, string fileName)
        {
            string pattern = "*" + fileName + "*" + "*.txt";
            string print_res = "On " + path_for_search + "  found:\n";
            string[] dirfiles = Directory.GetFiles(path_for_search, pattern);
            
            List<string> all_files = new List<string>();
            foreach (string dirfile in dirfiles)
            {
                print_res += dirfile + "\n";
                all_files.Add(dirfile);
            }

            foreach (string folder in res)
            {
                try
                {
                    string[] files = SearchFiles(folder, pattern);
                    foreach (string file in files)
                    {
                        print_res += file + "\n";
                        all_files.Add(file);
                    }
                }
                catch
                {
                    Console.WriteLine("Directory access error: " + folder);
                }
            }
            Console.WriteLine(print_res);
            return all_files;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(@"Searching E:\\");
            Console.WriteLine(".......................");
            string path_for_search = @"E:\osis_labs\Lab1";
            string resultFile = @"E:\osis_labs\Lab1\result.txt";

            string[] res = SearchDirectory(path_for_search);
            List<string> all_files = FoundFiles(res, path_for_search, kek);
            WriteResult(resultFile, all_files);
            
            Console.ReadKey();
        }
    }
}
