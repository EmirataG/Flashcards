using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Flashcards.MVVM.Model.Context
{
    public class FlashcardsDbContext : DbContext
    {
        public DbSet<Flashcard> Flashcards { get; set; }
        public DbSet<FlashcardSet> FlashcardSets { get; set; }
        public DbSet<User> Users { get; set; }

        public FlashcardsDbContext(DbContextOptions<FlashcardsDbContext> options) : base(options)
        {
            Database.EnsureCreated(); /* must be executed to ensure the database creation */

            ChangeTracker.Tracked += ChangeTracker_Tracked;
        }

        private void ChangeTracker_Tracked(object? sender, EntityTrackedEventArgs e)
        {
            int x = 0;
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Flashcard>()
            //    .HasOne(f => f.FlashcardSet)
            //    .WithMany(fs => fs.Flashcards)
            //    .HasForeignKey(f => f.FlashcardSetId);

            //modelBuilder.Entity<FlashcardSet>()
            //    .HasOne(fs => fs.Creator)
            //    .WithMany(u => u.FlashcardSets)
            //    .HasForeignKey(fs => fs.UserId);

        }

        public FlashcardsDbContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.;Initial Catalog=Flashcards;Integrated Security=True;TrustServerCertificate=True");
        }

    }
}
