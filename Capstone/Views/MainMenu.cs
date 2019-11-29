using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class MainMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public MainMenu(VendingMachine vm) : base(vm)
        {
            this.Title = "*** Main Menu ***";
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            this.menuOptions.Add("3", "Exit");
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1":
                    foreach (KeyValuePair<string, Product> kvp in base.VM.products)
                    {
                        Console.WriteLine($"{kvp.Value.Code.PadRight(10)}{kvp.Value.Name.PadRight(15)}{kvp.Value.Cost.ToString().PadRight(10)}{kvp.Value.ProductType.PadRight(10)}{kvp.Value.NumberItemsRemaining}");
                    }
                    Pause("");
                    return true;
                case "2":
                    // Get some input form the user, and then do something
                    PurchaseMenu pm = new PurchaseMenu(base.VM);
                    pm.Run();
                    Pause("");
                    return true;
                case "3":
                    return false;
            }
            return true;
        }

    }
}
