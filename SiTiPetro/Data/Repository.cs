using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data
{
    public class Repository<T> : IRepository<T> where T : class, IEntity
    {
        protected readonly AplikasiContext context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public Repository(AplikasiContext context)
        {
            this.context = context;
            entities = context.Set<T>();
        }

        public async Task Delete(int id)
        {

            if (String.IsNullOrEmpty(id.ToString())) throw new ArgumentNullException("entity");

            T entity = entities.SingleOrDefault(s => s.Id == id);
            entities.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await entities.FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");

            entities.Add(entity);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            
            entities.Update(entity);
            await context.SaveChangesAsync();
        }
    }
}
