using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MiniShop.SharedKernel.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
