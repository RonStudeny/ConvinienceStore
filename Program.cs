﻿using Store;
namespace Store
{
    static class Script
    {
        public static void Main()
        {

            // CUSTOMER INSTANCES
            Person pepa = new Person
            {
                Name = "Pepa",
                Surname = "Zakaznicky",
                DoB = DateTime.Parse("25.2.1998")
            };

            Person tonda = new Person
            {
                Name = "Tonda",
                Surname = "Zapotocky",
                DoB = DateTime.Parse("18.4.2008")
            };

            Person ondra = new Person
            {
                Name = "Ondra",
                Surname = "Vopršálek",
                DoB = DateTime.Parse("11.3.2001")
            };

            Person lukas = new Person
            {
                Name = "Lukas",
                Surname = "Sustr",
                DoB = DateTime.Parse("13.11.1985")
            };

            Person jonas = new Person
            {
                Name = "Jonas",
                Surname = "Ruzovi",
                DoB = DateTime.Parse("25.2.1998")
            };

            Person walt = new Person
            {
                Name = "Walter",
                Surname = "Heisenberg",
                DoB = DateTime.Parse("16.7.1980")
            };

            // EMPLOYEE INSTANCES
            Employee employeeKrystof = new Employee
            {
                Name = "Krystof",
                Surname = "Rurcnik",
                DoB = DateTime.Parse("16.8.2004"),
                HourlyWage = 100,
                HoursWorked = 0.5f
            };

            Employee employeeDominik = new Employee
            {
                Name = "Dominik",
                Surname = "Anlauf",
                DoB = DateTime.Parse("3.1.2002"),
                HourlyWage = 175,
                HoursWorked = 35
            };

            Employee employeeRon = new Employee
            {
                Name = "Ron",
                Surname = "Studeny",
                DoB = DateTime.Parse("19.5.2003"),
                HourlyWage = 200,
                HoursWorked = 14,
                HasManagerRights = true,
                
            };

            Item apple = new Item
            {
                Name = "Apple",
                ProductType = "Grocery",
                Description = "It's an apple",
                Firm = "N/A",
                ExpirationDate = DateTime.Today.AddDays(3),
                Price = 12f
            };

            Item yogurt = new Item
            {
                Name = "Yogurt",
                ProductType = "Grocery",
                Description = "White yogurt, 2.7% fat",
                Firm = "Olma",
                ExpirationDate = DateTime.Today.AddDays(14),
                Price = 24.99f
            };

            Item bread = new Item
            {
                Name = "Bread",
                ProductType = "Grocery",
                Description = "Standard consumer grade bread",
                Firm = "Lidl",
                ExpirationDate = DateTime.Today.AddDays(20),
                Price = 53f
            };

            Item rum = new Item
            {
                Name = "Bozkov - Tuzemsky rum",
                ProductType = "Grocery",
                Description = "Cheap booze to mix with coke or whatever",
                Firm = "Bozkov",
                ExpirationDate = DateTime.Today.AddYears(15),
                Price = 125f,
                LegalAge = 18

            };

            Item toiletPaper = new Item
            {
                Name = "Toilet paper",
                ProductType = "Scott",
                Description = "A pack of 8 rolls of silky smooth toilet paper",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(20),
                Price = 220f
            };

            Item soap = new Item
            {
                Name = "Hand Soap",
                ProductType = "Sanitary",
                Description = "Hand sanitization soap for bathrooms",
                Firm = "Softsoap",
                ExpirationDate = DateTime.Today.AddYears(20),
                Price = 89.90f
            };

            Item brush = new Item
            {
                Name = "Tooth brush",
                ProductType = "Sanitary",
                Description = "A manual tooth brush",
                Firm = "Colgate",
                ExpirationDate = DateTime.Today.AddYears(2),
                Price = 49.90f
            };


            Store lidl = new Store
            {
                Name = "Lidl",
                Employees = { employeeDominik, employeeRon, employeeKrystof },
                Customers = { pepa, tonda, ondra, lukas, jonas, walt },
                ItemsAvailable = { apple, yogurt, bread, rum, toiletPaper, brush, soap }
            };



            Transaction transaction1 = new Transaction() // standard transaction
            {
                Customer = pepa,
                Cashier = employeeDominik,
                PurchasedItems = { yogurt, yogurt, bread },
            };

            Transaction transaction2 = new Transaction() // illegal purchase of alcohol
            {
                Customer = tonda,
                Cashier = employeeKrystof,
                PurchasedItems = { rum, rum },
            };

            Transaction transaction3 = new Transaction() // legal but un-verified purchase of alcohol
            {
                Customer = jonas,
                Cashier = employeeDominik,
                PurchasedItems = { rum, brush, bread },
            };

            Transaction transaction4 = new Transaction() // legal and verofied purchase of alcohol
            {
                Customer = walt,
                Cashier = employeeRon,
                PurchasedItems = { rum, yogurt, yogurt, bread, toiletPaper },
            };
           
            lidl.Transactions.Add(transaction1);
            lidl.Transactions.Add(transaction2);
            lidl.Transactions.Add(transaction3);
            lidl.Transactions.Add(transaction4);

            foreach (var transaction in GetIlllegalPurchases(lidl))
                Console.WriteLine($"Illegal: {transaction.TransactionID}");

            foreach (var transaction in GetTransactionsOverAPrice(lidl, 250))
                Console.WriteLine($"Above {250}: {transaction.TransactionID}");


        }


        static List<Transaction> GetIlllegalPurchases(Store store)
        {

            return store.Transactions
                .Where(transaction => transaction.PurchasedItems.Any(item => item.LegalAge > transaction.Customer.Age))
                .ToList();
        }

        static List<Transaction> GetTransactionsOverAPrice(Store store, float price)
        {
            return store.Transactions
                .Where(transaction => transaction.TotalPrice > price).ToList();
        }

        public static DateTime GetRandomDoB()
        {
            Random rng = new Random();
            return new DateTime();
        }
    }
}