using Newtonsoft.Json;

namespace ECA.API.DTO
{
    public class ActivateDto
    {
        [Required]
        public string UserName { get; set; }

        //[EmailAddress]
        //public string? Email { get; set; }=null;
        //public string? Mobile { get; set; }

        [Required]
        public string Otp { get; set; }
    }
}