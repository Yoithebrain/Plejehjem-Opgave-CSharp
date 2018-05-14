using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Plejehjem_Opgave_CSharp.Models;


namespace Plejehjem_Opgave_CSharp.Models
{
    public class Roles
    {
        public void CreateRolesAndUsers()
        {
            MyDbContext db = new MyDbContext();

            /*var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
            var userManager = new userManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

            if (!roleManager.RoleExist("Admin"))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admin";
                roleManager.create(role);

            }*/



        }
    }
   
}