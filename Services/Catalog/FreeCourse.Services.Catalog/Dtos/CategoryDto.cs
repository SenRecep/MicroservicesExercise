using FreeCourse.Shared.ServicesLib.Core;

namespace FreeCourse.Services.Catalog.Dtos
{
    internal class CategoryDto:IDto
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
    }
}
