using System;

public sealed class PostDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public string ImageUrl { get; set; }
    public string AuthorName { get; set; }

    public List<string> Categories { get; set; }
}
