using System.Diagnostics.CodeAnalysis;
using CashbackManaging.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashbackManaging.Model
{
    [SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<MccCode> MccCodes { get; set; }
        public DbSet<UserCard> UserCards { get; set; }
        public DbSet<CardMccCodeCashback> CardMccCodeCashbacks { get; set; }
        public DbSet<Shop> Shops { get; set; }

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5432;Database=cashbackmanaging;Username=postgres;Password=postgres",
                b => b.MigrationsAssembly("CashbackManaging.Model"));
        }
    }
}