using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GartenManagement.BAL;

namespace GartenManagement.Services
{
    public class LieferungServices
    {
        #region Property
        private readonly GartenContext _appDBContext;
        #endregion

        #region Constructor
        public LieferungServices(GartenContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Lieferung
        public async Task<List<Lieferung>> GetAllAsync()
        {
            return await _appDBContext.Lieferungs.ToListAsync();
        }
        #endregion

        #region Insert Lieferung
        public async Task<bool> InsertAsync(Lieferung lieferung)
        {
            await _appDBContext.Lieferungs.AddAsync(lieferung);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Lieferung by Id
        public async Task<Lieferung> GetByIdAsync(int Id)
        {
            Lieferung lieferung = await _appDBContext.Lieferungs.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return lieferung;
        }
        #endregion

        #region Update Lieferung
        public async Task<bool> UpdateAsync(Lieferung lieferung)
        {
            _appDBContext.Lieferungs.Update(lieferung);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Lieferung
        public async Task<bool> DeleteAsync(Lieferung lieferung)
        {
            _appDBContext.Remove(lieferung);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
