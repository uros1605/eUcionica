using Microsoft.EntityFrameworkCore;
using EntityLib;
using System.Reflection.Emit;

namespace DBContext
{
    public class DBContextClass : DbContext
    {

        public DbSet<Predmet> Predmet { get; set; }
        public DbSet<Nivo> Nivo { get; set; }
        public DbSet<Oblast> Oblast { get; set; }
        public DbSet<Pitanje> Pitanje { get; set; }


        public DBContextClass(DbContextOptions<DBContextClass> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Predmet>()
                .Property(p => p.Naziv)
                .IsRequired();
            modelBuilder.Entity<Pitanje>()
                .Property(p => p.Tekst)
                .IsRequired();
            modelBuilder.Entity<Pitanje>()
                .Property(p => p.Odgovor)
                .IsRequired();
            modelBuilder.Entity<Pitanje>()
             .Property(p => p.NivoID)
             .IsRequired();
            modelBuilder.Entity<Pitanje>()
              .Property(p => p.OblastID)
              .IsRequired();
            modelBuilder.Entity<Pitanje>()
               .Property(p => p.PredmetID)
               .IsRequired();


            modelBuilder.Entity<Oblast>()
               .Property(o => o.Naziv)
               .IsRequired();
            modelBuilder.Entity<Oblast>()
               .Property(o => o.PredmetID)
               .IsRequired();

            modelBuilder.Entity<Nivo>()
               .Property(n => n.Naziv)
               .IsRequired();
            


            modelBuilder.Entity<Predmet>()
                .HasMany(s => s.PitanjazaPredmet).WithOne(p => p.Predmet).HasForeignKey(p => p.PredmetID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Predmet>()
                .HasMany(s => s.OblastzaPredmet).WithOne(p => p.Predmet).HasForeignKey(p => p.PredmetID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Oblast>()
                .HasMany(s => s.OblastzaPitanje).WithOne(p => p.Oblast).HasForeignKey(p => p.OblastID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Nivo>()
                .HasMany(s => s.NivozaPitanje).WithOne(p => p.Nivo).HasForeignKey(p => p.NivoID)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}