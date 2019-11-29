using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Change
    {
        public int Nickels { get; private set; }
        public int Dimes { get; private set; }
        public int Quarters { get; private set; }
        public double ChangeGiven { get; private set; }

        public Change(double change)
        {
            ChangeGiven = change;
            this.CalculateChange();
        }

        private void CalculateChange()
        {
            int cents = (int)((decimal)ChangeGiven * 100);

            int numQuarters = cents / 25;
            Quarters = numQuarters;
            cents -= numQuarters * 25;

            int numDimes = cents / 10;
            Dimes = numDimes;
            cents -= numDimes * 10;

            int numNickels = cents / 5;
            Nickels = numNickels;
            cents -= numNickels * 5;

            ChangeGiven = cents / 100.00;
        }
    }
}
