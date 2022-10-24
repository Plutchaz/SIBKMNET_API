using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNETMvc_WebApp.ViewModels
{
    public class ForgotPass
    {
        public string Email { get; set; }
        public string DefaultPassword { get; set; } = "thename";

        public int RoleId { get; set; }
    }
}
