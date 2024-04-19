using Store;
namespace Store
{
    static class Script
    {
        public static void Main()
        {
            // PERSON TEMPLATE
            Person person = new Person();
            person.Name = "";
            person.Surname = "";
            person.DoB = GetRandomDoB();

            // EMPLOYEE TEMPLATE
            Employee employee = new Employee();
            employee.Name = "";
            employee.Surname = "";
            employee.DoB = GetRandomDoB();
            employee.HourlyWage = 0;
            employee.HoursWorked = 0;


            // STORE TEMPLATE
            Store store = new Store();
            store.Name = "";
            store.Employees = new List<Employee>();
            store.Customers = new List<Person>();
            store.ItemsAvailable = new List<Item>();

            // ITEM TEMPLATE
            Item item = new Item();
            item.Name = "";
            item.Description = "";
            item.Firm = "";
            item.ExpirationDate = DateTime.Now;
            item.Price = 0f;


            // TRANSACTION TEMPLATE
            Transaction transaction = new Transaction();
            transaction.InStore = store;
            transaction.Customer = transaction.InStore.Customers[0];
            transaction.PurchasedItems = new Item[] { transaction.InStore.ItemsAvailable[0]};
            transaction.DateOfPurchase = DateTime.Now;
            


            



        }

        public static DateTime GetRandomDoB()
        {
            Random rng = new Random();
            return new DateTime();
        }
    }
}