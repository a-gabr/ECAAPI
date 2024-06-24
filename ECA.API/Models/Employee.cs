using Twilio.TwiML.Voice;

namespace ECA.API.Models
{
    [Table("Employee")]
    public class Employee
    {
        public Employee()
        {
            ComputerUsers = new HashSet<ComputerUser>();

            //AccountingUnits = new HashSet<AccountingUnit>();
            //Assessments = new HashSet<Assessment>();
            //Assessments1 = new HashSet<Assessment>();
            //BasicSalaryRaises = new HashSet<BasicSalaryRais>();
            //BOLChangeRequests = new HashSet<BOLChangeRequest>();
            //BOLChangeRequests1 = new HashSet<BOLChangeRequest>();
            //BOLChangeRequests2 = new HashSet<BOLChangeRequest>();
            //BOLTransactions = new HashSet<BOLTransaction>();
            //CarModelInformations = new HashSet<CarModelInformation>();
            //CarModelInformations1 = new HashSet<CarModelInformation>();
            //CashierShifts = new HashSet<CashierShift>();
            //CashierShifts1 = new HashSet<CashierShift>();
            //Commodities = new HashSet<Commodity>();
            //CurrentAccount_org = new HashSet<CurrentAccount_org>();
            //CurrentAccountTransactions = new HashSet<CurrentAccountTransaction>();
            //CustomsDealers = new HashSet<CustomsDealer>();
            //CustomsDealers1 = new HashSet<CustomsDealer>();
            //CustomsDealers2 = new HashSet<CustomsDealer>();
            //DCRTNChangeRequests = new HashSet<DCRTNChangeRequest>();
            //DCRTNChangeRequests1 = new HashSet<DCRTNChangeRequest>();
            //DCRTNTransactions = new HashSet<DCRTNTransaction>();
            //DCRTNTransactions1 = new HashSet<DCRTNTransaction>();
            //DeclarationBOLItems = new HashSet<DeclarationBOLItem>();
            //DeclarationExtensions = new HashSet<DeclarationExtension>();
            //DeclarationExtensions1 = new HashSet<DeclarationExtension>();
            //DeclarationExtensions2 = new HashSet<DeclarationExtension>();
            //Decrees = new HashSet<Decree>();
            //DiscrepancyEventLines = new HashSet<DiscrepancyEventLine>();
            //DocumentAccountTransactions = new HashSet<DocumentAccountTransaction>();
            //DocumentAssignedEmployeeChanges = new HashSet<DocumentAssignedEmployeeChange>();
            //DocumentAssignedEmployeeChanges1 = new HashSet<DocumentAssignedEmployeeChange>();
            //DocumentAssignedEmployeeChanges2 = new HashSet<DocumentAssignedEmployeeChange>();
            //DocumentAssignedEmployees = new HashSet<DocumentAssignedEmployee>();
            //DutyShiftTables = new HashSet<DutyShiftTable>();
            //ElementartyRecordNotes = new HashSet<ElementartyRecordNote>();
            //EmpAttendances = new HashSet<EmpAttendance>();
            //EmpExperinces = new HashSet<EmpExperince>();
            //EmployeeEducations = new HashSet<EmployeeEducation>();
            //Employee1 = new HashSet<Employee>();
            //EmployeeDebits = new HashSet<EmployeeDebit>();
            //EmployeeSelectionPools = new HashSet<EmployeeSelectionPool>();
            //LetterOfGuaranteeTransactions = new HashSet<LetterOfGuaranteeTransaction>();
            //EmploymentContracts = new HashSet<EmploymentContract>();
            //ExprtInspectionForms = new HashSet<ExprtInspectionForm>();
            //ExprtInspectionForms1 = new HashSet<ExprtInspectionForm>();
            //FinancialDocumentBooklets = new HashSet<FinancialDocumentBooklet>();
            //FZInvestmentLicenses = new HashSet<FZInvestmentLicense>();
            //LandCarrierTransactions = new HashSet<LandCarrierTransaction>();
            //GeneralRevenueDocuments = new HashSet<GeneralRevenueDocument>();
            //GeneralRevenueDocuments1 = new HashSet<GeneralRevenueDocument>();
            //GoeicEmployees = new HashSet<GoeicEmployee>();
            //IncomingCarsCards = new HashSet<IncomingCarsCard>();
            //IncomingCarsCards1 = new HashSet<IncomingCarsCard>();
            //InspectedUnclaimeds = new HashSet<InspectedUnclaimed>();
            //Intsructions = new HashSet<Intsruction>();
            //Intsructions1 = new HashSet<Intsruction>();
            //JobHistories = new HashSet<JobHistory>();
            //LandCarrierTransactions1 = new HashSet<LandCarrierTransaction>();
            //ReceivalLetterOfGuarantees = new HashSet<LetterOfGuarantee>();
            //ApprovalLetterOfGuarantees = new HashSet<LetterOfGuarantee>();
            //Loans = new HashSet<Loan>();
            //Loans1 = new HashSet<Loan>();
            //LoanTransactions = new HashSet<LoanTransaction>();
            //MilitaryStatus = new HashSet<MilitaryStatu>();
            //MoneyPaymentDocuments = new HashSet<MoneyPaymentDocument>();
            //MoneyPaymentDocuments1 = new HashSet<MoneyPaymentDocument>();
            //MoneyReceiptProofDocuments = new HashSet<MoneyReceiptProofDocument>();
            //MoneyRevenueDocuments = new HashSet<MoneyRevenueDocument>();
            //MonthlyExemptionBalances = new HashSet<MonthlyExemptionBalance>();
            //PassengerDeclartions = new HashSet<PassengerDeclartion>();
            //PassengerDeclartions1 = new HashSet<PassengerDeclartion>();
            //PaymentApprovalDocuments = new HashSet<PaymentApprovalDocument>();
            //PaymentApprovalDocuments1 = new HashSet<PaymentApprovalDocument>();
            //PaymentApprovalDocuments2 = new HashSet<PaymentApprovalDocument>();
            //PaymentApprovalDocuments3 = new HashSet<PaymentApprovalDocument>();
            //PaymentApprovalDocuments4 = new HashSet<PaymentApprovalDocument>();
            //Pendings = new HashSet<Pending>();
            //PREmployeePaymentForms = new HashSet<PREmployeePaymentForm>();
            //PricingDocuments = new HashSet<PricingDocument>();
            //PricingDocuments1 = new HashSet<PricingDocument>();
            //PricingDocumentLines = new HashSet<PricingDocumentLine>();
            //Punishments = new HashSet<Punishment>();
            //Retirements = new HashSet<Retirement>();
            //SeijureOrders = new HashSet<SeijureOrder>();
            //Seniorities = new HashSet<Seniority>();
            //SmReport_Employee = new HashSet<SmReport_Employee>();
            //SocialSecurityStatements = new HashSet<SocialSecurityStatement>();
            //SocialSecurityStatements1 = new HashSet<SocialSecurityStatement>();
            //Stores = new HashSet<Store>();
            //StoringOrders = new HashSet<StoringOrder>();
            //SubjectStateTransitionHistories = new HashSet<SubjectStateTransitionHistory>();
            //TariffEmployeeExperiences = new HashSet<TariffEmployeeExperience>();
            //TariffModificationRequests = new HashSet<TariffModificationRequest>();
            //TariffModificationRequests1 = new HashSet<TariffModificationRequest>();
            //TASquaringRequests = new HashSet<TASquaringRequest>();
            //TASquaringRequests1 = new HashSet<TASquaringRequest>();
            //TASquaringRequests2 = new HashSet<TASquaringRequest>();
            //TaxRebatRequests = new HashSet<TaxRebatRequest>();
            //TaxRebatRequests1 = new HashSet<TaxRebatRequest>();
            //MoneyPaymentDocuments2 = new HashSet<MoneyPaymentDocument>();
            //Trainings = new HashSet<Training>();
            //TransportRequests = new HashSet<TransportRequest>();
            //Tributes = new HashSet<Tribute>();
            //Vacations = new HashSet<Vacation>();
            //VacationBalances = new HashSet<VacationBalance>();
            //Vacations1 = new HashSet<Vacation>();
            //Vacations2 = new HashSet<Vacation>();
            //VariableIncomeBalances = new HashSet<VariableIncomeBalance>();
            //WarehouseInventoryEvents = new HashSet<WarehouseInventoryEvent>();
            //WarehouseTransferDocuments = new HashSet<WarehouseTransferDocument>();
            //WareHouseStockDestroyDocuments = new HashSet<WareHouseStockDestroyDocument>();
            //WarehouseDeliveryDocuments = new HashSet<WarehouseDeliveryDocument>();
            //WarehouseInventoryEvents1 = new HashSet<WarehouseInventoryEvent>();
            //WarehouseReceivalDocuments = new HashSet<WarehouseReceivalDocument>();
            //Tips = new HashSet<Tip>();
            //Stores1 = new HashSet<Store>();
        }

        [Key]
        [Column(TypeName = "numeric")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public decimal EMPIsn { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? DataEntryEMPIsn { get; set; }

        public short? SSEmpCode { get; set; }

        public int? DDBIdentification { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CDLRIsn { get; set; }

        [StringLength(60)]
        public string EMPName { get; set; }

        [StringLength(14)]
        public string EMPSSN { get; set; }

        [StringLength(14)]
        public string EMPIns { get; set; }
        public DateTime? EMPEmployDate { get; set; }
        public short? EMPEmployType { get; set; }
        public short? EMPDutyType { get; set; }
        public DateTime? EMPStartDate { get; set; }
        public DateTime? EMPConfirmDate { get; set; }
        public short? EMPReEmployRsn { get; set; }
        public DateTime? EMPExpctdRetmntDate { get; set; }
        public short? EMPSex { get; set; }
        public decimal? EMPIdCardNo { get; set; }
        public short? EMPIdCardType { get; set; }
        public DateTime? EMPIdCardIssDate { get; set; }

        [StringLength(40)]
        public string EMPIdCardIssPlace { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPPassport { get; set; }
        public DateTime? EMPPassportDT { get; set; }

        [StringLength(3)]
        public string EMPBloodType { get; set; }
        public DateTime? EMPBirthDate { get; set; }
        public short? EMPBirthPlace { get; set; }

        [StringLength(40)]
        public string EMPSpoHsbName1 { get; set; }

        [StringLength(40)]
        public string EMPSpoHsbName2 { get; set; }
        public short? EMPHsbStatus { get; set; }

        [StringLength(40)]
        public string EMPMotherName { get; set; }

        [StringLength(60)]
        public string EMPAddress { get; set; }
        public short? EMPGovernrate { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPPhoneH { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPPhoneO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? EMPMobile { get; set; }

        [StringLength(60)]
        public string EMPEmail { get; set; }

        public short? EMPReligion { get; set; }

        public short? EMPHealthStatus { get; set; }

        public double? EMPExmptSalary { get; set; }

        public double? EMPCurrentSalary { get; set; }

        [StringLength(25)]
        public string EMPBnkAccNo { get; set; }
        public double? EMPFrnkSalary { get; set; }
        public DateTime? EMPCurJobRnkDt { get; set; }
        public short? EMPCurJobRnk { get; set; }
        public short? EMPRelRank { get; set; }
        public short? EMPDecFRnk { get; set; }
        public int? EMPCurUnit { get; set; }
        public short? QGClassification { get; set; }
        public int? QGCode { get; set; }
        public short? EMPJobCode { get; set; }
        public DateTime? EMPRecordRevisedAt { get; set; }

        [StringLength(60)]
        public string EMPRemarks { get; set; }

        [StringLength(60)]
        public string EMPSignatureFile { get; set; }

        [StringLength(60)]
        public string EMPPhotoFile { get; set; }
        public short? EMPCrs { get; set; }
        public DateTime? SeniorityRelativeDate { get; set; }
        public int? xcode { get; set; }
        
        [Column(TypeName = "numeric")]
        public decimal? AUIsn { get; set; }

        [StringLength(32)]
        public string UnitExtCode { get; set; }
        public short? EMPMilitaryPublicServ { get; set; }
        public double? EMPAlimony { get; set; }
        public int? xcode_old { get; set; }
        public decimal? DEIsn { get; set; }
        public int? DEDDBIdentification { get; set; }
        public int? EMPFullSalaryIndecator { get; set; }
        public DateTime? TS_date { get; set; }
        public virtual ICollection<ComputerUser> ComputerUsers { get; set; }


        //[Column("DEISN")]
        //public decimal? DEISN1 { get; set; }
        //public virtual ICollection<AccountingUnit> AccountingUnits { get; set; }
        //public virtual ICollection<Assessment> Assessments { get; set; }
        //public virtual ICollection<Assessment> Assessments1 { get; set; }
        //public virtual ICollection<BasicSalaryRais> BasicSalaryRaises { get; set; }
        //public virtual ICollection<BOLChangeRequest> BOLChangeRequests { get; set; }
        //public virtual ICollection<BOLChangeRequest> BOLChangeRequests1 { get; set; }
        //public virtual ICollection<BOLChangeRequest> BOLChangeRequests2 { get; set; }
        //public virtual ICollection<BOLTransaction> BOLTransactions { get; set; }
        //public virtual ICollection<CarModelInformation> CarModelInformations { get; set; }
        //public virtual ICollection<CarModelInformation> CarModelInformations1 { get; set; }
        //public virtual ICollection<CashierShift> CashierShifts { get; set; }
        //public virtual ICollection<CashierShift> CashierShifts1 { get; set; }
        //public virtual ICollection<Commodity> Commodities { get; set; }
        //public virtual ICollection<CurrentAccount_org> CurrentAccount_org { get; set; }
        //public virtual ICollection<CurrentAccountTransaction> CurrentAccountTransactions { get; set; }
        //public virtual ICollection<CustomsDealer> CustomsDealers { get; set; }
        //public virtual ICollection<CustomsDealer> CustomsDealers1 { get; set; }
        //public virtual ICollection<CustomsDealer> CustomsDealers2 { get; set; }
        //public virtual ICollection<DCRTNChangeRequest> DCRTNChangeRequests { get; set; }
        //public virtual ICollection<DCRTNChangeRequest> DCRTNChangeRequests1 { get; set; }
        //public virtual ICollection<DCRTNTransaction> DCRTNTransactions { get; set; }
        //public virtual ICollection<DCRTNTransaction> DCRTNTransactions1 { get; set; }
        //public virtual ICollection<DeclarationBOLItem> DeclarationBOLItems { get; set; }
        //public virtual ICollection<DeclarationExtension> DeclarationExtensions { get; set; }
        //public virtual ICollection<DeclarationExtension> DeclarationExtensions1 { get; set; }
        //public virtual ICollection<DeclarationExtension> DeclarationExtensions2 { get; set; }
        //public virtual ICollection<Decree> Decrees { get; set; }
        //public virtual ICollection<DiscrepancyEventLine> DiscrepancyEventLines { get; set; }
        //public virtual ICollection<DocumentAccountTransaction> DocumentAccountTransactions { get; set; }
        //public virtual ICollection<DocumentAssignedEmployeeChange> DocumentAssignedEmployeeChanges { get; set; }
        //public virtual ICollection<DocumentAssignedEmployeeChange> DocumentAssignedEmployeeChanges1 { get; set; }
        //public virtual ICollection<DocumentAssignedEmployeeChange> DocumentAssignedEmployeeChanges2 { get; set; }
        //public virtual ICollection<DocumentAssignedEmployee> DocumentAssignedEmployees { get; set; }
        //public virtual ICollection<DutyShiftTable> DutyShiftTables { get; set; }
        //public virtual ICollection<ElementartyRecordNote> ElementartyRecordNotes { get; set; }
        //public virtual ICollection<EmpAttendance> EmpAttendances { get; set; }
        //public virtual ICollection<EmpExperince> EmpExperinces { get; set; }
        //public virtual ICollection<EmployeeEducation> EmployeeEducations { get; set; }
        //public virtual ICollection<Employee> Employee1 { get; set; }
        //public virtual Employee Employee2 { get; set; }
        //public virtual ICollection<EmployeeDebit> EmployeeDebits { get; set; }
        //public virtual EmployeeSubscription EmployeeSubscription { get; set; }
        //public virtual ICollection<EmployeeSelectionPool> EmployeeSelectionPools { get; set; }
        //public virtual ICollection<LetterOfGuaranteeTransaction> LetterOfGuaranteeTransactions { get; set; }
        //public virtual SocialStatu SocialStatu { get; set; }
        //public virtual ICollection<EmploymentContract> EmploymentContracts { get; set; }
        //public virtual ICollection<ExprtInspectionForm> ExprtInspectionForms { get; set; }
        //public virtual ICollection<ExprtInspectionForm> ExprtInspectionForms1 { get; set; }
        //public virtual ICollection<FinancialDocumentBooklet> FinancialDocumentBooklets { get; set; }
        //public virtual ICollection<FZInvestmentLicense> FZInvestmentLicenses { get; set; }
        //public virtual ICollection<LandCarrierTransaction> LandCarrierTransactions { get; set; }
        //public virtual ICollection<GeneralRevenueDocument> GeneralRevenueDocuments { get; set; }
        //public virtual ICollection<GeneralRevenueDocument> GeneralRevenueDocuments1 { get; set; }
        //public virtual ICollection<GoeicEmployee> GoeicEmployees { get; set; }
        //public virtual ICollection<IncomingCarsCard> IncomingCarsCards { get; set; }
        //public virtual ICollection<IncomingCarsCard> IncomingCarsCards1 { get; set; }
        //public virtual ICollection<InspectedUnclaimed> InspectedUnclaimeds { get; set; }
        //public virtual ICollection<Intsruction> Intsructions { get; set; }
        //public virtual ICollection<Intsruction> Intsructions1 { get; set; }
        //public virtual ICollection<JobHistory> JobHistories { get; set; }
        //public virtual ICollection<LandCarrierTransaction> LandCarrierTransactions1 { get; set; }
        //public virtual ICollection<LetterOfGuarantee> ReceivalLetterOfGuarantees { get; set; } // Added by Dalia
        //public virtual ICollection<LetterOfGuarantee> ApprovalLetterOfGuarantees { get; set; } // Added by Dalia
        //public virtual ICollection<Loan> Loans { get; set; }
        //public virtual ICollection<Loan> Loans1 { get; set; }
        //public virtual ICollection<LoanTransaction> LoanTransactions { get; set; }
        //public virtual MilitaryStatu MilitaryStatu { get; set; }
        //public virtual ICollection<MilitaryStatu> MilitaryStatus { get; set; }
        //public virtual ICollection<MoneyPaymentDocument> MoneyPaymentDocuments { get; set; }
        //public virtual ICollection<MoneyPaymentDocument> MoneyPaymentDocuments1 { get; set; }
        //public virtual ICollection<MoneyReceiptProofDocument> MoneyReceiptProofDocuments { get; set; }
        //public virtual ICollection<MoneyRevenueDocument> MoneyRevenueDocuments { get; set; }
        //public virtual ICollection<MonthlyExemptionBalance> MonthlyExemptionBalances { get; set; }
        //public virtual ICollection<PassengerDeclartion> PassengerDeclartions { get; set; }
        //public virtual ICollection<PassengerDeclartion> PassengerDeclartions1 { get; set; }
        //public virtual ICollection<PaymentApprovalDocument> PaymentApprovalDocuments { get; set; }
        //public virtual ICollection<PaymentApprovalDocument> PaymentApprovalDocuments1 { get; set; }
        //public virtual ICollection<PaymentApprovalDocument> PaymentApprovalDocuments2 { get; set; }
        //public virtual ICollection<PaymentApprovalDocument> PaymentApprovalDocuments3 { get; set; }
        //public virtual ICollection<PaymentApprovalDocument> PaymentApprovalDocuments4 { get; set; }
        //public virtual ICollection<Pending> Pendings { get; set; }
        //public virtual ICollection<PREmployeePaymentForm> PREmployeePaymentForms { get; set; }
        //public virtual ICollection<PricingDocument> PricingDocuments { get; set; }
        //public virtual ICollection<PricingDocument> PricingDocuments1 { get; set; }
        //public virtual ICollection<PricingDocumentLine> PricingDocumentLines { get; set; }
        //public virtual ICollection<Punishment> Punishments { get; set; }
        //public virtual ICollection<Retirement> Retirements { get; set; }
        //public virtual ICollection<SeijureOrder> SeijureOrders { get; set; }
        //public virtual ICollection<Seniority> Seniorities { get; set; }
        //public virtual ICollection<SmReport_Employee> SmReport_Employee { get; set; }
        //public virtual ICollection<SocialSecurityStatement> SocialSecurityStatements { get; set; }
        //public virtual ICollection<SocialSecurityStatement> SocialSecurityStatements1 { get; set; }
        //public virtual ICollection<Store> Stores { get; set; }
        //public virtual ICollection<StoringOrder> StoringOrders { get; set; }
        //public virtual ICollection<SubjectStateTransitionHistory> SubjectStateTransitionHistories { get; set; }
        //public virtual ICollection<TariffEmployeeExperience> TariffEmployeeExperiences { get; set; }
        //public virtual ICollection<TariffModificationRequest> TariffModificationRequests { get; set; }
        //public virtual ICollection<TariffModificationRequest> TariffModificationRequests1 { get; set; }
        //public virtual ICollection<TASquaringRequest> TASquaringRequests { get; set; }
        //public virtual ICollection<TASquaringRequest> TASquaringRequests1 { get; set; }
        //public virtual ICollection<TASquaringRequest> TASquaringRequests2 { get; set; }
        //public virtual ICollection<TaxRebatRequest> TaxRebatRequests { get; set; }
        //public virtual ICollection<TaxRebatRequest> TaxRebatRequests1 { get; set; }
        //public virtual ICollection<MoneyPaymentDocument> MoneyPaymentDocuments2 { get; set; }
        //public virtual ICollection<Training> Trainings { get; set; }
        //public virtual ICollection<TransportRequest> TransportRequests { get; set; }
        //public virtual ICollection<Tribute> Tributes { get; set; }
        //public virtual ICollection<Vacation> Vacations { get; set; }
        //public virtual ICollection<VacationBalance> VacationBalances { get; set; }
        //public virtual ICollection<Vacation> Vacations1 { get; set; }
        //public virtual ICollection<Vacation> Vacations2 { get; set; }
        //public virtual ICollection<VariableIncomeBalance> VariableIncomeBalances { get; set; }
        //public virtual ICollection<WarehouseInventoryEvent> WarehouseInventoryEvents { get; set; }
        //public virtual ICollection<WarehouseTransferDocument> WarehouseTransferDocuments { get; set; }
        //public virtual ICollection<WareHouseStockDestroyDocument> WareHouseStockDestroyDocuments { get; set; }
        //public virtual ICollection<WarehouseDeliveryDocument> WarehouseDeliveryDocuments { get; set; }
        //public virtual ICollection<WarehouseInventoryEvent> WarehouseInventoryEvents1 { get; set; }
        //public virtual ICollection<WarehouseReceivalDocument> WarehouseReceivalDocuments { get; set; }
        //public virtual ICollection<Tip> Tips { get; set; }
        //public virtual ICollection<Store> Stores1 { get; set; }
    }
}
