
namespace ECA.API.DTO
{
    public class ComputerUserDto
    {

        //[Key]
        //[Column(TypeName = "numeric")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public decimal UserId { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPID { get; set; }

        public int? DDBIdentification { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SYSWSIsn { get; set; }

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

        //public virtual CustomsDealer CustomsDealer { get; set; }

        //public virtual Employee Employee { get; set; }

        //public virtual security_users security_users { get; set; }
        //[ForeignKey("SYSWSIsn")]
        //public SystemWorkstation? SystemWorkstation { get; set; }

        //public virtual ICollection<ElementartyRecordNote> ElementartyRecordNotes { get; set; }

        //public virtual ICollection<EndUserWorkstationsAssignment> EndUserWorkstationsAssignments { get; set; }

        //public virtual ICollection<InspectionRequestLine> InspectionRequestLines { get; set; }

        //public virtual ICollection<InspectionLineResult> InspectionLineResults { get; set; }

        //public virtual ICollection<security_groupings> security_groupings { get; set; }
    }
}
