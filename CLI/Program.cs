//initial CLI
using System;
namespace CLI
{
    class CLI
    {
        public static void Main(string[] args){
            foodLib.foodLib.FileReader();
            CLInput();
            Console.WriteLine("Thank you!");
            
        }
        private static void WriteAll(List<string> rezeptnamelist)
        {//schreibt alle rezeptnamen und zutaten

            Console.WriteLine("Rezepte:");
            foreach(var name in rezeptnamelist)
                    {
                        Console.Write($"{name}: "); 
                        foreach(var z in foodLib.foodLib.Rezepte()[name])
                            Console.Write($"{z},");
                        Console.WriteLine("");
                    }
        }
        private static void CLInput()
        {//command line input :V

            Console.WriteLine("Zutat oder Zutaten(,)?:");
            string[] input = Console.ReadLine().Split(",");
            //string[] input = new string[]{"zwiebel", "hackfleisch"}; 
            for(int i=0; i<input.Length; i++)
            {//kein whitespace!
                input[i] = input[i].TrimStart().TrimEnd();
            }
            
            if(input[0].ToLower()=="rng" || input[0]=="")
            {//für die lustlosen das zufällige rezept
               
                var rez = foodLib.foodLib.RNGRezept();
                Console.WriteLine($"You got:{rez}");
                Console.WriteLine("==========================");
                CLInput();
            }
            else if(input[0].ToLower() == "exit" || input[0].ToLower() == "x")
            {//ausgang oder für immer essen!

                Console.WriteLine("Well done.");
            }
            else
            {//erkennung ob input ein rezeptname war oder eine liste von zutaten
                    
                List<string> rezept = foodLib.foodLib.RezeptName(input[0].ToLower());
                if(rezept.Count>0) //wenn 0, dann war der erste eingabe name teil eines rezeptnamens
                {
                    WriteAll(rezept);
                }
                else
                {   
                    List<string> rez = new List<string>();

                    if(input.Length==1)
                    {
                        rez = foodLib.foodLib.RezeptZutat(input[0]);
                    }
                    else
                    {
                        Console.Write("[O]r xor [A]nd:");
                        string Zinput = Console.ReadLine();
                              
                        if(Zinput.ToLower()=="o")
                        {
                            rez = foodLib.foodLib.RezeptZutatOR(input);
                        }
                        else if(Zinput.ToLower()=="a")
                        {
                            rez = foodLib.foodLib.RezeptZutatAND(input);
                        }
                        else
                        {
                            CLInput();
                        }

                    }

                    WriteAll(rez);

                }
                
                CLInput();
                
            }
        }

        
    }
}