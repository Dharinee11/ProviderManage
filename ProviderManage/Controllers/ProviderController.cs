using Microsoft.AspNetCore.Mvc;
using ProviderManage.Common;
using ProviderManage.Services.Interfaces;
using ProviderManagement.API.DTOs;

namespace ProviderManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderService _providerService;
        private readonly ILogger<ProviderController> _logger;

        public ProviderController(
            IProviderService providerService,
            ILogger<ProviderController> logger)
        {
            _providerService = providerService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProviders()
        {
            var providers = await _providerService.GetProvidersAsync();

            return Ok(new ApiResponse<IEnumerable<ProviderResponseDto>>(
                true,
                "Providers retrieved successfully",
                providers));
        }

        [HttpGet("{providerId:int}")]
        public async Task<IActionResult> GetProvider(int providerId)
        {
            var provider = await _providerService.GetProviderByIdAsync(providerId);

            return Ok(new ApiResponse<ProviderResponseDto>(
                true,
                "Provider retrieved successfully",
                provider));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider(
            [FromBody] CreateProviderDto request)
        {
            var providerId =
                await _providerService.CreateProviderAsync(request);

            return CreatedAtAction(
                nameof(GetProvider),
                new { providerId },
                new ApiResponse<int>(
                    true,
                    "Provider created successfully",
                    providerId));
        }

        [HttpPut("{providerId:int}")]
        public async Task<IActionResult> UpdateProvider(
            int providerId,
            [FromBody] UpdateProviderDto request)
        {
            await _providerService.UpdateProviderAsync(
                providerId,
                request);

            return Ok(new ApiResponse<object>(
                true,
                "Provider updated successfully",
                null));
        }

        [HttpDelete("{providerId:int}")]
        public async Task<IActionResult> DeleteProvider(
            int providerId)
        {
            await _providerService.DeleteProviderAsync(providerId);

            return Ok(new ApiResponse<object>(
                true,
                "Provider deleted successfully",
                null));
        }
    }
}