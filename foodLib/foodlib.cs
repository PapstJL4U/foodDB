using System;
using System.Collections.Generic;
using System.IO;
namespace foodLib;
public static class foodLib
{   
    private static string path = "food.tsv";
    public static Dictionary<string, string[]> Rezepte = new Dictionary<string, string[]>();
    public static void FileReader()
    {
        using(StreamReader SR = File.OpenText(path))
        {
            string line;
            while ((line = SR.ReadLine()) != null)
            {   
                string[] subs = line.Split("\t");
                Console.WriteLine(subs[0]);
            }
        }
    }
}
