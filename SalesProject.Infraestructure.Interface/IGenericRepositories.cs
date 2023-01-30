using SalesProject.Domain.Core;

namespace SalesProject.Infraestructure.Interface
{
    public interface IGenericRepositories<T> where T : ClassBase
    {
        #region async methods
        Task<int> InsertAsync(T entity);
        Task<int> UpdateAsync(T entity);
        Task<int> DeleteAsync(T entity);
        Task<T?> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> GetAllAsync();
        #endregion
    }
}
