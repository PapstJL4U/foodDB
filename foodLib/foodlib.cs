using System;
using System.Collections.Generic;
using System.IO;
namespace foodLib;
public static class foodLib
{   
    private static string path = "food.tsv";
    private static Dictionary<string, List<string>> _Rezepte = new Dictionary<string, List<string>>();

    public static Dictionary<string, List<string>> Rezepte()
    {
        return _Rezepte;
    }

    public static void FileReader()
    {
        using(StreamReader SR = File.OpenText(path))
        {
            string line;
            while ((line = SR.ReadLine()) != null)
            {   
                string[] subs = line.Split("\t");
                string key = subs[0];
                List<string> value = subs.ToList<string>();
                value.Remove(key);

                _Rezepte.Add(key, value);
            }
        }
    }

    public static List<string> RezeptName(string Name){
        List<string> Liste = new List<string>();
        foreach(var entry in _Rezepte.Keys)
        {
            if(entry.Contains(Name.ToLower()))
            {
                Liste.Add(entry);
            }
        }
        return Liste;
    }

    public static List<string> RezeptZutat(string Zutat){
        List<string> Liste = new List<string>();
        foreach(var entry in _Rezepte.Keys)
        {
            List<string> Zutaten = _Rezepte[entry];
            if(Zutaten.Contains(Zutat.ToLower()))
            {
                Liste.Add(entry);
            }
        }
        return Liste;
    }

    public static List<string> RezeptZutatOR(string[] Zutat){
        List<string> Liste = new List<string>();
        foreach(var entry in _Rezepte.Keys)
        {   
            List<string> Zutaten = _Rezepte[entry];
            foreach(var z in Zutat)
            {  
                if(Zutaten.Contains(z.ToLower()))
                {   
                    if(!Liste.Contains(entry))
                    {
                        Liste.Add(entry);
                    }
                }
            }
            
        }
        return Liste;
    }

    public static List<string> RezeptZutatAND(string[] Zutat){
        List<string> Liste = new List<string>();
        foreach(var entry in _Rezepte.Keys)
        {   
            List<string> Zutaten = _Rezepte[entry];
            bool nicht_vorhanden = false;
            foreach(var z in Zutat)
            {   
                if(nicht_vorhanden == false)
                {
                    if(Zutaten.Contains(z))
                    {   
                        if(!Liste.Contains(entry))
                        {
                            Liste.Add(entry);
                        }
                    }
                    else
                    {   
                        Liste.Remove(entry);
                        nicht_vorhanden = true;
                    }
                }
            }
            
        }
        return Liste;
    }
}
