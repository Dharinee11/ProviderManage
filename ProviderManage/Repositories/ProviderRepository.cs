using ProviderManage.Models;
using ProviderManage.Repositories.Interfaces;

namespace ProviderManage.Repositories
{
    public class ProviderRepository : IProviderRepository
    {
        private static readonly List<Provider> _providers = new()
    {
        new Provider
        {
            ProviderId = 1,
            ProviderName = "Provider One",
            Email = "provider1@test.com",
            PhoneNumber = "9876543210",
            Address = "Ahmedabad"
        },
        new Provider
        {
            ProviderId = 2,
            ProviderName = "Provider Two",
            Email = "provider2@test.com",
            PhoneNumber = "9876543211",
            Address = "Vadodara"
        }
    };

        public Task<IEnumerable<Provider>> GetAllAsync()
        {
            return Task.FromResult(_providers.AsEnumerable());
        }

        public Task<Provider?> GetByIdAsync(int providerId)
        {
            return Task.FromResult(
                _providers.FirstOrDefault(x => x.ProviderId == providerId));
        }

        public Task<int> CreateAsync(Provider provider)
        {
            provider.ProviderId = _providers.Max(x => x.ProviderId) + 1;

            _providers.Add(provider);

            return Task.FromResult(provider.ProviderId);
        }

        public Task UpdateAsync(Provider provider)
        {
            var existing = _providers.FirstOrDefault(
                x => x.ProviderId == provider.ProviderId);

            if (existing != null)
            {
                existing.ProviderName = provider.ProviderName;
                existing.Email = provider.Email;
                existing.PhoneNumber = provider.PhoneNumber;
                existing.Address = provider.Address;
            }

            return Task.CompletedTask;
        }

        public Task DeleteAsync(int providerId)
        {
            var provider =
                _providers.FirstOrDefault(x => x.ProviderId == providerId);

            if (provider != null)
            {
                _providers.Remove(provider);
            }

            return Task.CompletedTask;

        }
        
    public Task<IEnumerable<Provider>>
    SearchProvidersAsync(string providerName)
        {
            var result = _providers.Where(x =>
                x.ProviderName.Contains(
                    providerName,
                    StringComparison.OrdinalIgnoreCase));

            return Task.FromResult(result.AsEnumerable());
        }
    }
}