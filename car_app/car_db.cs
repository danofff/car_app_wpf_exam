namespace car_app
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class car_db : DbContext
    {
        public car_db()
            : base("name=car_db")
        {
        }

        public virtual DbSet<newEquipment> newEquipment { get; set; }
        public virtual DbSet<TablesManufacturer> TablesManufacturer { get; set; }
        public virtual DbSet<TablesModel> TablesModel { get; set; }
        public virtual DbSet<TablesSNPrefix> TablesSNPrefix { get; set; }
        public virtual DbSet<TrackMeter> TrackMeter { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<newEquipment>()
                .HasMany(e => e.TrackMeter)
                .WithRequired(e => e.newEquipment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesManufacturer>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesManufacturer)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesModel>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesModel)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TablesSNPrefix>()
                .HasMany(e => e.newEquipment)
                .WithRequired(e => e.TablesSNPrefix)
                .WillCascadeOnDelete(false);
        }
    }
}
