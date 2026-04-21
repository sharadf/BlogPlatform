using Microsoft.EntityFrameworkCore;

public class PostRepository : IPostRepository
{
    private readonly AppDbContext _context;

    public PostRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Post>> GetAllAsync()
    {
        return await _context
            .Posts.Include(p => p.Author)
            .Include(p => p.PostCategories)
            .ThenInclude(pc => pc.Category)
            .ToListAsync();
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        return await _context
            .Posts.Include(p => p.Author)
            .Include(p => p.PostCategories)
            .ThenInclude(pc => pc.Category)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Post> AddAsync(Post post)
    {
        _context.Add(post);
        await _context.SaveChangesAsync();
        return post;
    }

    public async Task Update(Post post)
    {
        _context.Update(post);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Post post)
    {
        _context.Remove(post);
        await _context.SaveChangesAsync();
    }
}
