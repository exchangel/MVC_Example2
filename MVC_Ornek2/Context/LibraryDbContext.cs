using Microsoft.EntityFrameworkCore;
using MVC_Ornek2.Configurations;
using MVC_Ornek2.Models;

namespace MVC_Ornek2.Context
{
    public class LibraryDbContext : DbContext
    {
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FLUENT API -> kodların veritabanına dönüştürülürken yapılan biçimlendirme işlemleri.

            //modelBuilder.Entity<Operation>().Ignore("Id");
            //modelBuilder.Entity<Operation>().HasKey("StudentId", "BookId");

            //modelBuilder.Entity<Student>().Property(x => x.FirstName).IsRequired();

            //modelBuilder.Entity<Student>().Property(x => x.FirstName).HasMaxLength(30);

            //üsttekileri config klasöründen çekicem

            modelBuilder.ApplyConfiguration(new StudentConfiguration());

            modelBuilder.ApplyConfiguration(new OperationConfiguration());

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Student> Students => Set<Student>();
        public DbSet<Author> Authors => Set<Author>();
        public DbSet<BookType> BookTypes => Set<BookType>();
        public DbSet<Book> Books => Set<Book>();
        public DbSet<Operation> Operations => Set<Operation>();
    }
}
