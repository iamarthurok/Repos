using Microsoft.EntityFrameworkCore;

namespace StudActivDynamicDB
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;
        public DbSet<Activities> Activities { get; set; } = null!;
        public DbSet<StudentActivities> StudentActivities { get; set; } = null!;

        public SchoolContext() { }

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=StudActivDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure Student entity
            modelBuilder.ApplyConfiguration(new StudentConfig());

            // Configure Activities entity
            modelBuilder.Entity<Activities>().HasKey(a => a.ActivityID);
            modelBuilder.Entity<Activities>().Property(a => a.ActivityID).ValueGeneratedOnAdd();
            modelBuilder.Entity<Activities>().Property(a => a.ActivityName).IsRequired();

            // Configure StudentActivities entity
            modelBuilder.Entity<StudentActivities>().HasKey(sa => new { sa.StudentID, sa.ActivityID });
            modelBuilder.Entity<StudentActivities>().Property(sa => sa.StartDate).IsRequired();
            modelBuilder.Entity<StudentActivities>().Property(sa => sa.EndDate).IsRequired();

            // Define relationships
            modelBuilder.Entity<StudentActivities>()
                .HasOne(sa => sa.Student)
                .WithMany(s => s.StudentActivities)
                .HasForeignKey(sa => sa.StudentID);

            modelBuilder.Entity<StudentActivities>()
                .HasOne(sa => sa.Activity)
                .WithMany(a => a.StudentActivities)
                .HasForeignKey(sa => sa.ActivityID);
        }
    }
}
