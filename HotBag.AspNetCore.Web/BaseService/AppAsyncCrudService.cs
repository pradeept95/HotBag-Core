﻿using HotBag.AspNetCore.AutoMapper;
using HotBag.AspNetCore.Data.BaseRepository;
using HotBag.AspNetCore.Data.EntityBase;
using HotBag.AspNetCore.DI;
using HotBag.AspNetCore.ResultWrapper.ResponseModel;
using System.Linq;
using System.Threading.Tasks;

namespace HotBag.AspNetCore.Web.Service.Generic
{
    //public class AppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey> : AppServiceBase<TEntityDto, TEntity, TPrimaryKey>, IAppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey> //, ITransientDependencies
    //   where TEntity : class, IEntityBase<TPrimaryKey>
    //   where TEntityDto : IEntityBaseDto<TPrimaryKey>
    //{
    //    private readonly IBaseRepository<TEntity, TPrimaryKey> _repository;
    //    //private readonly IUnitOfWork _unitOfWork;
    //    private readonly IObjectMapper _objectMapper;
    //    public AppAsyncCrudService(
    //         IBaseRepository<TEntity, TPrimaryKey> repository
    //         , IObjectMapper objectMapper
    //        //,IUnitOfWork unitOfWork
    //        )
    //    {
    //        _repository = repository; //repository.GetRepository();
    //        //_unitOfWork = unitOfWork;
    //        _objectMapper = objectMapper;
    //    }

    //    public override async Task Delete(TPrimaryKey id)
    //    {
    //        await _repository.DeleteAsync(id);
    //        await _repository.SaveChangeAsync();
    //    }

    //    public override async Task<ResultDto<TEntityDto>> Get(TPrimaryKey id)
    //    {
    //        var result = await _repository.GetAsync(id);
    //        var res = _objectMapper.Map<TEntityDto>(result);
    //        return new ResultDto<TEntityDto>(res);
    //    }

    //    public override async Task<ListResultDto<TEntityDto>> GetAll(string searchText)
    //    {
    //        var result = _repository.GetAll();
    //        if (!string.IsNullOrEmpty(searchText))
    //        {
    //            //result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
    //        }

    //        IQueryable<TEntityDto> finalResult = _objectMapper.ProjectTo<TEntity, TEntityDto>(result);
    //        var res = await Task.FromResult(finalResult.ToList());
    //        return new ListResultDto<TEntityDto>(res, "Test summary");

    //    }

    //    public override async Task<PagedResultDto<TEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
    //    {
    //        var result = _repository.GetAll();

    //        if (!string.IsNullOrEmpty(searchText))
    //        {
    //            //result = result.Where(x => x.TestName.ToLower().Trim().Contains(searchText.ToLower().Trim()));
    //        }

    //        var totalCount = result.Count();

    //        IQueryable<TEntityDto> finalResult = _objectMapper.ProjectTo<TEntity, TEntityDto>(result);
    //        var res = await Task.FromResult( finalResult.Skip(skip)
    //            .Take(maxResultCount)
    //            .ToList());
    //        return new PagedResultDto<TEntityDto>(totalCount, res, skip + maxResultCount < totalCount, "Total Data With summary");
    //    }

    //    public override async Task<ResultDto<int>> GetCount()
    //    {
    //        return new ResultDto<int>(await _repository.CountAsync());
    //    }

    //    public override async Task<ResultDto<TEntityDto>> Save(TEntityDto entity)
    //    {
    //        var saveModel = _objectMapper.Map<TEntity>(entity);
    //        var result = await _repository.InsertAsync(saveModel);
    //        await _repository.SaveChangeAsync();
    //        var res = _objectMapper.Map<TEntityDto>(result);
    //        return new ResultDto<TEntityDto>(res);
    //    }

    //    public override async Task<ResultDto<TEntityDto>> Update(TEntityDto entity)
    //    {
    //        var updateModel = _objectMapper.Map<TEntity>(entity);

    //        var result = await _repository.UpdateAsync(updateModel);
    //        await _repository.SaveChangeAsync();
    //        var res = _objectMapper.Map<TEntityDto>(result);
    //        return new ResultDto<TEntityDto>(res);
    //    }
    //}

}
