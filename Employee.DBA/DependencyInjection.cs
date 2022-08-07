using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Employee.DBA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Employee.DBA.Unit_Of_Work;

namespace Employee.DBA
{
    public static class DependencyInjection
    {
        public static void AddMySqlDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            MySqlServerVersion version = new MySqlServerVersion(new Version(8,0,29));
            services.AddDbContext<ApplicationContext>(options => options.UseMySql(configuration.GetConnectionString("DefaultUrl"),version));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            
        }
        public static void AddMySqlIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser,IdentityRole>().AddUserManager<UserManager<IdentityUser>>().AddSignInManager<SignInManager<IdentityUser>>().AddRoleManager<RoleManager<IdentityRole>>().AddEntityFrameworkStores<ApplicationContext>();
        }
    }
}
