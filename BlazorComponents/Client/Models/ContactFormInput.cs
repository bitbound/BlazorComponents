using System.ComponentModel.DataAnnotations;

namespace BlazorComponents.Client.Models
{
    public class ContactFormInput
    {
        [StringLength(50)]
        [Required]
        public string Name { get; set; } = "";

        [EmailAddress]
        [Required]
        public string Email { get; set; } = "";

        [StringLength(2000)]
        [Required]
        public string Message { get; set; } = "";
    }
}
