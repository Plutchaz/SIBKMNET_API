using SIBKMNET_API.Context;
using SIBKMNET_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNET_API.Repositories.Data
{
    public class UserRepository : GeneralRepository<User>
    {
        public UserRepository(MyContext myContext) : base(myContext)
        {

        }
    }
}
