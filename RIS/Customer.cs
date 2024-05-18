using System;

namespace RIS
{
    // Customer class include name and number (contact info)
    public class Customer
    {
        public string Name { get; set; }
        public string Number { get; set; }

        public Customer(string name, string number)
        {
            Name = name;
            Number = number;
        }
    }
}