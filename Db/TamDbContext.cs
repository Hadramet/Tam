using Microsoft.EntityFrameworkCore;
using Tam.webapp.Models;

namespace Tam.webapp.Db
{

    public sealed class TamDbContext : DbContext
    {
        public  DbSet<PlayList> PlayLists { get; set; }
        public  DbSet<Track> Tracks { get; set; }
        public  DbSet<TrackPlayList>  TrackPlayLists { get; set; }

        public TamDbContext(DbContextOptions<TamDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Many to Many
            modelBuilder.Entity<TrackPlayList>()
                .HasKey(bc => new { bc.TrackId, bc.PlayListId });

            modelBuilder.Entity<TrackPlayList>()
                .HasOne(tp => tp.Track)
                .WithMany(t => t.TrackPlayLists)
                .HasForeignKey(tp => tp.TrackId);

            modelBuilder.Entity<TrackPlayList>()
                .HasOne(tp => tp.PlayList)
                .WithMany(p => p.TrackPlayLists)
                .HasForeignKey(tp => tp.PlayListId);
        }
    }

}
