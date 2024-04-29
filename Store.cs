﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Store 
    {
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Person> Customers { get; set; }
        public List<Item> ItemsAvailable { get; set; }

    }

    public class Item
    {
        public Item()
        {
            LegalAge = 0;
        }

        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public string Firm { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid ItemId { get; set; }
        public float Price { get; set; }
        public int LegalAge { get; set; } // set to the year required to buy (energy drink: 15, alcohol: 18...)
        public bool IsExpired
        {
            get
            {
                if (ExpirationDate > DateTime.Today) return true;
                else return false;
            }
        }

        
    }

    public class Transaction
    {
        public Store InStore { get; set; }
        public Employee Cashier { get; set; }
        public Person Customer { get; set; }
        public List<Item> PurchasedItems { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public float TotalPrice
        {
            get
            {
                float res = 0;
                for (int i = 0; i < PurchasedItems.Count; i++)
                    res += PurchasedItems[i].Price;
                return res;
            }
        }

    }

    
}
