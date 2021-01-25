using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiTiPetro.Data
{
    public interface IRepository<T> where T : class, IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(int id);

    }
}
