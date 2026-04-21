public sealed class Category
{
    public int Id { get; set; }

    public string Name { get; set; }

    public List<PostCategory> PostCategories { get; set; } = new();
}
