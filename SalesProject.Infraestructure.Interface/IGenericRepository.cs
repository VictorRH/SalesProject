using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalesProject.Infraestructure.Interface
{
    public interface IGenericRepository<T>
    {
        #region async methods
        Task<bool> InsertAsync(T obj);
        Task<bool> UpdateAsync(int id, T obj);
        Task<bool> DeleteAsync(int id);
        Task<T> GetByIdAsync(int id);
        Task<T> GetAllAsync();
        #endregion
    }
}
