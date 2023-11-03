using Microsoft.EntityFrameworkCore;

namespace FolderTestApp.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Catalog> Catalogs { get; set; } = null!;
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.Migrate();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>().HasData(
                new Catalog { Id = 1, Name = "Creating Digital Images", ParentId = null},
                
                new Catalog { Id = 2, Name = "Resources", ParentId = 1},
                new Catalog { Id = 3, Name = "Evidence", ParentId = 1},
                new Catalog { Id = 4, Name = "Graphic product", ParentId = 1},
                
                new Catalog { Id = 5, Name = "Primary sources", ParentId = 2},
                new Catalog { Id = 6, Name = "Secondary sources", ParentId = 2},
                
                new Catalog { Id = 7, Name = "Process", ParentId = 4},
                new Catalog { Id = 8, Name = "Final product", ParentId = 4}
                );
        }
    }
}