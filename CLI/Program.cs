//initial CLI
using System;
using foodLib;
namespace CLI
{
    class CLI
    {
        public static void Main(string[] args){
            foodLib.foodLib.FileReader();
            Console.WriteLine("Done! Thank you!");
        }
    }
}