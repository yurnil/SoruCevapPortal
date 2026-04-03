using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace SoruCevapPortal.API.Models
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<UserVote> UserVotes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)

        {
            base.OnModelCreating(builder);


            builder.Entity<Answer>()
                .HasOne(a => a.Question)
                .WithMany(q => q.Answers)
                .HasForeignKey(a => a.QuestionId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.Entity<Question>()
                .HasOne(q => q.AppUser)
                .WithMany(u => u.Questions)
                .HasForeignKey(q => q.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Answer>()
                .HasOne(a => a.AppUser)
                .WithMany(u => u.Answers)
                .HasForeignKey(a => a.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.Entity<UserVote>()
                .HasOne(v => v.AppUser)
                .WithMany(u => u.Votes)
                .HasForeignKey(v => v.AppUserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserVote>()
                .HasOne(v => v.Question)
                .WithMany(q => q.Votes)
                .HasForeignKey(v => v.QuestionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<UserVote>()
                .HasOne(v => v.Answer)
                .WithMany(a => a.Votes)
                .HasForeignKey(v => v.AnswerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}