using System.Collections.Generic;
using System.Threading.Tasks;

namespace SportAccountApi.DAL
{
    public interface IStandartDTO<T>
    {
        public Task<ICollection<T>> GetAllAsync();
        public Task<T> FindByIdAsync(int id);

        public Task<ICollection<T>> AddAsync(T model);
        public Task<ICollection<T>> UpdateAsync(T model); 

        public Task<ICollection<T>> DeleteAsync(int id);

    }
}
