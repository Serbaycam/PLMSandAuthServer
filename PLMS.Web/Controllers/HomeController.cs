namespace PLMS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper mapper;
        private readonly IGenericService<Product, PLMSDbContext> genericService;
        public HomeController(ILogger<HomeController> logger, IGenericService<Product, PLMSDbContext> genericService, IMapper mapper)
        {
            _logger = logger;
            this.genericService = genericService;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var result = mapper.Map<IEnumerable<ProductDto>>(await genericService.GetAllAsync());
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}