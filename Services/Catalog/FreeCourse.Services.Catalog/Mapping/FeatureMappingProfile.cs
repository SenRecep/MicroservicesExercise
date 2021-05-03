
using AutoMapper;

using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;

namespace FreeCourse.Services.Catalog.Mapping
{
    public class FeatureMappingProfile : Profile
    {
        public FeatureMappingProfile()
        {
            CreateMap<Feature, FeatureDto>().ReverseMap();
        }
    }
}
