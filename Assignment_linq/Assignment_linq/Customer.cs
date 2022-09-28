using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment_linq
{
    public class Customer
    {
        public string Name { get; set; }
        public double Balance { get; set; } 
        public string Bank { get; set; }
        public Customer(string Name, double Balance, string Bank)
        {
            this.Name = Name;
            this.Balance = Balance;
            this.Bank = Bank;
        }
    }
}
