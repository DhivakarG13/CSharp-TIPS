﻿namespace Task_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            ListManager<string> library = new ListManager<string>();
            library.AddItem("Tamil");
            library.AddItem("Maths");
            library.AddItem("Science");
            library.AddItem("English");
            library.AddItem("Electrical");
            library.PrintItems();
            library.RemoveItem("English");
            library.RemoveItem("fence");
            library.PrintItems();
            Console.WriteLine(":: Search Operations ::");
            library.FindItem("Maths");
            library.FindItem("Tamil");
            library.FindItem("English");
            Console.ReadKey();
        }
    }
}
