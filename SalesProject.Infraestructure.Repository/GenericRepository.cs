using Microsoft.EntityFrameworkCore;
using SalesProject.Domain.Core;
using SalesProject.Domain.Entity.Models;
using SalesProject.Infraestructure.Interface;

namespace SalesProject.Infraestructure.Repository
{
    public class GenericRepository<T> : IGenericRepositories<T> where T : ClassBase
    {
        private readonly FerreteriaDbContext context;

        public GenericRepository(FerreteriaDbContext context)
        {
            this.context = context;
        }
        public async Task<int> DeleteAsync(T entity)
        {
            context.ChangeTracker.Clear();
            context.Set<T>().RemoveRange(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await context.Set<T>().ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await context.Set<T>().AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<int> InsertAsync(T entity)
        {
            context.Set<T>().Add(entity);
            return await context.SaveChangesAsync();
        }
        public async Task<int> UpdateAsync(T entity)
        {
            context.Set<T>().Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
            return await context.SaveChangesAsync();
        }
    }
}
