using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Currency_converter.Models;

namespace Currency_converter.Controllers
{
    public class ConvertersController : Controller
    {
        private readonly ILogger<ConvertersController> _logger;

        public ConvertersController(ILogger<ConvertersController> logger)
        {
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Converters(HomeViewModels input)
        {

            if (input.inputAmount==0)
            {
                return this.RedirectToAction("Index", "Home", new { input = "Please enter a valid value in the field Amount!" });
            }
            if (input.formControl == input.toControl)
            {
                return this.RedirectToAction("Index", "Home", new { input = "Please select a different value for the TO field than in the FROM field!" });
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
