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
            Store store1 = new Store();
            store1.Name = "";
            store1.Employees = new List<Employee>();
            store1.Customers = new List<Person>();
            store1.ItemsAvailable = new List<Item>();



            // TRANSACTION TEMPLATE
            Transaction transaction = new Transaction();
            transaction.InStore = store1;
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

            // GROCCERY ITEM INSTANCES

            Item toiletPaper = new Item();
            toiletPaper.Name = "Toilet paper";
            toiletPaper.ProductType = "Sanitary";
            toiletPaper.Description = "A pack of 6 rolls of silky smooth toilet paper";
            toiletPaper.Firm = "D&M";
            toiletPaper.ExpirationDate = DateTime.Today.AddYears(20);
            toiletPaper.Price = 220f;


            Item soap = new Item();
            soap.Name = "Hand Soap";
            soap.ProductType = "Sanitary";
            soap.Description = "Hand sanitization soap for bathrooms";
            soap.Firm = "D&M";
            soap.ExpirationDate = DateTime.Today.AddYears(20);
            soap.Price = 89.90f;

            Item brush = new Item();
            brush.Name = "Tooth brush";
            brush.ProductType = "Sanitary";
            brush.Description = "A manual tooth brush";
            brush.Firm = "D&M";
            brush.ExpirationDate = DateTime.Today.AddYears(2);
            brush.Price = 49.90f;

            // TOOL ITEM INSTANCES

            Item drill = new Item();
            drill.Name = "Hand Drill";
            drill.ProductType = "Tool";
            drill.Description = "A basic battery-powered hand drill";
            drill.Firm = "D&M";
            drill.ExpirationDate = DateTime.Today.AddYears(2);
            drill.Price = 3200f;

            Item wrench = new Item();
            wrench.Name = "Wrench";
            wrench.ProductType = "Tool";
            wrench.Description = "Standard adjustable wrench";
            wrench.Firm = "D&M";
            wrench.ExpirationDate = DateTime.Today.AddYears(5);
            wrench.Price = 850f;

            Item shovel = new Item();
            shovel.Name = "Garedening Shovel";
            shovel.ProductType = "Tool";
            shovel.Description = "A shovel fit for gardening work";
            shovel.Firm = "D&M";
            shovel.ExpirationDate = DateTime.Today.AddYears(2);
            shovel.Price = 450f;

            // STORE INSTANCES
            Store lidl = new Store();
            lidl.Name = "Lidl";
            lidl.Employees = new List<Employee> { employeeDominik };
            lidl.Customers = new List<Person>() { pepa, tonda };
            lidl.ItemsAvailable = new List<Item>() { apple, yogurt, bread };

            Store dm = new Store();
            dm.Name = "D&M";
            dm.Employees = new List<Employee> { employeeRon };
            dm.Customers = new List<Person>() { ondra, lukas };
            dm.ItemsAvailable = new List<Item>() { toiletPaper, brush, soap };

            Store hornbach = new Store();
            hornbach.Name = "Hornbach";
            hornbach.Employees = new List<Employee> { employeeDominik };
            hornbach.Customers = new List<Person>() { pepa, tonda };
            hornbach.ItemsAvailable = new List<Item>() { apple, yogurt, bread };



        }

        public static DateTime GetRandomDoB()
        {
            Random rng = new Random();
            return new DateTime();
        }
    }
}