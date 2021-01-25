using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TOTVSChallenge.Domain.Entities;
using TOTVSChallenge.Respository.Database.Seed;

namespace TOTVSChallenge.Respository.Database.Context
{
    public class TOTVSChallengeContext: DbContext
    {

        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> User { get; set; }

        public TOTVSChallengeContext(DbContextOptions<TOTVSChallengeContext> options)
            :base(options)
        {
            Database.Migrate();
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Auction>().HasKey(m => m.Id);
            modelBuilder.Entity<Auction>().HasOne(m => m.UserReference).WithOne(x => x.AuctionReference).HasForeignKey<Auction>(o => o.UserId);
            modelBuilder.Entity<Auction>().Property(p => p.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Auction>()
            .HasIndex(p => p.UserId)
            .IsUnique(false);




            modelBuilder.Entity<User>().HasKey(m => m.Id);

            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
      
    }
}
