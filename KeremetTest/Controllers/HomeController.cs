using KeremetTest.Data;
using KeremetTest.Helper;
using KeremetTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;

namespace KeremetTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly KeremetDbContext db;
        protected readonly IExcelHelper _excelHelper;

        public HomeController(ILogger<HomeController> logger, IConfiguration configuration, IExcelHelper excelHelper)
        {
            _logger = logger;
            db = new KeremetDbContext(configuration["ConnectionString"]);
            _excelHelper = excelHelper;
        }

        public IActionResult Index()
        {            
            return View();
        }
        public IActionResult ExportToExel()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ExportToExel(ClientVM model)
        {
            var client = await db.Clients.FirstOrDefaultAsync(m => m.SocialNumber == model.SocialNumber);
            if (client != null)
            {
                _excelHelper.Export(client);
                TempData["SuccessMessage"] = $"Документ {model.SocialNumber}.xlsx успешно сохранен в папку проекта Result";
            }
            else 
            {
                TempData["SuccessMessage"] = $"Клиент не найден";                
            }
            return View(model);
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
