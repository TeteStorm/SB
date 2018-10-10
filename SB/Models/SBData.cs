namespace SB.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SBData : DbContext
    {
        public SBData()
            : base("name=SBData1")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Classification> Classification { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Gender> Gender { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserSys> UserSys { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Classification>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Gender>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Region>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Region>()
                .HasMany(e => e.City)
                .WithRequired(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserRole>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<UserSys>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<UserSys>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UserSys>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
