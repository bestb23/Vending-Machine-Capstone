using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        public Dictionary<string, Product> products = new Dictionary<string, Product>();

        // property for the amount of money in the machine entered by the customer
        public decimal CurrentMoneyProvided { get; set; }
        // private string filePath = @"..\..\..\TextFiles\VendingMachineInputFile.txt";
        private string logFilePath;
        
        // constructor
        public VendingMachine(string inputFilePath, string logFilePath)
        {
            CurrentMoneyProvided = 0.00M;
            this.loadMachine(inputFilePath);
            this.logFilePath = logFilePath;
        }

        // method receives money from the customer and updates current money provided
        public void ReceiveMoney(double money)
        {
            CurrentMoneyProvided += (decimal)money;
            this.logMoney(logFilePath, money);
        }

        // accept customer code and check if the product is available. If it is, update money remaining, and update number of product remaining.
        public void AcceptCode(string code)
        {
            code = code.ToUpper();
            if (products.ContainsKey(code) && products[code].NumberItemsRemaining > 0 && CurrentMoneyProvided >= (decimal)products[code].Cost)
            {
                products[code].NumberItemsRemaining--;
                CurrentMoneyProvided -= (decimal)products[code].Cost;
                this.logPurchase(this.logFilePath, code); // TODO COME BACK TO THIS AFTER WRITING LOGPURCHASE METHOD
            }
        }

        // load machine by reading in from file
        private void loadMachine(string filePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string inputTxt = sr.ReadLine();
                        string[] productInfo = inputTxt.Split('|');
                        string code = productInfo[0].Trim();
                        string name = productInfo[1].Trim();
                        double cost = double.Parse(productInfo[2].Trim());
                        string productType = productInfo[3].Trim();
                        int numberItemsRemaining = int.Parse(productInfo[4].Trim());
                        Product product = new Product(code, name, cost, productType, numberItemsRemaining);
                        products.Add(product.Code, product);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadLine();
            }
        }
        
        // log each purchase into Log.txt
        private void logPurchase(string filePath, string code)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(DateTime.Now.ToString().PadRight(30) +
                    products[code.ToUpper()].Name.ToString().PadRight(20) +
                    code.ToUpper().PadRight(10) +
                    (CurrentMoneyProvided + (decimal)products[code.ToUpper()].Cost).ToString("C").PadRight(10) +
                    CurrentMoneyProvided.ToString("C"));
            }
        }
        // log each acceptmoney into log.txt
        private void logMoney(string filePath, double money)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(DateTime.Now.ToString().PadRight(30) +
                    "FEED MONEY:".PadRight(20) + "".PadRight(10) +
                    money.ToString("C").PadRight(10) +
                    CurrentMoneyProvided.ToString("C"));
            }
        }

        private void logChange(string filePath, double changeGiven)
        {
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine(DateTime.Now.ToString().PadRight(30) +
                    "GIVE CHANGE:".PadRight(20) + "".PadRight(10) +
                    CurrentMoneyProvided.ToString("C").PadRight(10) +
                    "$0.00");
            }
        }

        // finish the transaction and give customer change back
        public Change FinishTransaction()
        {
            Change change = new Change((double)CurrentMoneyProvided);
            
            this.logChange(logFilePath, change.ChangeGiven);
            CurrentMoneyProvided = 0;
            return change;
        }
    }
}
