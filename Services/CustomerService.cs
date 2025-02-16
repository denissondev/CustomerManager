using SaipherCustomerManager.Helpers;
using Microsoft.EntityFrameworkCore;

namespace SaipherCustomerManager.Services
{
    public class CustomerService
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public CustomerService(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<List<Customer>> GetAllAsync() => await _context.Customers.ToListAsync();
        public async Task<Customer?> GetByIdAsync(int id) => await _context.Customers.FindAsync(id);
        public async Task AddAsync(Customer customer) { _context.Customers.Add(customer); await _context.SaveChangesAsync(); }
        public async Task UpdateAsync(Customer customer) { _context.Customers.Update(customer); await _context.SaveChangesAsync(); }
        public async Task DeleteAsync(int id) { var customer = await _context.Customers.FindAsync(id); if (customer != null) { _context.Customers.Remove(customer); await _context.SaveChangesAsync(); } }

        public async Task<string?> AuthenticateAsync(string email, string password)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email);
            if (customer == null || !BCrypt.Net.BCrypt.Verify(password, customer.Password))
            {
                return null;
            }

            return _jwtService.GenerateToken(customer.Email, customer.Role);
        }
    }
}