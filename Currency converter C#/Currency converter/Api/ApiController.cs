namespace Currency_converter.Api
{
    using Currency_converter.Services;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ILogger<ApiController> _logger;
        private readonly IConverterServices converter;

        public ApiController(ILogger<ApiController> logger, IConverterServices converterService)
        {
            _logger = logger;
            converter = converterService;
        }

        [HttpGet("{input}", Name = "GetCurrencyConverterByString")]
        public ActionResult GetCurrencyConverterByString(string input)
        {
            _logger.LogInformation("GetCurrencyConverterByString");

            input = input.ToUpper();

            if (input != null)
            {
                var result = converter.ConverterApi(input);

                return Ok(result);
            }

            return NotFound();
        }

        [HttpGet("{id}/{forr}/{to}", Name = "GetCurrencyConverterByStrings")]
        public ActionResult GetCurrencyConverterByStrings(double id, string forr,string to)
        {
            _logger.LogInformation("GetCurrencyConverterByStrings");

            forr = forr.ToUpper();
            to = to.ToUpper();

            if (forr != null && to !=null && id>0)
            {
                var result = converter.Converter(id, forr, to);

                return Ok(result);
            }

            return NotFound();
        }
    }
}
