
using System.Threading.Tasks;

using FreeCourse.Services.Catalog.Services;
using FreeCourse.Shared.ServicesLib.ControllerBases;

using Microsoft.AspNetCore.Mvc;

namespace FreeCourse.Services.Catalog.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    internal class CoursesController : CustomBaseController
    {
        private readonly ICourseService courseService;

        public CoursesController(ICourseService courseService)
        {
            this.courseService = courseService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var response = await courseService.GetByIdAsync(id);
            return CreateIActionResultInstance(response);
        }
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllByUserId(string userId)
        {
            var response = await courseService.GetAllByUserIdAsync(userId);
            return CreateIActionResultInstance(response);
        }
    }
}
