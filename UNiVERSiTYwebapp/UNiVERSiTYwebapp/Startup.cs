using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using UNiVERSiTYwebapp.Context;
using UNiVERSiTYwebapp.Models;

[assembly: OwinStartupAttribute(typeof(UNiVERSiTYwebapp.Startup))]
namespace UNiVERSiTYwebapp
{
    public partial class Startup
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }

        // In this method we will create default User roles and Administrator user for login   
        private void CreateRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = new UserManager<User>(new UserStore<User>(context));

            // In Startup, creating first Super/System Administrator (SA) Role and 
            // creating a default Super/System Administrator User 
            if (!roleManager.RoleExists("SA"))
            {
                // first we create Administrator role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "SA";
                roleManager.Create(role);

                //Here we create a Administrator super user who will maintain the website
                var user = new User();
                user.UserName = "Administrator";
                user.Email = "administrator@ums.com";

                string userPWD = "@cc3$5DEn1ed";
                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Administrator   
                if (chkUser.Succeeded)
                    UserManager.AddToRole(user.Id, "SA");
            }
                // In Startup, creating first Administrator Role and creating a default Administrator User    
            if (!roleManager.RoleExists("Administrator"))
            {
                // first we create Administrator role
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Administrator";
                roleManager.Create(role);

                //Here we create a Administrator (robin) who will maintain the website
                var user1 = new User();
                user1.UserName = "robin";
                user1.Email = "robin@ums.com";

                string userPWD1 = "12345678";
                var chkUser1 = UserManager.Create(user1, userPWD1);

                //Add default User to Role Administrator   
                if (chkUser1.Succeeded)
                    UserManager.AddToRole(user1.Id, "Administrator");

                //Here we create a Administrator (noman) who will maintain the website
                var user2 = new User();
                user2.UserName = "noman";
                user2.Email = "noman@ums.com";

                string userPWD2 = "12345678";
                var chkUser2 = UserManager.Create(user2, userPWD2);

                //Add default User to Role Administrator   
                if (chkUser2.Succeeded)
                    UserManager.AddToRole(user2.Id, "Administrator");

                //Here we create a Administrator (tamanna) who will maintain the website
                var user3 = new User();
                user3.UserName = "tamanna";
                user3.Email = "tamanna@ums.com";

                string userPWD3 = "12345678";
                var chkUser3 = UserManager.Create(user3, userPWD3);

                //Add default User to Role Administrator   
                if (chkUser3.Succeeded)
                    UserManager.AddToRole(user3.Id, "Administrator");

                //Here we create a Administrator (faisal) who will maintain the website
                var user4 = new User();
                user4.UserName = "faisal";
                user4.Email = "faisal@ums.com";

                string userPWD4 = "12345678";
                var chkUser4 = UserManager.Create(user4, userPWD4);

                //Add default User to Role Administrator   
                if (chkUser4.Succeeded)
                    UserManager.AddToRole(user4.Id, "Administrator");

                //Here we create a Administrator super user who will maintain the website
                var user5 = new User();
                user5.UserName = "nishad";
                user5.Email = "nishad@ums.com";

                string userPWD5 = "12345678";
                var chkUser5 = UserManager.Create(user5, userPWD5);

                //Add default User to Role Administrator   
                if (chkUser5.Succeeded)
                    UserManager.AddToRole(user5.Id, "Administrator");

                //Here we create a Administrator (arifulalam) who will maintain the website
                var user6 = new User();
                user6.UserName = "arifulalam";
                user6.Email = "arifulalam@ums.com";

                string userPWD6 = "12345678";
                var chkUser6 = UserManager.Create(user6, userPWD6);

                //Add default User to Role Administrator   
                if (chkUser6.Succeeded)
                    UserManager.AddToRole(user6.Id, "Administrator");
            }

            //Creating Manager role    
            if (!roleManager.RoleExists("Manager")){
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Manager";
                roleManager.Create(role);
            }

            // Creating Employee role
            if (!roleManager.RoleExists("Employee")){
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Employee";
                roleManager.Create(role);
            }

            //Creating Faculty role    
            if (!roleManager.RoleExists("Faculty")){
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Faculty";
                roleManager.Create(role);
            }

            // Creating Student role
            if (!roleManager.RoleExists("Student")){
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Student";
                roleManager.Create(role);
            }

            //Creating Parent role    
            if (!roleManager.RoleExists("Parent")){
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Parent";
                roleManager.Create(role);
            }
        }
    }
}
