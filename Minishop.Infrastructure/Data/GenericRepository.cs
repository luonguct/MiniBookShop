using MiniShop.SharedKernel;
using MiniShop.SharedKernel.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Minishop.Infrastructure.Data
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        public Task<List<T>> GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new System.NotImplementedException();
        }
    }
}