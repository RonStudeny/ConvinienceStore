using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store
{
    public class Person
    {
        public Person()
        {
            
        }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DoB { get; set; }
        public int Age
        {
            get
            {
                int res = DateTime.Today.Year - DoB.Year;
                if (DoB.Date > DateTime.Today.AddYears(-res)) res--; // substract a year if they hadn't have birthday yet
                return res;
            }
        }
       
    }

    public class Employee : Person
    {
        public Employee() :base()
        {
            HasManagerRights = false;
        }
        public Guid EmployeeId { get; private set; }
        public bool HasManagerRights { get; set; }
        public float HourlyWage { get; set; }
        public float HoursWorked { get; set; }
        public float Salary
        {
            get
            {
                return HoursWorked * HourlyWage;
            }
        } 
        
        
    }


 


}
