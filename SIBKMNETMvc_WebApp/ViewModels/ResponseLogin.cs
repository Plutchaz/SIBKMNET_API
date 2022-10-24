using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNETMvc_WebApp.ViewModels
{
    public class ResponseLogin
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        //kalau rolenya ada dua pake List<Role> Roles
    }
}
