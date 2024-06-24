using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;

namespace ECA.API.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("DefaultConnection");
        //}
        public DbSet<ComputerUser> ComputerUsers { get; set; }
        public DbSet<CustomsDealer> CustomsDealers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<SystemWorkstation> SystemWorkstations { get; set; }
        public DbSet<SecurityUsers> securityUsers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region ComputerUser
            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.UserId)
                .HasPrecision(9, 0);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.EMPID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.CDLRIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.SYSWSIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.UserPasswordTypeCode)
                .HasPrecision(1, 0);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.UserPassword)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.UserEventsLoggingFlag)
                .HasPrecision(1, 0);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.UserRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.UserPasswordEncrypted)
                .IsUnicode(false);

            modelBuilder.Entity<ComputerUser>()
                .Property(e => e.GEMPIsn)
                .HasPrecision(9, 0);

            //modelBuilder.Entity<ComputerUser>()
            //    .HasMany(e => e.EndUserWorkstationsAssignments)
            //    .WithRequired(e => e.ComputerUser)
            //    .WillCascadeOnDelete(false);            
            #endregion
            #region CustomsDealer
            modelBuilder.Entity<CustomsDealer>()
                .HasKey(e => new { e.DDBIdentification, e.CDLRIsn });

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.EMPID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.ApprovingEMPID)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CTRYIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CITYIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CUSTIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.ParentCDLRIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CELIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRNumber)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRArabicName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRTradeName)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRPhone)
                .HasPrecision(15, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRFax)
                .HasPrecision(15, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLREmailAddress)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.EMPIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRDealerCardReceivedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.LastCUSTIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CCTIsn)
                .HasPrecision(9, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRFileArchiveLocation)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRRemarks)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRDealerWebURL)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRDealerMobile)
                .HasPrecision(15, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRInternetSite)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRMobileNo)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.GOVAIsn)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRTaxCardNo)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRCommercialBookNo)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRDiscountPercentage)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRDiscountAmount)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.CDLRGuaranteeLimit)
                .HasPrecision(18, 6);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.AirSitaCode)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.PersonalID)
                .HasPrecision(14, 0);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.PersonalIDReleased)
                .IsUnicode(false);

            modelBuilder.Entity<CustomsDealer>()
                .Property(e => e.AmountOFIndebtedness)
                .HasPrecision(18, 6);

            //modelBuilder.Entity<CustomsDealer>() // Added by Dalia
            //    .HasMany(e => e.APPLYDeclarations)
            //    .WithRequired(e => e.APPLYCustomsDealer)
            //    .HasForeignKey(e => new { e.APPLYDDBIdentification, e.APPLYCDLRIsn })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CustomsDealer>() // Added by Dalia
            //    .HasMany(e => e.IMPRTDeclarations)
            //    .WithRequired(e => e.IMPRTCustomsDealer)
            //    .HasForeignKey(e => new { e.IMPRTRDDBIdentification, e.IMPRTRCDLRIsn })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CustomsDealer>() //Added by Dalia
            //    .HasMany(e => e.MoneyRevenueDocuments)
            //    .WithRequired(e => e.CustomsDealer)
            //    .HasForeignKey(e => new { e.CDLRDDBIdentification, e.CDLRIsn })
            //    .WillCascadeOnDelete(false);

            //modelBuilder.Entity<CustomsDealer>() //Added by Dalia
            //    .HasMany(e => e.MoneyRevenueDocumentsBank)
            //    .WithRequired(e => e.CustomsDealerBank)
            //    .HasForeignKey(e => new { e.BankDDBIdentification, e.BankCDLRIsn })
            //    .WillCascadeOnDelete(false);

            modelBuilder.Entity<CustomsDealer>() // Added by Dalia 17.10.2020
                .HasMany(e => e.ComputerUsers)
                .WithOne(e => e.CustomsDealer)
                .HasForeignKey(e => new { e.DDBIdentification, e.CDLRIsn })
            .OnDelete(DeleteBehavior.SetNull);

            #endregion
        }
    }
}
