# **Convinience Store model - documentation (EN)**
### Version:
1.0
### Field:
INFOP
### For subject:
Objektové modelování
### Author:
Ron Studený
### Contact:
XSTUR008@studenti.czu.cz

# 1 About the model
## 1.1 Realisation
The model is realised in C# Console App using net6.0 framework. Queries are implemented using LINQ and collections are represented by generic ``List<T>`` collecitons. I've chosen this environment for it's adaptibility and ease of use aswell as for my previous expirence.
## 1.2 Purpose
This model serves as an example of what an internal database/system for a convinience store could look like, and to demonstrate that an application or interface could be easily built for such a system.
## 1.3 Scope
The scope of this model is scaled back as not to be overcomplicated, it implements 5 classes which represent the Store itself, it's employees, customers and items, furthermore 5 queries have been implemented to demonstrate functionality of this model.<br> **No connection** to an actual database or application has been implemented.
# 2 Model topology
## 2.1 Class Store
This is the core class around which the entire system is built and it contains collections of all the remaining classes. Only 1 instance of this class exists within the model as per the **1.3 Scope**, the model should only represents the system for a single store, however this class is implemented in such a way, that multiple stores could be created and handled within a single system.<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Variable containing the name of the establishment, in the event that the use of this model is expanded to facilitate multiple stores, this variable could be used for identification<br>
``List<Employee> Employees`` - A collection of ``Employee`` type, contains all instances of ``Employee`` class. This collection is used extensively through out the project as will be described further into the document<br>
``List<Person> Customers`` - A collection of ``Person`` type, has multiple use cases, it represents all the people that have made a purchase, but also ones that didn't but may in the future, such feature could be used as a registration and account system in an event that the model gets expanded into an e-shop service<br>
``List<Item> ItemsAvailable`` - A collection of ``Item`` type, serves as a summary of all the products the shop offers. An important collection in any type of application or interface this model may be a part of.<br>
``List<Transaction> Transactions`` - A collection of ``Transaction`` type, it's a collection of all the transactions within the store. Another important collection as it may be used to track sales, gross income, verify how much time do employees stay at the cash register etc.<br>
## 2.2 Class Person
This class is used to represent a customer within the store that may have made a purchase. Further more, this class ``Person`` is the parent of class ``Employee`` so that an ``Employee`` may be considered a customer aswell.<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Variable containing the first name of the person used for basic identification within a potentialy large collection of other customers.<br>
``string Surname`` - Variable containing the surname of the person, same usecase as with ``Name`` variable.<br>
``DateTime DoB`` - Variable containing the date of birth of the person, used to calculate the ``Age`` and can also be used to filter for specific customers.<br>
``int Age`` - A variable containing the age of the person, It is calculated on demand based on the persons ``DoB`` and current date. Used to verify if they can buy certain products, which may be age-restricted.<br>
## 2.3 Class Employee
As mentioned above, this class is the child of class ``Person``. It represents employees that are responsible for running the establishment and are listed seperatly from customers in class ``Store``.<br> The class can be used to track the the employees work hours, the salary the've been paid, products they have sold etc.<br>
----INSTANCE VARIABLES----<br>
**ALL VARIABLES FROM CLASS ``PERSON`` ARE PRESENT IN THIS CLASS ASWELL**<br>
``Guid EmployeeId`` - A unique id variable for each employee, is used for primary identification.<br>
``bool HasManagerRights`` - An optional variable (default false) that describes wether the employee has manager rights, the use of this variable is to be decided by the store policy.<br>
``float HourlyWage`` - A variable that can be used to track how much an employee should get paid per hour of labor. An information that may proof useful in an integrated system. Used to calculate employees ``Salary``.<br>
``float HoursWorked`` - A Variable used to track how many hours has the employee clocked during the month, also used in the calculation of ``Salary``.<br>
``float Salary`` - A variable that returns the product of ``HourlyWage`` and ``HoursWorked`` variables, useful for tracking how much the employee should be compensated for their work.<br>
## 2.4 Class Item
This class represents a unique product that is for sale in the store. It's instances form a kind of catalogue of items, that are refferenced each time they are bought by a customer, instead of representing the volume of this item in stock<br>
----INSTANCE VARIABLES----<br>
``string Name`` - A variable containing the name of the product, one of the main options in sorting products is to look for its name.<br>
``string ProductType`` - Another variable useful for sorting through available items, a user may wish to select a wider selection of items with similar use, which would be done using this variable.<br>
``string Description`` - A less important variable containing a worded description of the product, could be implemented into a e-shop service if needed.<br>
``string Firm`` - A name of the firm responsible for the production of given product, useful for further sorting options.<br>
``DateTime ExpirationDate`` - An optional variable containing the expiration date provided by the producer, mostly useful for food products.<br>
``string BarCodeID`` - The barcode of the item, unique to every instance, in the model a Guid instance is created to represent each item, this can however be changed to be inline with the actual inventory of the store.<br>
``float Price`` - The price of the item, used to calculate sum price of a ``Transaction``.<br>
``int LegalAge`` - Defaulted to 0, an optional variable that can be set to whichever age the customer should be in order to purchase the given item.<br>
``bool IsExpired`` - Implemented by a function, checks wheter current date exceeds the ``ExpirationDate`` of the item and returns appropriate value.<br>

## 2.5 Class Transaction
Another core class, it represents a transaction between the store and a customer, contains all the important information, such as the cashier ``Employee`` who made the transaction, the customer ``Person``, the items that have been bought etc.<br>
----INSTANCE VARIABLES----<br>
``Employee Cashier`` - The cashier that was responsible for the finalisation of the transaction. Useful for sorting through the ``Transactions`` collection.<br>
``Person Customer`` - The customer that made the purchase, useful for determening factors such as wether the legal age of purchase for the item(s) in the transaction was satisfied.<br>
``List<Item> PurchasedItems`` - A collection of ``Item`` type, contains refferences to the individual items of ``ItemsAvailable`` collection of ``Store``, with every refference representing a purchase of an individual item of that type.<br>
``DateTime DateOfPurchase`` - Contains the date that the given instance was created on. Generated automatically using a constructor, useful for sorting, indexing.<br>
``Guid TransactionID`` - Automatically generated unique ID given to the transaction for identification.<br>
``double TotalPrice`` - Sums the ``Price`` value of each refference to an item from ``PurchasedItems`` collection, resulting in the total price paid by the customer, implemented as a getter function<.br>
# 3 Functinality
## 3.1 Queries
To test out the capabilities of the model 5 queries have been implemented together with a simple service program to visualise the result of these queries in order to demonstrate it's functionality<br>
``GetIlleGalPurchases`` - Returns a collection of ``Transaction`` type containing all the transactions that contain an ``Item`` with higher ``LegalAge`` variable then the ``Customer`` variable's ``Age`` variable<br>
``GetTransactionsOverAPrice`` - This query accepts a float representing a desired price and returns collection of ``Transaction`` containing transactions with ``TotalPrice`` variable higher then the given price<br>
``GetItemsSoldByEmployee`` - This query accepts a ``Employee`` parameter and returns a collection of type ``Item`` containing all the items that have benn in a transaction made by the given employee<br>
``GetItemsSoldByCustomer`` - Similar to the previous query, accepts a ``Person`` type parameter, and returns a collection of type ``Item`` containing all the items that have benn in a transaction containing the given parameter<br>
``GetEmployeesThatAreCustomers`` - Returns a collection of ``Employee`` type containing all those that are also contained in the ``Customers`` collection of the ``Store``<br>
