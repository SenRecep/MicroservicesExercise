using FreeCourse.Shared.ServicesLib.Core;

namespace FreeCourse.Services.Catalog.Dtos
{
    public class CategoryDto:IDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
