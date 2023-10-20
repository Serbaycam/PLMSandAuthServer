namespace PLMS.Api.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Product,AppDbContext> _genericService;
        private readonly IUnitOfWork<AppDbContext> _unitOfWork;

        public ProductsController(IMapper mapper, IGenericService<Product, AppDbContext> genericService, IUnitOfWork<AppDbContext> unitOfWork)
        {
            _mapper = mapper;
            _genericService = genericService;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _genericService.GetAllAsync();
            var productDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult<List<ProductDto>>(CustomResponseDTO<List<ProductDto>>.Success(200, productDtos));
        }

    }
}
