public interface IPostService
{
    Task<List<PostDto>> GetAllAsync();
    Task<PostDto> GetByIdAsync(int id);
    Task CreateAsync(CreatePostDto dto, string userId);
    Task UpdateAsync(int id, CreatePostDto dto);
    Task DeleteAsync(int id);
}
