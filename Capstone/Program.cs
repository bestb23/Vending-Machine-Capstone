using Capstone.Classes;
using Capstone.Views;
using System;
using System.Collections.Generic;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vm = new VendingMachine(@"..\..\..\TextFiles\VendingMachineInputFile.txt", @"..\..\..\TextFiles\Log.txt");
            foreach (KeyValuePair<string, Product> kvp in vm.products)
            {
                Console.WriteLine($"{kvp.Value.Code} | {kvp.Value.Name} | {kvp.Value.Cost} | {kvp.Value.ProductType} | {kvp.Value.NumberItemsRemaining}");
            }

            MainMenu mm = new MainMenu(vm);
            mm.Run();
            Console.ReadLine();
        }
    }
}
