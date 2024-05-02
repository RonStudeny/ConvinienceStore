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
# Table of Contents
* 1 [About the model](#1-about-the-model)

# 1 About the model
## 1.1 Realisation
The model is realised in C# Console App using net6.0 framework. Queries are implemented using LINQ and collections are represented by generic ``List<T>`` collecitons. I've chosen this environment for it's adaptibility and ease of use aswell as for my previous expirence.
## 1.2 Purpose
This model serves as an example of what an internal database/system for a convinience store could look like, and to demonstrate that an application or interface could be easily built for such a system.
## 1.3 Scope
The scope of this model is scaled back as not to be overcomplicated, it implements 5 classes which represent the Store itself, it's employees, customers and items, furthermore 5 queries have been implemented to demonstrate functionality of this model.<br> **No connection** to an actual database or application has been implemented.
# 2 Model topology
## 2.1 Class Store
This is the core class around which the entire system is built and it contains collections of all the remaining classes. Only 1 instance of this class exists within the model as per the [Scope](#13-scope), the model should only represents the system for a single store, however this class is implemented in such a way, that multiple stores could be created and handled within a single system.<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Variable containing the name of the establishment, in the event that the use of this model is expanded to facilitate multiple stores, this variable could be used for identification<br>
``List<Employee> Employees`` - A collection of ``Employee`` type, contains all instances of ``Employee`` class. This collection is used extensively through out the project as will be described further into the document<br>
``List<Person> Customers`` - A collection of ``Person`` type, has multiple use cases, it represents all the people that have made a purchase, but also ones that didn't but may in the future, such feature could be used as a registration and account system in an event that the model gets expanded into an e-shop service<br>
``List<Item> ItemsAvailable`` - A collection of ``Item`` type, serves as a summary of all the products the shop offers. An important collection in any type of application or interface this model may be a part of.<br>
``List<Transaction> Transactions`` - A collection of ``Transaction`` type, it's a collection of all the transactions within the store. Another important collection as it may be used to track sales, gross income, verify how much time do employees stay at the cash register etc.<br>
## 2.2 Class Person
This class is used to represent a customer within the store that may have made a purchase. Further more, this class ``Person`` is the parent of class ``Employee`` so that an ``Employee`` may be considered a customer aswell.<br>
----INSTANCE VARIABLES----<br>
``string Name`` - Variable containing the first name of the person used for basic identification within a potentialy large collection of other customers<br>
``string Surname`` - Variable containing the surname of the person, same usecase as with ``Name`` variable<br>
``DateTime DoB`` - Variable containing the date of birth of the person, used to calculate the ``Age`` and can also be used to filter for specific customers<br>
``int Age`` - A variable containing the age of the person, It is calculated on demand based on the persons ``DoB`` and current date. Used to verify if they can buy certain products, which may be age-restricted<br>
## 2.3 Class Employee
As mentioned above, this class is the child of class ``Person``. It represents employees that are responsible for running the establishment and are listed seperatly from customers in class ``Store``.<br> The class can be used to track the the employees work hours, the salary the've been paid, products they have sold etc.<br>
----INSTANCE VARIABLES----<br>
**ALL VARIABLES FROM CLASS ``PERSON`` ARE PRESENT IN THIS CLASS ASWELL**<br>
``Guid EmployeeId`` - A unique id variable for each employee, is used for primary identification.<br>
``bool HasManagerRights`` - An optional variable (default false) that describes wether the employee has manager rights, the use of this variable is to be decided by the store policy<br>
``float HourlyWage`` - A variable that can be used to track how much an employee should get paid per hour of labor. An information that may proof useful in an integrated system. Used to calculate employees ``Salary``<br>
``float HoursWorked`` - A Variable used to track how many hours has the employee clocked during the month, also used in the calculation of ``Salary``<br>
``float Salary`` - A variable that returns the product of ``HourlyWage`` and ``HoursWorked`` variables, useful for tracking how much the employee should be compensated for their work<br>
## 2.4 Class Item
blah blah blah<br>
----INSTANCE VARIABLES----<br>
## 2.5 Class Transaction
blah blah blah<br>
----INSTANCE VARIABLES----<br>
# 3 Model functionality
