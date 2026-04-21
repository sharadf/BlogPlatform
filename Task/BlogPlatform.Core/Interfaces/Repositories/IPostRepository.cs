public interface IPostRepository
{
    // Task<List<Category>> GetAllAsync();

    Task<List<Post>> GetAllAsync();
    Task<Post> GetByIdAsync(int id);
    Task<Post> AddAsync(Post post);
    Task Update(Post post);
    Task Delete(Post post);
}
