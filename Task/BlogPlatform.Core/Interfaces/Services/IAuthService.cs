public interface IAuthService
{
    Task<string> RegisterAsync(RegisterDto dto, string role);
    Task<string> LoginAsync(LoginDto dto);
}