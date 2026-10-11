using Microsoft.AspNetCore.Mvc;
using ProviderManage.Services.Interfaces;

namespace ProviderManage.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;

        public ProviderController(
            IProviderService providerService)
        {
            _providerService = providerService;
        }

        [HttpGet]
        public IActionResult GetProviders()
        {
            var providers =
                _providerService.GetProviders();

            return Ok(providers);
        }
    }
}