using Microsoft.EntityFrameworkCore;
using Microsoft.SqlServer.Management.Smo;
using User.Models;

namespace User.Data
{
    public class EmployeeLoginDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public EmployeeLoginDbContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("logins"));
        }
        public DbSet<Register> EmployeeLogins { get; set; }
    }
}