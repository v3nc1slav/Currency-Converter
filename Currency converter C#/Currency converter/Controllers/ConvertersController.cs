namespace Currency_converter.Controllers
{
    using System.Diagnostics;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Currency_converter.Models;
    using Currency_converter.Services;

    public class ConvertersController : Controller
    {
        private readonly ILogger<ConvertersController> _logger;
        private readonly IConverterServices converter;

        public ConvertersController(ILogger<ConvertersController> logger, IConverterServices converterService)
        {
            _logger = logger;
            converter = converterService;
        }


        [HttpPost]
        public async Task<IActionResult> Converters(HomeViewModels input)
        {
            _logger.LogInformation("Post index");
            if (input.inputAmount==0)
            {
                return this.RedirectToAction("Index", "Home", new { input = "Please enter a valid value in the field Amount!" });
            }
            if (input.formControl == input.toControl)
            {
                return this.RedirectToAction("Index", "Home", new { input = "Please select a different value for the TO field than in the FROM field!" });
            }

            var result = converter.Converter(input.inputAmount, input.formControl, input.toControl);
           
            return this.RedirectToAction("Index", "Home", new { input = result, booll = true });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
