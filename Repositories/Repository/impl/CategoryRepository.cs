using BusinessObject.Models;
using DataAccess.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CategoryDAO _categoryDAO;

        public CategoryRepository(CategoryDAO categoryDAO)
        {
            _categoryDAO = categoryDAO;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryDAO.GetAllCategories();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _categoryDAO.GetCategoryById(categoryId);
        }

        public int InsertCategory(Category category)
        {
            return _categoryDAO.InsertCategory(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDAO.UpdateCategory(category);
        }

        public void DeleteCategory(int categoryId)
        {
            _categoryDAO.DeleteCategory(categoryId);
        }
    }

}
