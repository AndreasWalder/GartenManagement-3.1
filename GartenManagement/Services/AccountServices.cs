using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using GartenManagement.BAL;

namespace GartenManagement.Services
{
    public class AccountServices
    {
        #region Property
        private readonly GartenContext _appDBContext;
        #endregion

        #region Constructor
        public AccountServices(GartenContext appDBContext)
        {
            _appDBContext = appDBContext;
        }
        #endregion

        #region Get List of Account
        public async Task<List<Account>> GetAllAsync()
        {
            return await _appDBContext.Accounts.ToListAsync();
        }
        #endregion

        #region Insert Account
        public async Task<bool> InsertAsync(Account account)
        {
            await _appDBContext.Accounts.AddAsync(account);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Get Account by Id
        public async Task<Account> GetByIdAsync(int Id)
        {
            Account account = await _appDBContext.Accounts.FirstOrDefaultAsync(c => c.Id.Equals(Id));
            return account;
        }
        #endregion

        #region Update Account
        public async Task<bool> UpdateAsync(Account account)
        {
            _appDBContext.Accounts.Update(account);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion

        #region Delete Account
        public async Task<bool> DeleteAsync(Account account)
        {
            _appDBContext.Remove(account);
            await _appDBContext.SaveChangesAsync();
            return true;
        }
        #endregion
    }
}
