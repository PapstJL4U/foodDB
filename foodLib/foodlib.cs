﻿using System;
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

    public static int Size()
    {
        return _Rezepte.Count;
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
        //gibt liste an Rezeptnamen zurück, deren Rezeptname den namen als teil enthält
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
        //gibt eine Liste an Rezeptnamen zurück, deren Rezeptzutat "Zutat" enthält
        List<string> Liste = new List<string>();
        foreach(var entry in _Rezepte.Keys)
        {
            FoodList<string> Zutaten = (FoodList<string>)_Rezepte[entry];
            if(Zutaten.Contains(Zutat.ToLower()))
            {
                Liste.Add(entry);
            }
        }
        return Liste;
    }

    public static List<string> RezeptZutatOR(string[] Zutat){
        //gibt eine Liste an Rezeptnamen zurück, deren Rezeptzutat eine Zutat aus der Liste enthält
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

    public static List<string> RezeptZutatAND(string[] Zutat)
    {   
        //gibt eine Liste an Rezeptnamen zurück, deren Rezeptzutat alle Zutaten aus der Liste enthält
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

    public static String RNGRezept()
    {
        Random rng = new Random();
        int rng_choice = rng.Next(0,_Rezepte.Count());
        List<string> list = _Rezepte.Keys.ToList();
        return list[rng_choice];
    }

}
//class, that acts like a list except for special "contain method"
/*
    contains should return true if asked for "käse" and the list contains "mozzarella" or "gouda", and in reverse
    more rules to come
*/
    internal class FoodList<T> : List<string>
    {   
        public bool Contains(string element)
        {

                switch(element)
                {
                    case "zwiebeln":
                        return base.Contains("zwiebel");
                    case "käse":
                    case "gouda":
                    case "mozarella":
                        return cheese();
                    default:
                        return base.Contains(element);
                }
        }

        private bool cheese(){
            if(base.Contains("käse")||base.Contains("gouda")||base.Contains("mozarella"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
