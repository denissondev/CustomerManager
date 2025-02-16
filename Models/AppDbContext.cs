namespace SaipherCustomerManager
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                // Criei um GUID e um Senha fixa (Bcrypt para "admin123") para evitar problemas de migração (Migrations mapeia mudanças e a cada execução o hash mudaria se usasse BCrypt.HashPassword() causando erro.)
                Id = new Guid("d3b4f5e6-7a8b-4c9d-8e1f-2a3b4c5d6e7f"), 
                Name = "Admin",
                Email = "admin@example.com",
                Password = "$2a$11$/sdS9UmL2aRP/WdIL5Pc1ehADLsMH00GCxOZG408BB25KJpp1t656",
                Role = "Admin"
            });
        }
    }
}