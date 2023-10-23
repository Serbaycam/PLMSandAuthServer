namespace PLMS.Api.Controllers
{
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Product, PLMSDbContext> _genericService;
        private readonly IUnitOfWork<PLMSDbContext> _unitOfWork;

        public ProductsController(IMapper mapper, IGenericService<Product, PLMSDbContext> genericService, IUnitOfWork<PLMSDbContext> unitOfWork)
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
            return CreateActionResult(CustomResponseDTO<List<ProductDto>>.Success(200, productDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Product,PLMSDbContext>))]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _genericService.GetByIdAsync(id);
            var productDto = _mapper.Map<ProductDto>(product);
            return CreateActionResult(CustomResponseDTO<ProductDto>.Success(200, productDto));
        }
        [HttpPost()]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            await _genericService.AddAsync(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDto>.Success(201));
        }
        [HttpPut()]
        public IActionResult Update(ProductDto productDto)
        {
            _genericService.Update(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDto>.Success(204));
        }
        [HttpDelete()]
        public IActionResult Remove(ProductDto productDto)
        {
            _genericService.Remove(_mapper.Map<Product>(productDto));
            return CreateActionResult(CustomResponseDTO<NoContentDto>.Success(204));
        }

    }
}
