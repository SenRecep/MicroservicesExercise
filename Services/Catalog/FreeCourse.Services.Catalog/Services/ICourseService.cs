using System.Collections.Generic;
using System.Threading.Tasks;

using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Shared.ServicesLib.Dtos;

namespace FreeCourse.Services.Catalog.Services
{
    public interface ICourseService
    {
        public Task<Response<IEnumerable<CourseDto>>> GetAllAsync();
        public Task<Response<CourseDto>> GetByIdAsync(string id);
        public Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto);
        public  Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto);
        public  Task<Response<NoContent>> DeleteAsync(string id);
        public Task<Response<IEnumerable<CourseDto>>> GetAllByUserIdAsync(string userId);

    }
}
