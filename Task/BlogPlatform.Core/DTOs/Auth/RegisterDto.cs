using System.ComponentModel.DataAnnotations;

public sealed class RegisterDto
{
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string UserName { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [RegularExpression(
        @"^(?=.*[A-Z])(?=.*\d).{6,}$",
        ErrorMessage = "Пароль должен содержать минимум 6 символов, 1 цифру и 1 заглавную букву"
    )]
    public string Password { get; set; }
}
