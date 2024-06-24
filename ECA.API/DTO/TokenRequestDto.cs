namespace ECA.API.DTO
{
    public class TokenRequestDto
    {
        //[Required]
        //public string Email { get; set; }
        [Required]
        public string User { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
