using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

[Table("AspNetUsers")]
public sealed class AppUser : IdentityUser
{
    public string? FullName { get; set; }
}
