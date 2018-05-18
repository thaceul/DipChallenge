namespace DipChallengeAPI.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DipChallengeModel : DbContext
    {
        public DipChallengeModel()
            : base("name=DipChallengeModel")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Ordered> Ordered { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Region> Region { get; set; }
        public virtual DbSet<Segment> Segment { get; set; }
        public virtual DbSet<Shipping> Shipping { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.CatName)
                .IsUnicode(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Product)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.CustID)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Region)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Ordered)
                .WithRequired(e => e.Customer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Ordered>()
                .Property(e => e.CustID)
                .IsFixedLength();

            modelBuilder.Entity<Ordered>()
                .Property(e => e.ProdID)
                .IsFixedLength();

            modelBuilder.Entity<Ordered>()
                .Property(e => e.ShipMode)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.ProdID)
                .IsFixedLength();

            modelBuilder.Entity<Product>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Product>()
                .Property(e => e.UnitPrice)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.Ordered)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Region>()
                .Property(e => e.Region1)
                .IsFixedLength();

            modelBuilder.Entity<Region>()
                .HasMany(e => e.Customer)
                .WithRequired(e => e.Region1)
                .HasForeignKey(e => e.Region)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Segment>()
                .Property(e => e.SegName)
                .IsUnicode(false);

            modelBuilder.Entity<Segment>()
                .HasMany(e => e.Customer)
                .WithRequired(e => e.Segment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Shipping>()
                .Property(e => e.ShipMode)
                .IsFixedLength();

            modelBuilder.Entity<Shipping>()
                .HasMany(e => e.Ordered)
                .WithRequired(e => e.Shipping)
                .WillCascadeOnDelete(false);
        }
    }
}
