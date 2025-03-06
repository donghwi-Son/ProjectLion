using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Configuration;

namespace MyCompiler
{
    class Program
    {
        public static void Main(string[] args)
        {
            string str = Console.ReadLine();
            HashSet<string> set = new HashSet<string>();
            int x = str.Length;
            for (int i = 1; i < str.Length; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    set.Add(str.Substring(j, i));
                }
                x--;
            }
            Console.WriteLine(set.Count+1);
        
        }
        
    }
}