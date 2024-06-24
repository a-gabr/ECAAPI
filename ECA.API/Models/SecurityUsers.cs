using System.Security.AccessControl;
using Twilio.TwiML.Voice;

namespace ECA.API.Models
{
    [Table("security_users")]
    public partial class SecurityUsers
    {
        public SecurityUsers()
        {
            ComputerUsers = new HashSet<ComputerUser>();
            //RoleSubjects = new HashSet<RoleSubject>();
            //security_groupings = new HashSet<security_groupings>();
            //security_groupings1 = new HashSet<security_groupings>();
            //security_info = new HashSet<security_info>();
        }

        [Key]
        [StringLength(16)]
        public string name { get; set; }

        [Required]
        [StringLength(64)]
        public string description { get; set; }

        public int priority { get; set; }

        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal RoleIsn { get; set; }

        public int? user_type { get; set; }

        public virtual ICollection<ComputerUser> ComputerUsers { get; set; }

        //public virtual ICollection<RoleSubject> RoleSubjects { get; set; }

        //public virtual ICollection<security_groupings> security_groupings { get; set; }

        //public virtual ICollection<security_groupings> security_groupings1 { get; set; }

        //public virtual ICollection<security_info> security_info { get; set; }
        // ---------- Added by Dalia 06.10.2017 ---------- //
        //public groups_apps groups_apps { get; set; }
        // ---------------------------------------------- //
    }
}
