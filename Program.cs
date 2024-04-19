using Store;
namespace Store
{
    static class Script
    {
        public static void Main()
        {
            // PERSON TEMPLATE
            Person person1 = new Person();
            person1.Name = "";
            person1.Surname = "";
            person1.DoB = GetRandomDoB();

            // EMPLOYEE TEMPLATE
            Employee employee1 = new Employee();
            employee1.Name = "";
            employee1.Surname = "";
            employee1.DoB = GetRandomDoB();
            employee1.HourlyWage = 0;
            employee1.HoursWorked = 0;

            // ITEM TEMPLATE
            Item item1 = new Item();
            item1.Name = "";
            item1.ProductType = "";
            item1.Description = "";
            item1.Firm = "";
            item1.ExpirationDate = DateTime.Now;
            item1.Price = 0f;

            // STORE TEMPLATE
            Store store = new Store();
            store.Name = "";
            store.Employees = new List<Employee>();
            store.Customers = new List<Person>();
            store.ItemsAvailable = new List<Item>();



            // TRANSACTION TEMPLATE
            Transaction transaction = new Transaction();
            transaction.InStore = store;
            transaction.Customer = transaction.InStore.Customers[0];
            transaction.PurchasedItems = new Item[] { transaction.InStore.ItemsAvailable[0]};
            transaction.DateOfPurchase = DateTime.Now;


            // CUSTOMER INSTANCES
            Person pepa = new Person();
            pepa.Name = "Pepa";
            pepa.Surname = "Zakaznicky";
            pepa.DoB = GetRandomDoB();

            Person tonda = new Person();
            tonda.Name = "Tonda";
            tonda.Surname = "Zapotocky";
            tonda.DoB = GetRandomDoB();

            Person ondra = new Person();
            ondra.Name = "Ondra";
            ondra.Surname = "Vopršálek";
            ondra.DoB = GetRandomDoB();

            Person lukas = new Person();
            lukas.Name = "Lukas";
            lukas.Surname = "Sustr";
            lukas.DoB = GetRandomDoB();

            Person jonas = new Person();
            jonas.Name = "Jonas";
            jonas.Surname = "Ruzovi";
            jonas.DoB = GetRandomDoB();

            Person walt = new Person();
            walt.Name = "Walter";
            walt.Surname = "Heisenberg";
            walt.DoB = GetRandomDoB();

            // EMPLOYEE INSTANCES

            Employee employeeKrystof = new Employee();
            employeeKrystof.Name = "Krystof";
            employeeKrystof.Surname = "Rurcnik";
            employeeKrystof.DoB = GetRandomDoB();
            employeeKrystof.HourlyWage = 100;
            employeeKrystof.HoursWorked = 0.5f;

            Employee employeeDominik = new Employee();
            employeeDominik.Name = "Dominik";
            employeeDominik.Surname = "Anlauf";
            employeeDominik.DoB = GetRandomDoB();
            employeeDominik.HourlyWage = 175;
            employeeDominik.HoursWorked = 35;

            Employee employeeRon = new Employee();
            employeeRon.Name = "Ron";
            employeeRon.Surname = "Studeny";
            employeeRon.DoB = GetRandomDoB();
            employeeRon.HourlyWage = 200;
            employeeRon.HoursWorked = 14;

            // FOOD ITEM INSTANCES

            Item apple = new Item();
            apple.Name = "Apple";
            apple.ProductType = "Food";
            apple.Description = "It's an apple";
            apple.Firm = "N/A";
            apple.ExpirationDate = DateTime.Today.AddDays(3);
            apple.Price = 12f;

            Item yogurt = new Item();
            yogurt.Name = "Yogurt";
            yogurt.ProductType = "Food";
            yogurt.Description = "White yogurt, 2.7% fat";
            yogurt.Firm = "Olma";
            yogurt.ExpirationDate = DateTime.Today.AddDays(14);
            yogurt.Price = 24.99f;

            Item bread = new Item();
            bread.Name = "Bread";
            bread.ProductType = "Food";
            bread.Description = "Standard consumer grade bread";
            bread.Firm = "Lidl";
            bread.ExpirationDate = DateTime.Today.AddDays(20);
            bread.Price = 53f;


        }

        public static DateTime GetRandomDoB()
        {
            Random rng = new Random();
            return new DateTime();
        }
    }
}