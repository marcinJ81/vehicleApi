using Infrastructure.Entity.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Entity.Context
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleMth> VehicleMths { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>(eb =>
            {
                eb.Property(prop => prop.Vehicle_Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                eb.Property(prop => prop.Vehicle_SerialNumber)
                    .HasColumnType("varchar(20)");
                eb.HasOne(f => f.VehicleType)
                .WithMany(fk => fk.Vehicles)
                .HasForeignKey(x => x.VehicleType_id);

            });

            modelBuilder.Entity<VehicleMth>(eb =>
            {
                eb.Property(prop => prop.Mth_Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                eb.Property(prop => prop.Mth_Register)
                    .HasColumnType("decimal(5,1)");
                eb.Property(prop => prop.Mth_RegisterDate)
                    .HasPrecision(5)
                    .IsRequired();
                eb.Property(prop => prop.Mth_RegisterInsert)
                    .HasDefaultValue(DateTime.Now);
                eb.HasOne(f => f.Vehicle)
                .WithMany(fk => fk.MthRegisters)
                .HasForeignKey(x => x.Vehicle_Id);
            });

            modelBuilder.Entity<VehicleType>(eb =>
            {
                eb.Property(prop => prop.VehicleType_Id)
                    .ValueGeneratedOnAdd()
                    .IsRequired();
                eb.Property(prop => prop.VehicleType_Name)
                    .HasMaxLength(20)
                    .HasColumnType("varchar(20)");
            });
        }
    }
}
