using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ECA.API.Models
{
    [Table("ComputerUser")]
    public class ComputerUser
    {
        public ComputerUser()
        {
            //ElementartyRecordNotes = new HashSet<ElementartyRecordNote>();
            //EndUserWorkstationsAssignments = new HashSet<EndUserWorkstationsAssignment>();
            //InspectionRequestLines = new HashSet<InspectionRequestLine>();
            //InspectionLineResults = new HashSet<InspectionLineResult>();
            //security_groupings = new HashSet<security_groupings>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal UserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPID { get; set; }

        public int? DDBIdentification { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SYSWSIsn { get; set; }

        [Required]
        [StringLength(16)]
        public string name { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UserPasswordTypeCode { get; set; }

        [StringLength(9)]
        public string? UserPassword { get; set; } = string.Empty;

        public DateTime? UserPasswordEndDate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UserEventsLoggingFlag { get; set; }

        public DateTime? UserEventsLoggingBeginDT { get; set; }

        public DateTime? UserEventsLoggingEndDT { get; set; }

        public DateTime? UserLastLoginDateTime { get; set; }

        public DateTime? UserLastLogoutDateTime { get; set; }

        [StringLength(60)]
        public string? UserRemarks { get; set; } = string.Empty;

        public short? UserWorkStValidateFlag { get; set; }

        public short? Rsc { get; set; }

        [StringLength(60)]
        public string? UserPasswordEncrypted { get; set; } = string.Empty;

        [Column(TypeName = "numeric")]
        public decimal? GEMPIsn { get; set; }

        public int? GEMPDDBIdentification { get; set; }

       //[ForeignKey("CDLRIsn")]
        public CustomsDealer CustomsDealer { get; set; }

        [ForeignKey("EMPID")]
        public  Employee Employee { get; set; }

        [ForeignKey("name")]
        public SecurityUsers security_users { get; set; }
        [ForeignKey("SYSWSIsn")]
        public SystemWorkstation? SystemWorkstation { get; set; }

        //public virtual ICollection<ElementartyRecordNote> ElementartyRecordNotes { get; set; }

        //public virtual ICollection<EndUserWorkstationsAssignment> EndUserWorkstationsAssignments { get; set; }

        //public virtual ICollection<InspectionRequestLine> InspectionRequestLines { get; set; }

        //public virtual ICollection<InspectionLineResult> InspectionLineResults { get; set; }

        //public virtual ICollection<security_groupings> security_groupings { get; set; }
    }
}
