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
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration, ModelBuilder modelBuilder) : base(options)
        {
            _configuration = configuration;

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuring Employee entity
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.FName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PhoneNumper).IsRequired().HasMaxLength(20);
                entity.Property(e => e.Salary).IsRequired();
                entity.Property(e => e.HireDate).IsRequired();
                entity.HasMany(e => e.Transaction).WithOne(t => t.Employee).HasForeignKey(t => t.EmployeeId);
            });

            modelBuilder.Entity<EmployeeTransaction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Transaction).IsRequired();
                entity.Property(e => e.TransactionDate).IsRequired();
                entity.HasOne(t => t.Employee)
                      .WithMany(e => e.Transaction)
                      .HasForeignKey(t => t.EmployeeId);
            });
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTransaction> EmployeeTransaction { get; set; }
        
    }
}
