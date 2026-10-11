
using ProviderManagement.API.DTOs;
namespace ProviderManage.Services.Interfaces
{
    public interface IProviderService
    {
       
            Task<IEnumerable<ProviderResponseDto>> GetProvidersAsync();
            Task<ProviderResponseDto> GetProviderByIdAsync(int providerId);
            Task<int> CreateProviderAsync(CreateProviderDto request);
            Task UpdateProviderAsync(int providerId, UpdateProviderDto request);
            Task DeleteProviderAsync(int providerId);
            
    }
}