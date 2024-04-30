using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Store 
    {
        public Store()
        {
            Employees = new List<Employee>();
            Customers = new List<Person>();
            ItemsAvailable = new List<Item>();
            Transactions = new List<Transaction>();
        }
        public string Name { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Person> Customers { get; set; }
        public List<Item> ItemsAvailable { get; set; }
        public List<Transaction> Transactions { get; set; }

        public override string ToString()
        {
            return $"---Store Name---\n{Name}\n\n" +
                   $"---Employees---\n{string.Join("\n", Employees)}\n\n" +
                   $"---Customers---\n{string.Join("\n", Customers)}\n\n" +
                   $"---Items Available---\n{string.Join("\n", ItemsAvailable)}\n\n" +
                   $"---Transactions---\n{string.Join("\n\n", Transactions)}\n\n";
        }
    }

    public class Item
    {
        public Item()
        {
            LegalAge = 0;
            BarCodeID = Guid.NewGuid();
        }

        public string Name { get; set; }
        public string ProductType { get; set; }
        public string Description { get; set; }
        public string Firm { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Guid BarCodeID { get; set; }
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

        public override string ToString()
        {
            return $"Name: {Name}, ProductType: {ProductType}, Price: {Price}CZK, BarCodeID: {BarCodeID}";
        }

    }

    public class Transaction
    {
        public Transaction()
        {
            DateOfPurchase = DateTime.Now;
            PurchasedItems = new List<Item>();
            TransactionID = Guid.NewGuid(); 
        }
        public Employee Cashier { get; set; }
        public Person Customer { get; set; }
        public List<Item> PurchasedItems { get; set; }
        public DateTime DateOfPurchase { get; set; }
        public Guid TransactionID { get; set; }
        public double TotalPrice
        {
            get
            {
                float res = 0;
                for (int i = 0; i < PurchasedItems.Count; i++)
                    res += PurchasedItems[i].Price;
                return Math.Round(res, 2);
            }
        }

        public override string ToString()
        {
            return "Cashier: " + Cashier + "\n" +
                   "Customer: " + Customer + "\n" +
                   "Purchased items:\n" + string.Join("\n", PurchasedItems) + "\n" +
                   "Date Of Purchase: " + DateOfPurchase + "\n" +
                   "Transaction ID: " + TransactionID + "\n" +
                   "Total Price: " + TotalPrice + "CZK";
        }

    }

    
}
