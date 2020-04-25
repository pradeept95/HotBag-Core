using HotBag.AspNetCore.Data.EntityBase;
using HotBag.AspNetCore.ResultWrapper.ResponseModel;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.Web.Service.Generic
{
    public interface IAppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey>
        where TEntity : IEntityBase<TPrimaryKey>
        where TEntityDto : IEntityBaseDto<TPrimaryKey>
    {
        Task Delete(TPrimaryKey id);
        Task<ResultDto<TEntityDto>> Get(TPrimaryKey id);
        Task<ListResultDto<TEntityDto>> GetAll(string searchText);
        Task<PagedResultDto<TEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText);
        Task<ResultDto<int>> GetCount();
        Task<ResultDto<TEntityDto>> Save(TEntityDto entity);
        Task<ResultDto<TEntityDto>> Update(TEntityDto entity);
    }

}
