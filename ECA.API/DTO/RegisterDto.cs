namespace ECA.API.DTO
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "يجب ادخال رقم المستخدم"), StringLength(16)]
        [Display(Name = "رقم المستخدم")]
        public string UserNumber { get; set; }

        //[Required(ErrorMessage = "يجب ادخال البريد الإلكتروني")]
        [EmailAddress]
        public string Email { get; set; } = null;

        [Phone]
        public string Mobile { get; set; } = null;

        [StringLength(50)]
        public string Password { get; set; }

        //[Required(ErrorMessage = "يجب تحديد نوع المستخدم")]
        public short UserType { get; set; } = 1; // 1 = Employee    2 = CustomsDealer
    }
}
