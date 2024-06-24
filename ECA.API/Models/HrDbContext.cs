using Microsoft.EntityFrameworkCore;

namespace ECA.API.Models
{
    public class HrDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public HrDbContext(DbContextOptions<HrDbContext> options):base(options){ }
        public DbSet<MasterRep> MasterReps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region mastrep
            modelBuilder.Entity<MasterRep>()
                .Property(e => e.NO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.NOF)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.NAME)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.adress)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.army_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.bran_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.cer_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.kinde_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.custom_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.deg_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.degkind)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.degree_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.govern)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.relg_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.job_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.mang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.out_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.univ_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.re_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.social_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.NO_NAT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.CARDNO)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.NO_FROM)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.govern_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.govern_cod1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.card_cod)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.B_PLACe)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.busy)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.KINDE)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.job2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.note)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.s)
                .HasPrecision(19, 0);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.language2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.language1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.qulativegroup)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.jobtitles)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.retirement)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.mangid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.degreeid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.degorder)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.jopcodid)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.sec)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.cent)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.genmang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.mang1)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.mang2)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.typ_group)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.first_deg)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.first_typdeg)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.lastgov)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.serialemp)
                .HasPrecision(10, 0);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.first_name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.second_name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.third_name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.fourth_name)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.sector)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<MasterRep>()
                .Property(e => e.central)
                .IsFixedLength()
                .IsUnicode(false);
            #endregion

        }
    }
}
