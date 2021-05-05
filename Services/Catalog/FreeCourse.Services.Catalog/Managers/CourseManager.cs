
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using FreeCourse.Services.Catalog.Dtos;
using FreeCourse.Services.Catalog.Models;
using FreeCourse.Services.Catalog.Services;
using FreeCourse.Services.Catalog.Settings;
using FreeCourse.Shared.ServicesLib.Dtos;

using Microsoft.AspNetCore.Http;

using MongoDB.Driver;

namespace FreeCourse.Services.Catalog.Managers
{
    public class CourseManager : ICourseService
    {
        private readonly IMapper _mapper;
        private readonly IDatabaseSettings _databaseSettings;
        private readonly IMongoCollection<Course> courseCollection;
        private readonly ICategoryService _categoryService;

        public CourseManager(IMapper mapper, IDatabaseSettings databaseSettings, ICategoryService categoryService)
        {
            _mapper = mapper;
            _databaseSettings = databaseSettings;
            MongoClient client = new(databaseSettings.ConnectionString);
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            courseCollection = db.GetCollection<Course>(databaseSettings.CourseCollectionName);
            _categoryService = categoryService;
        }

        private IEnumerable<CourseDto> LoadCourseListCategory(List<Course> courses)
        {
            if (courses.Any())
                courses.ForEach(async item =>
                {
                    var categoryDto = await _categoryService.GetByIdAsync(item.CategoryId);
                    item.Category = _mapper.Map<Category>(categoryDto.Data);
                });

            return _mapper.Map<IEnumerable<CourseDto>>(courses);
        }

        public async Task<Response<CourseDto>> CreateAsync(CourseCreateDto courseCreateDto)
        {
            var course = _mapper.Map<Course>(courseCreateDto);
            course.CreatedTime = DateTime.Now;
            await courseCollection.InsertOneAsync(course);
            var dto = _mapper.Map<CourseDto>(course);
            return Response<CourseDto>.Success(dto, StatusCodes.Status201Created);
        }

        public async Task<Response<NoContent>> UpdateAsync(CourseUpdateDto courseUpdateDto)
        {
            var course = _mapper.Map<Course>(courseUpdateDto);
            var result = await courseCollection.FindOneAndReplaceAsync(x=>x.Id== course.Id,course);
            if (result is null) return Response<NoContent>.Fail(StatusCodes.Status404NotFound,"Course not found");
            return Response<NoContent>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<Response<NoContent>> DeleteAsync(string id)
        {
            var result = await courseCollection.DeleteOneAsync(x=>x.Id==id);
            if(result.DeletedCount==0) return Response<NoContent>.Fail(StatusCodes.Status404NotFound, "Course not found");
            return Response<NoContent>.Success(StatusCodes.Status204NoContent);
        }

        public async Task<Response<IEnumerable<CourseDto>>> GetAllAsync()
        {
            var courses = await courseCollection.Find(course => true).ToListAsync();
            var dtoList = LoadCourseListCategory(courses);
            return Response<IEnumerable<CourseDto>>.Success(dtoList, StatusCodes.Status200OK);
        }

        public async Task<Response<CourseDto>> GetByIdAsync(string id)
        {
            var course = await courseCollection.Find(course => course.Id == id).FirstOrDefaultAsync();
            if (course is null) return Response<CourseDto>.Fail(StatusCodes.Status404NotFound, "Course not found");

            var categoryDto = await _categoryService.GetByIdAsync(course.CategoryId);
            course.Category = _mapper.Map<Category>(categoryDto.Data);

            var dto = _mapper.Map<CourseDto>(course);
            return Response<CourseDto>.Success(dto, StatusCodes.Status200OK);
        }

        public async Task<Response<IEnumerable<CourseDto>>> GetAllByUserIdAsync(string userId)
        {
            var courses = await courseCollection.Find(x => x.UserId.Equals(userId)).ToListAsync();
            var dtoList = LoadCourseListCategory(courses);
            return Response<IEnumerable<CourseDto>>.Success(dtoList, StatusCodes.Status200OK);
        }
    }
}
