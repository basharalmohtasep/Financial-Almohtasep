using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Data
{
    public class ApplicationDbContext: DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;

        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, ModelBuilder modelBuilder) : base(options)
        {
            _configuration = configuration;
           
        }
        public DbSet<EmployeeTransaction> EmployeeTransaction { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}
