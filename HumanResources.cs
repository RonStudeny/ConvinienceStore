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
        public int Age { get; set; } // implement by func.
       
    }

    public class Employee : Person
    {
        public Guid EmployeeId { get; private set; }
        public bool HasManagerRights { get; set; }
        public float HourlyWage { get; set; }
        public float HoursWorked { get; set; }
        public float Salary { get; set; } // calculate
        
        
    }


 


}
