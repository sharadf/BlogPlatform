using System.ComponentModel.DataAnnotations;

public sealed class CategoryDto
{
    public int Id { get; set; }
    
    [Required]
    [StringLength(50, MinimumLength = 2)]
    public string Name { get; set; }
}
