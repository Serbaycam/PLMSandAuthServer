namespace PLMS.Web.Controllers
{
    [Authorize]
    public class HomeController(ILogger<HomeController> logger, IGenericService<SizeSet, PLMSDbContext> genericService, IMapper mapper) : Controller
    {
        private readonly ILogger<HomeController> _logger = logger;
        private readonly IMapper mapper = mapper;
        private readonly IGenericService<SizeSet, PLMSDbContext> genericService = genericService;

        public IActionResult Index()
        {
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