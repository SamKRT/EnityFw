using Microsoft.EntityFrameworkCore;

using SamuelsShop.Models;

namespace FirstContactWithEFCore.Data
{
    class SamuelsShopContext : DbContext
    {
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<GoodsReceipt> GoodsReceipts { get; set; }
        public DbSet<GoodsReceiptDraft> GoodsReceiptDrafts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Database=SamuelsShop;Trusted_Connection=True");
        }
    }
}
