// * Com intuito de simplificar e separar responsabilidades optei por uma classe própria de requisição login ao invés de uma DTO. 
    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }