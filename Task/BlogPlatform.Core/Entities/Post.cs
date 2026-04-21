
public sealed class Post
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string? ImageUrl { get; set; }

    public DateTime CreatedAt { get; set; }

    public string AuthorId { get; set; }
    public AppUser Author { get; set; }

    public List<PostCategory> PostCategories { get; set; } = new();
}
