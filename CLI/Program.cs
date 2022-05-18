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
            var three = foodLib.foodLib.RezeptZutatOR(new string[]{"zwiebel", "hackfleisch"});
            Console.WriteLine($"{three.Count}");
            var four = foodLib.foodLib.RezeptZutatAND(new string[]{"zwiebel", "hackfleisch"});
            Console.WriteLine($"{four[0]}, {four[1]}");
            Console.WriteLine("Done! Thank you!");
        }
    }
}