using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Models
{
    public class Employee
    {
        public Employee(ViewModels.EmployeeVM employee)
        {
            this.Id = employee.Id;
            this.FullName = employee.FullName;
            this.Email = employee.Email;
        }

        public Employee()
        {

        }
        [Key]
        public int Id { get; private set; }
        public string FullName { get; private set; }
        public string Email { get; private set; }
    }
}
