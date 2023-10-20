namespace PLMS.Api.Filters
{
    public class NotFoundFilter<TEntity,TContext> : IAsyncActionFilter where TEntity : class
    {
        private readonly IGenericService<TEntity, TContext> _genericService;

        public NotFoundFilter(IGenericService<TEntity, TContext> genericService)
        {
            _genericService = genericService;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var idValue = context.ActionArguments.Values.FirstOrDefault();
            if (idValue == null)
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _genericService.GetByIdAsync(id);
            if(anyEntity!= null)
            {
                await next.Invoke();
                return;

            }
            else
            {
                context.Result = new NotFoundObjectResult(CustomResponseDTO<NoContentDto>.Fail(404, $"{typeof(TEntity).Name}({id}) not found"));
            }
        }
    }
}
