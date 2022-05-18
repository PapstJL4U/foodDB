//initial CLI
using System;
using foodLib;
namespace CLI
{
    class CLI
    {
        public static void Main(string[] args){
            foodLib.foodLib.FileReader();

            CLInput();

            Console.WriteLine("Thank you!");
        }

        private static void CLInput()
        {   
            Console.Write("Zutat oder Zutaten?:");
            string[] input = Console.ReadLine().Split(",");
            for(int i=0; i<input.Length-1; i++)
            {
                input[i] = input[i].TrimStart().TrimEnd();
            }
            
            if(input[0].ToLower()=="rng" || input[0]=="")
            {
               
                var rez = foodLib.foodLib.RNGRezept();
                Console.WriteLine($"You got:{rez}");
                Console.WriteLine("==========================");
                CLInput();
            }
            else if(input[0].ToLower() == "exit" || input[0].ToLower() == "x")
            {
                //finished
                Console.WriteLine("Well done.");
            }
            else
            {
                //TODO

                
            }
        }
    }
}