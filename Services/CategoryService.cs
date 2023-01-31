using Domain.Entities;
using Domain.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAllCategories();
            return categories.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public async Task<CategoryDTO> GetCategoryById(long id)
        {
            var category = await _categoryRepository.GetCategoryById(id);
            if (category == null)
            {
                return null;
            }
            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public async Task AddCategory(CategoryDTO categoryDTO)
        {
            var category = new Category
            {
                Id = categoryDTO.Id,
                Name = categoryDTO.Name
            };
            await _categoryRepository.AddCategory(category);
        }

        public async Task UpdateCategory(CategoryDTO categoryDTO)
        {
            var category = await _categoryRepository.GetCategoryById(categoryDTO.Id);
            category.Name = categoryDTO.Name;
            await _categoryRepository.UpdateCategory(category);
        }

        public async Task DeleteCategory(long id)
        {
            await _categoryRepository.DeleteCategory(id);
        }
    }
}
