using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CategoryDAO
    {
        private readonly BookStoreContext _dbContext;

        public CategoryDAO(BookStoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int categoryId)
        {
            return _dbContext.Categories.FirstOrDefault(c => c.Category_Id == categoryId);
        }

        public int InsertCategory(Category category)
        {
            _dbContext.Categories.Add(category);
            _dbContext.SaveChanges();

            return category.Category_Id;
        }

        public void UpdateCategory(Category category)
        {
            _dbContext.Categories.Update(category);
            _dbContext.SaveChanges();
        }

        public void DeleteCategory(int categoryId)
        {
            var category = _dbContext.Categories.FirstOrDefault(c => c.Category_Id == categoryId);

            if (category != null)
            {
                _dbContext.Categories.Remove(category);
                _dbContext.SaveChanges();
            }
        }
    }

}
