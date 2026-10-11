using System.ComponentModel.DataAnnotations;
namespace ProviderManage.Models
{
    public class Provider
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string ProviderName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string City { get; set; } = string.Empty;

        public bool IsActive { get; set; }
        
            public int ProviderId { get; set; }

            public string Name { get; set; } = string.Empty;

           

            public string PhoneNumber { get; set; } = string.Empty;

            public string Address { get; set; } = string.Empty;

            public DateTime CreatedDate { get; set; }
        
    }
}