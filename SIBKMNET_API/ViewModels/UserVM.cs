using Newtonsoft.Json;
using SIBKMNET_API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.ViewModels
{
    public class UserVM
    {
        [ForeignKey("Employee")]
        public int Id { get; set; }
        public string Password { get; set; }

        //[JsonConstructor]
        //public UserVM(ViewModels.EmployeeVM employee)
        //{

        //}
    }
}
