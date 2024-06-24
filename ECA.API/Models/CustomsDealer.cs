using System.Xml.Linq;
using Twilio.TwiML.Voice;

namespace ECA.API.Models
{
    [Table("CustomsDealer")]
    public class CustomsDealer
    {
        public CustomsDealer()
        {
            ComputerUsers = new HashSet<ComputerUser>();
            //APPLYDeclarations = new HashSet<Declaration>();
            //IMPRTDeclarations = new HashSet<Declaration>();
            //MoneyRevenueDocuments = new HashSet<MoneyRevenueDocument>();
            //MoneyRevenueDocumentsBank = new HashSet<MoneyRevenueDocument>();
        }
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DDBIdentification { get; set; }

        [Key]
        [Column(Order = 1, TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal CDLRIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ApprovingEMPID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CTRYIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CITYIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CUSTIsn { get; set; }

        public int? ParentDDBIdentification { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? ParentCDLRIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CELIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRNumber { get; set; }

        [Required]
        [StringLength(40)]
        public string CDLRArabicName { get; set; }

        [StringLength(40)]
        public string CDLRTradeName { get; set; }

        [Required]
        [StringLength(80)]
        public string CDLRAddress { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRPhone { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRFax { get; set; }

        [StringLength(30)]
        public string CDLREmailAddress { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPIsn { get; set; }

        public double? CDLRCapital { get; set; }

        public int? CDLRTarrifAreaCode { get; set; }

        public short? CDLRActualRepresentCnt { get; set; }

        public DateTime? CDLRDataEntryApprovalStamp { get; set; }

        public DateTime? CDLRHqApprovalStamp { get; set; }

        [StringLength(25)]
        public string CDLRDealerCardReceivedBy { get; set; }

        public short? CDLRCustDealerCardPrintCnt { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LastCUSTIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CCTIsn { get; set; }

        public DateTime LastUpdateDate { get; set; }

        public DateTime? CDLRDealerCardDeliveryDate { get; set; }

        [StringLength(30)]
        public string CDLRFileArchiveLocation { get; set; }

        [StringLength(60)]
        public string CDLRRemarks { get; set; }

        public short? CDLRCrs { get; set; }

        public int? Rli { get; set; }

        public short? Rdl { get; set; }

        public short? Rsc { get; set; }

        [StringLength(60)]
        public string CDLRDealerWebURL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRDealerMobile { get; set; }

        [StringLength(80)]
        public string CDLRInternetSite { get; set; }

        public decimal? CDLRMobileNo { get; set; }

        public decimal? GOVAIsn { get; set; }

        [StringLength(30)]
        public string CDLRTaxCardNo { get; set; }

        [StringLength(30)]
        public string CDLRCommercialBookNo { get; set; }

        public short? CDLRDealingMethod { get; set; }

        public short? CDLRAppositenessLong { get; set; }

        public decimal? CDLRDiscountPercentage { get; set; }

        public decimal? CDLRDiscountAmount { get; set; }

        public decimal? CDLRGuaranteeLimit { get; set; }

        public DateTime? TS_date { get; set; }

        //[Column("CDLRinternetSite")]
        //[StringLength(80)]
        //public string CDLRinternetSite1 { get; set; }

        public DateTime? Temp_date { get; set; }

        [StringLength(7)]
        public string AirSitaCode { get; set; }

        public short? CDLRDeleg { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PersonalID { get; set; }

        [StringLength(20)]
        public string PersonalIDReleased { get; set; }

        public DateTime? PersonalIDDateReleased { get; set; }

        public short? MortgagorCDLR { get; set; }

        public decimal? AmountOFIndebtedness { get; set; }

        //public virtual City City { get; set; }

        //public virtual ClassificationCategoryTree ClassificationCategoryTree { get; set; }

        //public virtual CompanyEstablishingLaw CompanyEstablishingLaw { get; set; }

        //public virtual Country Country { get; set; }

        //public virtual CustomsPost CustomsPost { get; set; }

        //public virtual CustomsPost CustomsPost1 { get; set; }

        //public virtual DistributedDataBase DistributedDataBase { get; set; }

        //public virtual Employee Employee { get; set; }

        //public virtual Employee Employee1 { get; set; }

        //public virtual Employee Employee2 { get; set; }
        //public virtual ICollection<MoneyRevenueDocument> MoneyRevenueDocuments { get; set; } // Added by Dalia

        //public virtual ICollection<MoneyRevenueDocument> MoneyRevenueDocumentsBank { get; set; } // Added by Dalia
        public ICollection<ComputerUser> ComputerUsers { get; set; } // Added by Dalia 17.10.2020
        //public virtual ICollection<Declaration> APPLYDeclarations { get; set; }

        //public virtual ICollection<Declaration> IMPRTDeclarations { get; set; }

    }
}
