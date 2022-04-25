using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GartenManagement.BAL;

namespace GartenManagement.Services
{
    public class LieferantServices
    {
        #region Property
        private readonly GartenContext _appDBContext;
        #endregion

        #region Constructor
        public LieferantServices(GartenContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Lieferant
        public async Task<List<Lieferant>> GetAllAsync()
        {
            return await _appDBContext.Lieferants.ToListAsync();
        }
        #endregion

        #region Insert Lieferant
        public async Task<bool> InsertAsync(Lieferant lieferant)
        {
            await _appDBContext.Lieferants.AddAsync(lieferant);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Lieferant by Id
        public async Task<Lieferant> GetByIdAsync(int Id)
        {
            Lieferant lieferant = await _appDBContext.Lieferants.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return lieferant;
        }
        #endregion

        #region Update Lieferant
        public async Task<bool> UpdateAsync(Lieferant lieferant)
        {
            _appDBContext.Lieferants.Update(lieferant);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete lieferant
        public async Task<bool> DeleteAsync(Lieferant lieferant)
        {
            _appDBContext.Remove(lieferant);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
