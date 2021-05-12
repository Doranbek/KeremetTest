using KeremetTest.Data;
using KeremetTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace KeremetTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        protected readonly KeremetDbContext db;
       
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            db = new KeremetDbContext(configuration["ConnectionString"]);
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
            var result = await db.Clients.FirstOrDefaultAsync(m => m.SocialNumber == model.SocialNumber);
           
            return View();
        }
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
