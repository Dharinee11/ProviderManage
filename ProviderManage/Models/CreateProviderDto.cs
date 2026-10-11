namespace ProviderManagement.API.DTOs
{
    public class CreateProviderDto
    {
        public string ProviderName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;
    }
}