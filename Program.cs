using Store;
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
                DoB = GetRandomDoB()
            };

            Person tonda = new Person
            {
                Name = "Tonda",
                Surname = "Zapotocky",
                DoB = GetRandomDoB()
            };

            Person ondra = new Person
            {
                Name = "Ondra",
                Surname = "Vopršálek",
                DoB = GetRandomDoB()
            };

            Person lukas = new Person
            {
                Name = "Lukas",
                Surname = "Sustr",
                DoB = GetRandomDoB()
            };

            Person jonas = new Person
            {
                Name = "Jonas",
                Surname = "Ruzovi",
                DoB = GetRandomDoB()
            };

            Person walt = new Person
            {
                Name = "Walter",
                Surname = "Heisenberg",
                DoB = GetRandomDoB()
            };

            // EMPLOYEE INSTANCES
            Employee employeeKrystof = new Employee
            {
                Name = "Krystof",
                Surname = "Rurcnik",
                DoB = GetRandomDoB(),
                HourlyWage = 100,
                HoursWorked = 0.5f
            };

            Employee employeeDominik = new Employee
            {
                Name = "Dominik",
                Surname = "Anlauf",
                DoB = GetRandomDoB(),
                HourlyWage = 175,
                HoursWorked = 35
            };

            Employee employeeRon = new Employee
            {
                Name = "Ron",
                Surname = "Studeny",
                DoB = GetRandomDoB(),
                HourlyWage = 200,
                HoursWorked = 14
            };

            // FOOD ITEM INSTANCES
            Item apple = new Item
            {
                Name = "Apple",
                ProductType = "Food",
                Description = "It's an apple",
                Firm = "N/A",
                ExpirationDate = DateTime.Today.AddDays(3),
                Price = 12f
            };

            Item yogurt = new Item
            {
                Name = "Yogurt",
                ProductType = "Food",
                Description = "White yogurt, 2.7% fat",
                Firm = "Olma",
                ExpirationDate = DateTime.Today.AddDays(14),
                Price = 24.99f
            };

            Item bread = new Item
            {
                Name = "Bread",
                ProductType = "Food",
                Description = "Standard consumer grade bread",
                Firm = "Lidl",
                ExpirationDate = DateTime.Today.AddDays(20),
                Price = 53f
            };

            // GROCERY ITEM INSTANCES
            Item toiletPaper = new Item
            {
                Name = "Toilet paper",
                ProductType = "Sanitary",
                Description = "A pack of 6 rolls of silky smooth toilet paper",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(20),
                Price = 220f
            };

            Item soap = new Item
            {
                Name = "Hand Soap",
                ProductType = "Sanitary",
                Description = "Hand sanitization soap for bathrooms",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(20),
                Price = 89.90f
            };

            Item brush = new Item
            {
                Name = "Tooth brush",
                ProductType = "Sanitary",
                Description = "A manual tooth brush",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(2),
                Price = 49.90f
            };

            // TOOL ITEM INSTANCES
            Item drill = new Item
            {
                Name = "Hand Drill",
                ProductType = "Tool",
                Description = "A basic battery-powered hand drill",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(2),
                Price = 3200f
            };

            Item wrench = new Item
            {
                Name = "Wrench",
                ProductType = "Tool",
                Description = "Standard metalic wrench",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(5),
                Price = 850f
            };

            Item shovel = new Item
            {
                Name = "Gardening Shovel",
                ProductType = "Tool",
                Description = "A shovel fit for gardening work",
                Firm = "D&M",
                ExpirationDate = DateTime.Today.AddYears(2),
                Price = 450f
            };

            // STORE INSTANCES
            Store lidl = new Store
            {
                Name = "Lidl",
                Employees = new List<Employee> { employeeDominik },
                Customers = new List<Person> { pepa, tonda },
                ItemsAvailable = new List<Item> { apple, yogurt, bread }
            };

            Store dm = new Store
            {
                Name = "D&M",
                Employees = new List<Employee> { employeeRon },
                Customers = new List<Person> { ondra, lukas },
                ItemsAvailable = new List<Item> { toiletPaper, brush, soap }
            };

            Store hornbach = new Store
            {
                Name = "Hornbach",
                Employees = new List<Employee> { employeeDominik },
                Customers = new List<Person> { pepa, tonda },
                ItemsAvailable = new List<Item> { drill, shovel, wrench }
            };

            Transaction transaction1 = new Transaction()
            {
                InStore = lidl,
                Customer = lidl.Customers[0],
                Cashier = lidl.Employees[0],
                PurchasedItems = { lidl.ItemsAvailable[0], lidl.ItemsAvailable[0], lidl.ItemsAvailable[2] },
                DateOfPurchase = DateTime.Now
            };



        }

        public static DateTime GetRandomDoB()
        {
            Random rng = new Random();
            return new DateTime();
        }
    }
}