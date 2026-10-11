namespace ProviderManagement.API.DTOs
{
    public class ProviderResponseDto
    {
        public int ProviderId { get; set; }

        public string ProviderName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        public DateTime CreatedDate { get; set; }
    }
}