using ProviderManage.Models;

namespace ProviderManage.Repositories.Interfaces
{
    public interface IProviderRepository
    {
       
        Task<IEnumerable<Provider>> GetAllAsync();
        Task<Provider?> GetByIdAsync(int providerId);
        Task<int> CreateAsync(Provider provider);
        Task UpdateAsync(Provider provider);
        Task DeleteAsync(int providerId);
    }
}