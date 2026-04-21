using System.Security.Claims;
using Microsoft.EntityFrameworkCore;


    // Task CreateAsync(CreatePostDto dto, string userId);
    // void UpdateAsync(int id, CreatePostDto dto);
    // void DeleteAsync(int id);

public class PostService : IPostService
{
    private readonly IPostRepository _postRepo;
    private readonly ICategoryRepository _categoryRepo;
    private readonly AppDbContext _context;

    public PostService(
        IPostRepository postRepo,
        ICategoryRepository categoryRepo,
        AppDbContext context
    )
    {
        _postRepo = postRepo;
        _categoryRepo = categoryRepo;
        _context = context;
    }

    public async Task<List<PostDto>> GetAllAsync()
    {
        var posts = await _postRepo.GetAllAsync();

        return posts
            .Select(p => new PostDto
            {
                Id = p.Id,
                Title = p.Title,
                Content = p.Content,
                ImageUrl = p.ImageUrl,
                AuthorName = p.Author.UserName,
                Categories = p.PostCategories.Select(pc => pc.Category.Name).ToList(),
            })
            .ToList();
    }

    public async Task<PostDto> GetByIdAsync(int id)
    {
        var post = await _postRepo.GetByIdAsync(id);

        if (post == null)
            throw new Exception("Post not found");

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Content = post.Content,
            ImageUrl = post.ImageUrl,
            AuthorName = post.Author.UserName,
            Categories = post.PostCategories.Select(pc => pc.Category.Name).ToList(),
        };
    }

    public async Task CreateAsync(CreatePostDto dto, string userId)
    {
        var post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            ImageUrl = dto.ImageUrl,
            CreatedAt = DateTime.UtcNow,
            AuthorId = userId,
        };

        await _postRepo.AddAsync(post);

        // ❗ ВАЖНО: сохраняем связи Many-to-Many
        foreach (var catId in dto.CategoryIds)
        {
            var category = await _categoryRepo.GetByIdAsync(catId);

            if (category == null)
                throw new Exception($"Category {catId} not found");

            _context.PostCategories.Add(new PostCategory { PostId = post.Id, CategoryId = catId });
        }

        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(int id, CreatePostDto dto)
    {
        var post = await _postRepo.GetByIdAsync(id);

        if (post == null)
            throw new Exception("Post not found");

        post.Title = dto.Title;
        post.Content = dto.Content;
        post.ImageUrl = dto.ImageUrl;

        var existing = _context.PostCategories.Where(pc => pc.PostId == id);

        _context.PostCategories.RemoveRange(existing);

        foreach (var catId in dto.CategoryIds)
        {
            _context.PostCategories.Add(new PostCategory { PostId = id, CategoryId = catId });
        }

        await _postRepo.Update(post);
    }

    public async Task DeleteAsync(int id)
    {
        var post = await _postRepo.GetByIdAsync(id);

        if (post == null)
            throw new Exception("Post not found");

        _postRepo.Delete(post);
    }
}
