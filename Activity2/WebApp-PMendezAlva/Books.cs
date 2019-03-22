using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApp_PMendezAlva
{
    public class Books
    {
        public string ISBN { get; set; }
        public string Name { get; set; }
        public double PurchaseCost { get; set; }
        public double SellingPrice { get; set; }

        public Books()
        {

        }
        public Books(string isbn, string name, double cost, double price)
        {
            ISBN = isbn;
            Name = name;
            PurchaseCost = cost;
            SellingPrice = price;
        }
    }
}