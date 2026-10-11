using ProviderManage.Models;
using ProviderManagement.API.DTOs;

namespace ProviderManage.Repositories.Interfaces
{
    public interface IProviderRepository
    {
       
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider?> GetByIdAsync(int providerId);
        Task<int> CreateAsync(Provider provider);
        Task UpdateAsync(Provider provider);
        Task DeleteAsync(int providerId);
        
    Task<IEnumerable<Provider>>
    SearchProvidersAsync(string providerName);
    }
}