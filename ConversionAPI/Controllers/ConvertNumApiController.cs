using ConversionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConversionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConvertNumApiController : ControllerBase
    {
        private readonly IConvertNumService _convertNumService;
        public ConvertNumApiController(IConvertNumService convertNumService) => _convertNumService = convertNumService;

        [HttpGet("{amount}")]
        public string Convert(double amount)
        {
            var data = _convertNumService.ConvertNum(amount);

            return data;
        }
    }
}
