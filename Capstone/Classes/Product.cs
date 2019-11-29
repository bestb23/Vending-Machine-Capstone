using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Product
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public string ProductType { get; set; }
        public int NumberItemsRemaining { get; set; }

        public Product(string code, string name, double cost, string productType, int numberItemsRemaining)
        {
            Code = code;
            Name = name;
            Cost = cost;
            ProductType = productType;
            NumberItemsRemaining = numberItemsRemaining;
        }
    }
}
