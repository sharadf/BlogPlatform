using System.ComponentModel.DataAnnotations;

public sealed class CreatePostDto
{
    [Required]
    public string Title { get; set; }

    [Required]
    public string Content { get; set; }

    public string? ImageUrl { get; set; }

    [Required]
    public List<int> CategoryIds { get; set; }
}
