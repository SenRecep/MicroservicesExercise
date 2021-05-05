using System.Collections;
using System.Collections.Generic;
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
    public class CategoryManager : ICategoryService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMapper _mapper;
        private readonly IDatabaseSettings _databaseSettings;
        public CategoryManager(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            _mapper = mapper;
            _databaseSettings = databaseSettings;
            MongoClient client = new(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);

        }

        public async Task<Response<IEnumerable<CategoryDto>>> GetAllAsync()
        {
            var categories = await _categoryCollection.Find(category => true).ToListAsync();
            var dtoList = _mapper.Map<IEnumerable<CategoryDto>>(categories);
            return Response<IEnumerable<CategoryDto>>.Success(dtoList, StatusCodes.Status200OK);
        }

        public async Task<Response<CategoryDto>> GetByIdAsync(string id)
        {
            var category = await _categoryCollection.Find(category => category.Id == id).FirstOrDefaultAsync();
            if (category is null) return Response<CategoryDto>.Fail(StatusCodes.Status404NotFound, "Category not found");
            var dto = _mapper.Map<CategoryDto>(category);
            return Response<CategoryDto>.Success(dto, StatusCodes.Status200OK);
        }

        public async Task<Response<CategoryDto>> CreateAsync(CategoryCreateDto categoryCreateDto)
        {
            var category = _mapper.Map<Category>(categoryCreateDto);
            await _categoryCollection.InsertOneAsync(category);
            var dto = _mapper.Map<CategoryDto>(category);
            return Response<CategoryDto>.Success(dto, StatusCodes.Status201Created);
        }
    }
}
