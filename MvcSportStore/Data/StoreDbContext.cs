using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcSportStore.Models;
using MvcSportStore.ViewModels.IdentityViewModels;

namespace MvcSportStore.Data
{
    public class StoreDbContext : IdentityDbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<MvcSportStore.ViewModels.IdentityViewModels.LoginViewModel> LoginViewModel { get; set; } = default!;
        public DbSet<MvcSportStore.ViewModels.IdentityViewModels.RegisterViewModel> RegisterViewModel { get; set; } = default!;
    }
}
