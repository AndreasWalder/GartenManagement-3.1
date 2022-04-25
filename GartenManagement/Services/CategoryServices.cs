using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GartenManagement.BAL;

namespace GartenManagement.Services
{
    public class CategoryServices
    {
        #region Property
        private readonly GartenContext _appDBContext;
        #endregion

        #region Constructor
        public CategoryServices(GartenContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Category
        public async Task<List<Category>> GetAllAsync()
        {
            return await _appDBContext.Categories.ToListAsync();
        }
        #endregion

        #region Insert Category
        public async Task<bool> InsertAsync(Category category)
        {
            await _appDBContext.Categories.AddAsync(category);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Category by Id
        public async Task<Category> GetByIdAsync(int Id)
        {
            Category category = await _appDBContext.Categories.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return category;
        }
        #endregion

        #region Update Category
        public async Task<bool> UpdateAsync(Category category)
        {
            _appDBContext.Categories.Update(category);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Category
        public async Task<bool> DeleteAsync(Category category)
        {
            _appDBContext.Remove(category);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
