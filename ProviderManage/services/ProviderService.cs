using ProviderManage.Exceptions;
using ProviderManage.Models;
using ProviderManage.Repositories.Interfaces;
using ProviderManage.Services.Interfaces;
using ProviderManagement.API.DTOs;
namespace ProviderManage.Services
{
    public class ProviderService : IProviderService
    {      
     
            private readonly IProviderRepository _providerRepository;
            private readonly ILogger<ProviderService> _logger;

            public ProviderService(
                IProviderRepository providerRepository,
                ILogger<ProviderService> logger)
            {
                _providerRepository = providerRepository;
                _logger = logger;
            }

            public async Task<IEnumerable<ProviderResponseDto>> GetProvidersAsync()
            {
                _logger.LogInformation("Fetching all providers");

                var providers = await _providerRepository.GetAllAsync();

                return providers.Select(x => new ProviderResponseDto
                {
                    ProviderId = x.ProviderId,
                    ProviderName = x.Name,
                    Email = x.Email
                });
            }

            public async Task<ProviderResponseDto> GetProviderByIdAsync(int providerId)
            {
                _logger.LogInformation("Fetching provider {ProviderId}", providerId);

                var provider = await _providerRepository.GetByIdAsync(providerId);

                if (provider == null)
                {
                    throw new NotFoundException(
                        $"Provider {providerId} not found");
                }

                return new ProviderResponseDto
                {
                    ProviderId = provider.ProviderId,
                    ProviderName = provider.Name,
                    Email = provider.Email
                };
            }

            public async Task<int> CreateProviderAsync(
                CreateProviderDto request)
            {
                var provider = new Provider
                {
                    Name = request.ProviderName,
                    Email = request.Email
                };

                return await _providerRepository.CreateAsync(provider);
            }

            public async Task UpdateProviderAsync(
                int providerId,
                UpdateProviderDto request)
            {
                var provider = await _providerRepository.GetByIdAsync(providerId);

                if (provider == null)
                    throw new NotFoundException(
                        $"Provider {providerId} not found");

                provider.ProviderName = request.ProviderName;
                provider.Email = request.Email;

                await _providerRepository.UpdateAsync(provider);
            }

            public async Task DeleteProviderAsync(int providerId)
            {
                var provider = await _providerRepository.GetByIdAsync(providerId);

                if (provider == null)
                    throw new NotFoundException(
                        $"Provider {providerId} not found");

                await _providerRepository.DeleteAsync(providerId);
            }
        }
    }
