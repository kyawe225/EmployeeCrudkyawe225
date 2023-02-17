using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Employee.DBA.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Employee.DBA.Unit_Of_Work;

namespace Employee.DBA
{
    public static class DependencyInjection
    {
        public static void AddMySqlDbContext(this IServiceCollection services,IConfiguration configuration)
        {
            /*ySqlServerVersion version = new MySqlServerVersion(new Version(8,0,29));*/
            services.AddDbContext<ApplicationContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultUrl")));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            
        }
        public static void AddMySqlIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser,IdentityRole>().AddUserManager<UserManager<IdentityUser>>().AddSignInManager<SignInManager<IdentityUser>>().AddRoleManager<RoleManager<IdentityRole>>().AddEntityFrameworkStores<ApplicationContext>();
        }
    }
}
