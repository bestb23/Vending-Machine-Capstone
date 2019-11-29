using Capstone.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Views
{
    public class PurchaseMenu : CLIMenu
    {
        /// <summary>
        /// Constructor adds items to the top-level menu
        /// </summary>
        public PurchaseMenu(VendingMachine vm) : base(vm)
        {
            this.Title = "*** Purchase Menu ***";
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            // this.menuOptions.Add("Current Money Provided: ", VM.CurrentMoneyProvided.ToString());
        }

        private string feedMoneyOptions = "1,2,5,10";
        private Dictionary<string, string> productMessage = new Dictionary<string, string>()
        {
            { "Chip", "Crunch Crunch, Yum!" },
            { "Candy", "Munch Munch, Yum!" },
            { "Drink", "Glug Glug, Yum!" },
            { "Gum", "Chew Chew, Yum!" }
        };
        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            while (true)
            {
                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        Console.WriteLine("You selected Feed Money");
                        Console.WriteLine("Enter an integer 1, 2, 5, 10");
                        string feedMoneyInput = Console.ReadLine();
                        if (feedMoneyOptions.Contains(feedMoneyInput))
                        {
                            try
                            {
                                VM.ReceiveMoney(double.Parse(feedMoneyInput));
                                return true;
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Improper input, please try again.");
                            }
                            Pause("Press any key");
                        }
                        else
                        {
                            continue;
                        }
                        return true;

                    case "2":
                        Console.WriteLine("Select a product: ");
                        foreach (KeyValuePair<string, Product> kvp in base.VM.products)
                        {
                            Console.WriteLine($"{kvp.Value.Code.PadRight(10)}{kvp.Value.Name.PadRight(15)}{kvp.Value.Cost.ToString().PadRight(10)}{kvp.Value.ProductType.PadRight(10)}{kvp.Value.NumberItemsRemaining}");
                        }
                        Console.WriteLine("Enter a product code to select a product.");
                        string selectAProductInput = Console.ReadLine().ToUpper();
                        if (VM.products.ContainsKey(selectAProductInput))
                        {
                            try
                            {
                                if (VM.CurrentMoneyProvided >= (decimal)VM.products[selectAProductInput].Cost)
                                {
                                    if (VM.products[selectAProductInput].NumberItemsRemaining > 0)
                                    {
                                        VM.AcceptCode(selectAProductInput);
                                        Console.WriteLine($"{VM.products[selectAProductInput].Name.PadRight(15)}{VM.products[selectAProductInput].Cost.ToString("C").PadRight(10)} money remaining {VM.CurrentMoneyProvided.ToString("C").PadRight(10)}{productMessage[VM.products[selectAProductInput].ProductType]}");
                                        Pause("Press any key");
                                        return true;
                                    }
                                    else
                                    {
                                        Console.WriteLine("The product is sold out, please choose another product.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("You dont have enough money to buy that, please feed more money.");
                                }
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("Improper input, please try again.");
                            }
                            Pause("Press any key");
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Product code does not exist.");
                            Pause("Press any key");
                            return true;
                        }
                        return true;
                    case "3":
                        Console.WriteLine("Here is your change.");
                        Change change = VM.FinishTransaction();
                        Console.WriteLine(change.Quarters + " Quarters");
                        Console.WriteLine(change.Dimes + " Dimes");
                        Console.WriteLine(change.Nickels + " Nickels");
                        
                        return false;
                }
            }
        }
    }
}
