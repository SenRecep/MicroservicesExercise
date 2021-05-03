using System.Collections.Generic;
using System.Threading.Tasks;

using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Shared.ServicesLib.Dtos;

namespace FreeCourse.Services.Catalog.Services
{
    internal interface ICategoryService
    {
        public Task<Response<IEnumerable<CategoryDto>>> GetAllAsync();
        public Task<Response<CategoryDto>> CreateAsync(Category category);
        public Task<Response<CategoryDto>> GetByIdAsync(int id);
    }
}
