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
   
            builder.Entity<Category>().HasData(
               
                new Category { Id = 1, Name = "Teknoloji & Yazılım", Description = "Yazılım dilleri, donanım, yapay zeka ve güncel teknolojiler.", IsActive = true, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 2, Name = "Eğitim & Sınavlar", Description = "Üniversite, akademik kadro ve sınav hazırlıkları.", IsActive = true, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 3, Name = "Kariyer & İş Hayatı", Description = "İş bulma, mülakatlar, CV hazırlama ve ofis yaşamı.", IsActive = true, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 4, Name = "Kültür & Sanat", Description = "Sinema, müzik, edebiyat, oyunlar ve hobiler.", IsActive = true, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 5, Name = "Gündelik Yaşam", Description = "Hayata dair tavsiyeler, yemek mekanları, seyahat ve sohbet.", IsActive = true, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 6, Name = "Web Geliştirme", Description = "ASP.NET Core, React, HTML/CSS projeleri.", IsActive = true, ParentCategoryId = 1, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 7, Name = "Masaüstü & Mobil", Description = "C#, Delphi, Flutter, React Native.", IsActive = true, ParentCategoryId = 1, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 8, Name = "Veritabanı Yönetimi", Description = "SQL Server, MySQL, PostgreSQL.", IsActive = true, ParentCategoryId = 1, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 9, Name = "DGS (Dikey Geçiş Sınavı)", Description = "DGS hazırlık süreci, kontenjanlar ve mühendislik geçişleri.", IsActive = true, ParentCategoryId = 2, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 10, Name = "Erasmus & Yurtdışı", Description = "Yurtdışı staj, dil sınavları ve Avrupa'da eğitim.", IsActive = true, ParentCategoryId = 2, CreatedDate = new DateTime(2026, 4, 3) },
                new Category { Id = 11, Name = "Vize & Final Haftası", Description = "Üniversite dersleri, proje ödevleri ve sunumlar.", IsActive = true, ParentCategoryId = 2, CreatedDate = new DateTime(2026, 4, 3) }
            );
        }
    }
}