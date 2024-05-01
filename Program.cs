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
            Employee employeePetr = new Employee
            {
                Name = "Petr",
                Surname = "Holy",
                DoB = DateTime.Parse("28.9.1999"),
                HourlyWage = 155,
                HoursWorked = 40
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
                Employees = { employeeDominik, employeeRon, employeeKrystof, employeePetr },
                Customers = { pepa, tonda, ondra, lukas, jonas, walt, employeePetr },
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



            #region QUERY TESTING PROGRAM
            bool loop = true;
            while (loop)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the store database, select an action:");
                Console.WriteLine("1. Print out the whole store");
                Console.WriteLine("2. Query menu");
                Console.WriteLine("3. Quit");
                if (int.TryParse(Console.ReadLine(), out int action))
                {
                    switch (action)
                    {
                        case 1:
                            Console.WriteLine(lidl.ToString());
                            Console.ReadLine();
                            break;
                        case 2:
                            bool chooseQuery = true;
                            while (chooseQuery)
                            {
                                Console.Clear();
                                Console.WriteLine("Choose a Query:");
                                Console.WriteLine("1. Query illegal age-restricted purchases");
                                Console.WriteLine("2. Query transactions over a given price");
                                Console.WriteLine("3. Get items sold by a specific employee");
                                Console.WriteLine("4. Get items bought by a specific customer");
                                Console.WriteLine("5. Get employees that are also customers");
                                if (int.TryParse(Console.ReadLine(), out int query))
                                {
                                    if (query == 1)
                                    {
                                        PrintCollection(GetIlllegalPurchases(lidl));
                                        chooseQuery = false;
                                    } // Illegal purchases
                                    if (query == 2)
                                    {
                                        Console.WriteLine("Please enter the treshold price");
                                        if (int.TryParse(Console.ReadLine(), out int price))
                                        {
                                            PrintCollection(GetTransactionsOverAPrice(lidl, price));
                                            chooseQuery = false;
                                        }                                            
                                        else Console.WriteLine("Invalid input, enter a valid ammount");
                                    } // Set price transactions
                                    if (query == 3)
                                    {
                                        Console.WriteLine("Choose the employee");
                                        for (int i = 0; i < lidl.Employees.Count; i++)
                                            Console.WriteLine((i + 1) + " " + lidl.Employees[i].Name);
                                        if (int.TryParse(Console.ReadLine(), out int employeeNum) && employeeNum-1 >= 0 && employeeNum-1 < lidl.Employees.Count)
                                        {
                                            PrintCollection(GetItemsSoldByEmployee(lidl, lidl.Employees[employeeNum-1]));
                                            chooseQuery = false;
                                        }
                                        else Console.WriteLine("Invalid input, enter a corresponding employee number");
                                    } // Items sold by employee
                                    if (query == 4)
                                    {
                                        Console.WriteLine("Choose the customer");
                                        for (int i = 0; i < lidl.Customers.Count; i++)
                                            Console.WriteLine((i + 1) + " " + lidl.Customers[i].Name);
                                        if (int.TryParse(Console.ReadLine(), out int customerNum) && customerNum-1 >= 0 && customerNum-1 < lidl.Customers.Count)
                                        {
                                            PrintCollection(GetItemsBoughtByCustomer(lidl, lidl.Customers[customerNum-1]));
                                            chooseQuery = false;
                                        }
                                        else Console.WriteLine("Invalid input, enter a corresponding customer number");
                                    } // Items bought by customer
                                    if (query == 5) // Employees that are also customers
                                        PrintCollection(GetEmployeesThatAreCustomers(lidl));
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("Invalid input, please write a corresponding number");
                                    Console.ReadLine();
                                }
                            }
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                    }

                }
                else Console.WriteLine("Invalid input, please type a corresponding number");

            }

            #endregion


        }

        static void PrintCollection<T>(List<T> list)
        {
            foreach (var item in list)
            {
                Console.WriteLine(item.ToString());
            }
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
                .Where(transaction => transaction.TotalPrice > price)
                .ToList();
        }


        static List<Item> GetItemsSoldByEmployee(Store store, Employee employee)
        {
            return store.Transactions
                        .Where(transaction => transaction.Cashier == employee)
                        .SelectMany(transaction => transaction.PurchasedItems)
                        .ToList();
        }

        static List<Item> GetItemsBoughtByCustomer(Store store, Person customer)
        {
            return store.Transactions
                        .Where(transaction => transaction.Customer == customer)
                        .SelectMany(transaction => transaction.PurchasedItems)
                        .ToList();
        }

        static List<Employee> GetEmployeesThatAreCustomers(Store store)
        {
            return store.Employees
                        .Where(employee => store.Customers.Contains(employee))
                        .ToList();
        }





        public static DateTime GetRandomDoB()
        {
            Random rng = new Random();
            return new DateTime();
        }
    }
}