using System.Collections.Generic;
using System.Threading.Tasks;

using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shared.ServicesLib.Dtos;

namespace FreeCourse.Services.Catalog.Services
{
    internal interface ICategoryService
    {
        public Task<Response<IEnumerable<CategoryDto>>> GetAllAsync();
        public Task<Response<CategoryDto>> GetByIdAsync(string id);
        public Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto);
    }
}
