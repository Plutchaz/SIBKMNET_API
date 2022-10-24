using SIBKMNET_API.Context;
using SIBKMNET_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Repositories.Data
{
    public class EmployeeRepository : GeneralRepository<Employee>
    {
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
