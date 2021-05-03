using FreeCourse.Shared.ServicesLib.Core;

namespace FreeCourse.Services.Catalog.Dtos
{
    internal class CategoryDto:IDto
    {
        internal string Id { get; set; }
        internal string Name { get; set; }
    }
}
