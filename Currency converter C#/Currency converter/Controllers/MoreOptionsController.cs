namespace Currency_converter.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Currency_converter.Models;

    public class MoreOptionsController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public MoreOptionsController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> MoreOptions()
        {
            _logger.LogInformation("Get MoreOptions");
            return this.View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
