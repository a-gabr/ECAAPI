namespace ECA.API.DTO
{
    public class SystemWorkstationDto
    {        
        //[Key]
        //[Column(TypeName = "numeric")]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public decimal SYSWSIsn { get; set; }

        public int DDBIdentification { get; set; }

        public int? UnitCode { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CUSTIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CCPXIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CshrIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? STOREIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? GATEIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? UserId { get; set; }

        [Required]
        [StringLength(15)]
        public string SYSWSIdentificationNumber { get; set; }

        [StringLength(25)]
        public string? SYSWSArabicName { get; set; } = string.Empty;

        [Required]
        [StringLength(60)]
        public string SYSWSInstallationPlace { get; set; }

        [StringLength(25)]
        public string? SYSWSPurpose { get; set; } = string.Empty;

        public short SYSWSWorkTypeCode { get; set; }

        public short? Rsc { get; set; }

        public decimal? OLD_DCRTNIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DCRTNIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? WRHSEIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDIsn { get; set; }

        public decimal? WTSTIsn { get; set; }

        //public virtual ICollection<ApplicationServerWorkstation> ApplicationServerWorkstations { get; set; }

        //public virtual Cashier Cashier { get; set; }

        //public virtual ClearanceGate ClearanceGate { get; set; }

        public ICollection<ComputerUser>? ComputerUsers { get; set; }

        //public virtual CustomsComplex CustomsComplex { get; set; }

        //public virtual CustomsPost CustomsPost { get; set; }

        //public virtual DistributedDataBase DistributedDataBase { get; set; }

        //public virtual ICollection<EndUserWorkstationsAssignment> EndUserWorkstationsAssignments { get; set; }

        //public virtual ICollection<Event> Events { get; set; }

        //public virtual OrganizationalUnit OrganizationalUnit { get; set; }

        //public virtual Store Store { get; set; }

        //public virtual ICollection<SubjectLocking> SubjectLockings { get; set; }

        //public virtual Warehouse Warehouse { get; set; }
    }
}
