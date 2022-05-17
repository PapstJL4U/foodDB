//initial CLI
using System;
using foodLib;
namespace CLI
{
    class CLI
    {
        public static void Main(string[] args){
            foodLib.foodLib.FileReader();
            var one = foodLib.foodLib.RezeptName("joe");
            Console.WriteLine($"{one.Count}");
            var two = foodLib.foodLib.RezeptZutat("käse");
            Console.WriteLine($"{two.Count}");
            Console.WriteLine("Done! Thank you!");
        }
    }
}