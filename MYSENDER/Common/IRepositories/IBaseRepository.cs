using System.Collections.Generic;
using System.Threading.Tasks;
using MYSENDER.Models;

namespace MYSENDER.Common.IRepositories
{
    public interface IBaseRepository<TEntity, TEntity2>
    {
        Task<IEnumerable<TEntity>> List();
        Task<TEntity> Get(TEntity2 id);
        Task<Response> Add(TEntity entity);
        Task<Response> Set(TEntity entity);
        Task<Response> Delete(TEntity2 id);
    }
}
