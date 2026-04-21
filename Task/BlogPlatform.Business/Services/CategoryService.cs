public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _repo;

    public CategoryService(ICategoryRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<CategoryDto>> GetAllAsync()
    {
        var categories = await _repo.GetAllAsync();

        return categories.Select(c => new CategoryDto { Id = c.Id, Name = c.Name }).ToList();
    }

    public async Task<CategoryDto> GetByIdAsync(int id)
    {
        var category = await _repo.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        return new CategoryDto { Name = category.Name };
    }

    public async Task CreateAsync(CategoryDto dto)
    {
        var category = new Category { Name = dto.Name };

        await _repo.AddAsync(category);
    }

    public async Task UpdateAsync(int id, CategoryDto dto)
    {
        var category = await _repo.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        category.Name = dto.Name;

        await _repo.Update(category);
    }

    public async Task DeleteAsync(int id)
    {
        var category = await _repo.GetByIdAsync(id);

        if (category == null)
            throw new Exception("Category not found");

        await _repo.Delete(category);
    }
}
