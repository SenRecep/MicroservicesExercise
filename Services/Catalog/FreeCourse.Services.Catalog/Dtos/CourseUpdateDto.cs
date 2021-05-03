
using FreeCourse.Shared.ServicesLib.Core;

namespace FreeCourse.Services.Catalog.Dtos
{
    internal class CourseUpdateDto:IDto
    {
        internal string Id { get; set; }

        internal string Name { get; set; }

        internal decimal Price { get; set; }


        internal string Description { get; set; }

        internal string Picture { get; set; }

        internal string UserId { get; set; }


        internal FeatureDto Feature { get; set; }

        internal string CategoryId { get; set; }
    }
}
