using Microsoft.EntityFrameworkCore;
using SIBKMNETMvc_WebApp.Context;
using SIBKMNETMvc_WebApp.Handler;
using SIBKMNETMvc_WebApp.Models;
using SIBKMNETMvc_WebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIBKMNETMvc_WebApp.Repositories.Data
{
    public class AccountRepository
    {
        MyContext myContext;

        public AccountRepository(MyContext myContext)
        {
            this.myContext = myContext;
        }

        public ResponseLogin Login(Login login)
        {
            var data = myContext.UserRoles
                .Include(x => x.Role)
                .Include(x => x.User)
                .Include(x => x.User.Employee)
                .FirstOrDefault(x => x.User.Employee.Email.Equals(login.Email));
            //&& x.User.Password.Equals(login.Password));

            var verify = Hashing.ValidatePassword(login.Password, data.User.Password);

            //if (data != null)
            if(verify)
            {
                var response = new ResponseLogin()
                {
                    Id = data.User.Employee.Id,
                    FullName = data.User.Employee.FullName,
                    Email = data.User.Employee.Email,
                    Role = data.Role.Name
                };
                return response;
            }
            return null;
        }

        //Register
        public int Register(Register register)
        {
            //mapping data ke Employee table
            Employee employee = new Employee()
            {
                FullName = register.FullName,
                Email = register.Email
            };

            myContext.Employees.Add(employee);

            //commit insert to Employee
            var resultEmployee = myContext.SaveChanges();
            if (resultEmployee > 0)
            {
                int id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(register.Email)).Id;
                //var Employee = myContext.Employees.SingleOrDefault(x => x.Email.Equals(register.Email));
                User user = new User()
                {
                    Id = id,
                    //Employee = Employee,
                    Password = Hashing.HashPassword(register.Password)
                };
                myContext.Users.Add(user);
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    UserRole userRole = new UserRole()
                    {
                        UserId = id,
                        RoleId = register.RoleId
                    };
                    myContext.UserRoles.Add(userRole);
                    var resultUserRole = myContext.SaveChanges();
                    if (resultUserRole > 0)
                        return resultUserRole;
                    myContext.Users.Remove(user);
                    myContext.SaveChanges();
                    myContext.Employees.Remove(employee);
                    myContext.SaveChanges();
                    return 0;
                }
                myContext.Employees.Remove(employee);
                myContext.SaveChanges();
                return 0;
            }
            return 0;
        }
        //Forgot Password -> sebelum login, verify email nanti password diganti sesuai yg didapatkan, ganti secara paksa, mis default password metrodata diganti tapi dihash
        public int ForgotPassword (ForgotPass forgotPass)
        {
            //search data employee pada db
            Employee employee = new Employee()
            {
                Email = forgotPass.Email
            };

            myContext.Employees.Find(employee);

            var resultEmployee = myContext.SaveChanges();
            if (resultEmployee > 0)
            {
                int id = myContext.Employees.SingleOrDefault(x => x.Email.Equals(forgotPass.Email)).Id;
                User user = new User()
                {
                    Id = id,
                    Password = Hashing.HashPassword(forgotPass.DefaultPassword)
                };
                myContext.Users.Find(user);
                var resultUser = myContext.SaveChanges();
                if (resultUser > 0)
                {
                    UserRole userRole = new UserRole()
                    {
                        UserId = id,
                        RoleId = forgotPass.RoleId
                    };
                    myContext.UserRoles.Find(userRole);
                    var resultUserRole = myContext.SaveChanges();
                    if (resultUserRole > 0)
                        return resultUserRole;
                    return 0;
                }
                return 0;
            }
            return 0;
        }
        //Change Password -> sesudah login, verify email dan verify password, input email, password lama dan password baru terus retype password baru (opt)
    }
}
