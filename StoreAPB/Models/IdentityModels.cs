using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace StoreAPB.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole() : base() { }

        public ApplicationRole(string name) : base(name) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("StoreAPBIdentity")//, throwIfV1Schema: false
        {
            Database.SetInitializer<ApplicationDbContext>(new IdentityDbInit());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public class IdentityDbInit : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            PerformInitialSetup(context);
            base.Seed(context);
        }

        public void PerformInitialSetup(ApplicationDbContext context)
        {
            ApplicationUserManager userMgr = new ApplicationUserManager(new UserStore<ApplicationUser>(context));
            ApplicationRoleManager roleMgr = new ApplicationRoleManager(new RoleStore<ApplicationRole>(context));
            
            string roleAdmin = "Administrators";
           
            string userName = "admin@example.com";
            string password = "MySecret123*";
            string email = "admin@example.com";
            
            if (!roleMgr.RoleExists(roleAdmin))
            {
                roleMgr.Create(new ApplicationRole(roleAdmin));
            }           

            ApplicationUser user = userMgr.FindByName(userName);
            if (user == null)
            {//, City = Cities.CHICAGO, Country = Countries.USA
                user = new ApplicationUser { UserName = userName, Email = email };
                userMgr.Create(user,password);
                user = userMgr.FindByName(userName);
            }

            if (!userMgr.IsInRole(user.Id, roleAdmin))
            {
                userMgr.AddToRole(user.Id, roleAdmin);
            }
        }

    }
}