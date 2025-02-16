using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaipherCustomerManager;

[Route("api/customers")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly AppDbContext _context;

    public CustomerController(AppDbContext context)
    {
        _context = context;
    }

    // * Entendo que, nesse contexto, onde a Auth não é global, não é obrigatório o uso de "[AllowAnonymous]", inclui pra deixar explicíto à outros desenvolvedores que não foi um erro ou "esquecimento" na inclusão do atributo de "[Authorize]".]
    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] CustomerRegisterDto request)
    {
        if (await _context.Customers.AnyAsync(c => c.Email == request.Email))
        {
            return BadRequest("Email already registered.");
        }

        // Proteção contra XSS na entrada
        var customer = new Customer
        {
            Name = System.Web.HttpUtility.HtmlEncode(request.Name),
            Email = System.Web.HttpUtility.HtmlEncode(request.Email),
            Password = BCrypt.Net.BCrypt.HashPassword(request.Password), 
            Role = "Default"  // Somente Admins poderão promover.
        };

        _context.Customers.Add(customer);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Customer registered successfully!" });
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAll()
    {
        var customers = await _context.Customers.ToListAsync();
        return Ok(customers);
    }

    [HttpGet("{id}")]
    [AllowAnonymous]
    public async Task<IActionResult> GetById(int id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return NotFound("Customer not found.");

        // Proteção contra XSS na saída
        var safeCustomer = new
        {
            Id = customer.Id,
            Name = System.Web.HttpUtility.HtmlEncode(customer.Name),
            Email = System.Web.HttpUtility.HtmlEncode(customer.Email),
            Role = System.Web.HttpUtility.HtmlEncode(customer.Role)
        };

        return Ok(safeCustomer);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] Customer updatedCustomer)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
            return NotFound("Customer not found.");

        if (!string.IsNullOrEmpty(updatedCustomer.Name))
            customer.Name = updatedCustomer.Name;

        if (!string.IsNullOrEmpty(updatedCustomer.Email))
            customer.Email = updatedCustomer.Email;

        if (!string.IsNullOrEmpty(updatedCustomer.Password))
            customer.Password = updatedCustomer.Password;

        if (!string.IsNullOrEmpty(updatedCustomer.Role))
            customer.Role = updatedCustomer.Role;

        await _context.SaveChangesAsync();
        return Ok(new { message = "Customer updated successfully!" });
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null) return NotFound("Customer not found.");

        _context.Customers.Remove(customer);
        await _context.SaveChangesAsync();

        return Ok(new { message = "Customer deleted successfully!" });
    }
}
