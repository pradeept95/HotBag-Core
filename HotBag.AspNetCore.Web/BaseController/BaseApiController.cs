using HotBag.AspNetCore.Web.AppSession;
using Microsoft.AspNetCore.Mvc;


namespace HotBag.AspNetCore.Web.BaseController
{
    [Route("api/app/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseApiController : ControllerBase
    {
        protected readonly IAppSession AppSession;
        public BaseApiController()
        {
            AppSession = NullAppSession.Instance;
        }
    }

    [Route("api/app/[Area]/[controller]")]
    [ApiController]
    //[Authorize]
    public class BaseApiAreaController : ControllerBase
    {
        protected readonly IAppSession AppSession;
        public BaseApiAreaController()
        {
            AppSession = NullAppSession.Instance;
        }
    }

    //[GenericControllerName]
    //[Route("api/app/v1/[controller]")]
    //[ApiController]
    //public class GenericBaseController<TEntity, TEntityDto, TPrimaryKey>
    //  where TEntity : IEntityBase<TPrimaryKey>
    //  where TEntityDto : IEntityBaseDto<TPrimaryKey>
    //{
    //    private readonly IAppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey> _service;
    //    public GenericBaseController(IAppAsyncCrudService<TEntityDto, TEntity, TPrimaryKey> service)
    //    {
    //        _service = service;
    //    }

    //    [HttpGet]
    //    [Route("Get")]
    //    public async Task<ResultDto<TEntityDto>> Get(TPrimaryKey id)
    //    {
    //        return await _service.Get(id);
    //    }

    //    [HttpGet]
    //    [Route("GetAll")]
    //    public async Task<ListResultDto<TEntityDto>> GetAll(string searchText)
    //    {
    //        return await _service.GetAll(searchText);
    //    }

    //    [HttpGet]
    //    [Route("GetAllPaged")]
    //    public async Task<PagedResultDto<TEntityDto>> GetAllPaged(int skip, int maxResultCount, string searchText)
    //    {
    //        return await _service.GetAllPaged(skip, maxResultCount, searchText);
    //    }

    //    [HttpGet]
    //    [Route("Count")]
    //    public async Task<ResultDto<int>> GetCount()
    //    {
    //        return await _service.GetCount();
    //    }

    //    [HttpPost]
    //    [Route("Save")]
    //    public async Task<ResultDto<TEntityDto>> Save(TEntityDto entity)
    //    {
    //        return await _service.Save(entity);
    //    }


    //    [HttpPut]
    //    [Route("Update")]
    //    public async Task<ResultDto<TEntityDto>> Update(TEntityDto entity)
    //    {
    //        return await _service.Update(entity);
    //    }

    //    [HttpDelete]
    //    [Route("Delete")]
    //    public async Task Delete(TPrimaryKey id)
    //    {
    //        await _service.Delete(id);
    //    }
    //}

    //public class GenericTypeControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    //{
    //    public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
    //    {
    //        //var currentAssembly = typeof(GenericTypeControllerFeatureProvider).Assembly;

    //        var platform = Environment.OSVersion.Platform.ToString();
    //        var runtimeAssemblyNames = DependencyContext.Default.GetRuntimeAssemblyNames(platform);
    //        var allAssembly = runtimeAssemblyNames
    //            .Select(Assembly.Load)
    //            .Where(x => x.FullName.Contains("HotBag"));

    //        foreach (var assembly in allAssembly)
    //        {
    //            var candidates = assembly.GetExportedTypes().Where(x => x.GetCustomAttributes<GeneratedControllerAttribute>().Any());

    //            foreach (var candidate in candidates)
    //            {
    //                var dto = candidate.GetCustomAttribute<GeneratedControllerAttribute>();
    //                if (dto == null)
    //                {
    //                    continue;
    //                }
    //                var genController = typeof(GenericBaseController<,,>).MakeGenericType(candidate, dto.EntityDtoType, dto.PrimaryKeyType).GetTypeInfo();
    //                feature.Controllers.Add(genController);
    //            }
    //        }
    //    }

    //    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    //    public class GenericControllerNameAttribute : Attribute, IControllerModelConvention
    //    {
    //        public void Apply(ControllerModel controller)
    //        {
    //            if (controller.ControllerType.GetGenericTypeDefinition() == typeof(GenericBaseController<,,>))
    //            {
    //                var entityType = controller.ControllerType.GenericTypeArguments[0];
    //                controller.ControllerName = entityType.Name;
    //            }
    //        }
    //    }
    //}
}
