using Microsoft.EntityFrameworkCore;

namespace Financial_Almohtasep.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasQueryFilter(e => !e.IsDeleted);
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTransaction> EmployeeTransaction { get; set; }

    }
}
