using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AppDbContext(DbContextOptions<AppDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public DbSet<User> User { get; set; }
        public DbSet<Address> Address { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Email).HasMaxLength(128);
                entity.Property(u => u.FirstName).HasMaxLength(50);
                entity.Property(u => u.LastName).HasMaxLength(50);
                entity.Property(u => u.PhoneNumber).HasMaxLength(20);
            });
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);
                entity.Property(a => a.Title).HasMaxLength(100);
                entity.Property(a => a.Street).HasMaxLength(200);
                entity.Property(a => a.City).HasMaxLength(100);
                entity.Property(a => a.PostalCode).HasMaxLength(20);
                entity.Property(a => a.Country).HasMaxLength(100);
                entity.Property(a => a.District).HasMaxLength(100);
                entity.Property(a => a.FullAddress).HasMaxLength(500);
                entity.HasOne(a => a.User).WithOne(u => u.Address).HasForeignKey<Address>(a => a.UserId);
            });
        }
    }
}
