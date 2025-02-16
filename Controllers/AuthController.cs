using Microsoft.AspNetCore.Mvc;
using SaipherCustomerManager.Services;

[Route("api/auth")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly CustomerService _customerService;

    public AuthController(CustomerService customerService)
    {
        _customerService = customerService;
    }

// Melhorias futuras de segurança.
    // - Rate Limiting
    // * pra evitar ataques de força bruta. Criar um Middleware que permite somente 3 ou 5 tentaticas por minuto.
    // - Bloqueio por tentativas
    // * Criar um int de contador em customer equando chegar a um numero bloqueia o acesso.

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var token = await _customerService.AuthenticateAsync(request.Email, request.Password);
        if (token == null)
        {
            // * Mater respostas padrão impede que invasor descubre emails válidos
            return Unauthorized("Invalid email or password.");
        }

        return Ok(new { token });
    }
}