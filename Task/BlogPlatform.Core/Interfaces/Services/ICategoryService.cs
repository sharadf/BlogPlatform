using Microsoft.EntityFrameworkCore.Metadata.Internal;

public interface ICategoryService
{
    Task<List<CategoryDto>> GetAllAsync();
    Task<CategoryDto> GetByIdAsync(int id);

    Task CreateAsync(CategoryDto dto);
    Task UpdateAsync(int id, CategoryDto dto);
    Task DeleteAsync(int id);
}
