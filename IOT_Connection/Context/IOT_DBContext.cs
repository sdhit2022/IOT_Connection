using IOT_Connection.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace IOT_Connection.Context
{
    public class IOT_DBContext : DbContext
    {

        private readonly IConfiguration _configuration;

        public IOT_DBContext()
        {
        }

        public IOT_DBContext(DbContextOptions<IOT_DBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<DeviceHdr> DeviceHdrs { get; set; }
        public DbSet<DeviceDtl> DeviceDtls { get; set; }
        public DbSet<RelUserAndDevice> RelUserAndDevices { get; set; }
       

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<RelUserAndDevice>()
                .HasOne(r=>r.User)
                .WithMany(u=>u.RelUserAndDevices)
                .HasForeignKey(r=>r.FkUserId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<RelUserAndDevice>()
                .HasOne(r=>r.DeviceHdr)
                .WithMany(u=>u.RelUserAndDevices)
                .HasForeignKey(r=>r.FkDeviceHdrId)
                .OnDelete(DeleteBehavior.NoAction);
               
            modelBuilder.Entity<DeviceDtl>()
                .HasOne(r=>r.DeviceHdr)
                .WithMany(u=>u.DeviceDtls)
                .HasForeignKey(r=>r.FkDeviceHdrId)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }
        
}
}
