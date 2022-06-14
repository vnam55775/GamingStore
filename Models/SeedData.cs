using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.EntityFrameworkCore;

namespace GamingStore.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            GamingStoreDbContext context =
            app.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GamingStoreDbContext>();
            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if (!context.Gamings.Any())
            {
                context.Gamings.AddRange(
                new Gaming
                {
                    Title = "Chuột Razer Basilisk Ultimates",
                    Description = "https://gearshop.vn/upload/resizer.php?src=https://gearshop.vn/upload/images/Product/Razer/Chu%E1%BB%99t/Razer%20Basilisk%20Ultimate/chuot-razer-basilisk-ultimate-ban-khong-dock-sac6982b6fb4d0-(2).jpg&w=1200&h=1200&q=72&zc=2",
                    Genre = "Chuột",
                    Price = 11.98m
                },
                new Gaming
                {
                    Title = "Chuột Gaming Havit MS953",
                    Description = "https://gearshop.vn/upload/resizer.php?src=https://gearshop.vn/upload/images/Product/Havit/Chu%E1%BB%99t/MS953/MS953-01.jpg&w=1200&h=1200&q=72&zc=2",
                    Genre = "Chuột",
                    Price = 17.46m
                },
                new Gaming
                {
                    Title = "Bàn phím cơ Corsair K60 PRO SE Mx VIOLA CH-910D119-NA",
                    Description = "https://bizweb.sapocdn.net/thumb/medium/100/329/122/products/ban-phim-co-corsair-k60-pro-se-mx-viola-ch-910d119-na.png?v=1627739472000!",
                    Genre = "Bàn phím",
                    Price = 13.41m
                },
                new Gaming
                {
                    Title = "Bàn phím cơ Corsair K100 BLK RGB Cherry MX Speed/CORSAIR OPX",
                    Description = "https://bizweb.sapocdn.net/thumb/medium/100/329/122/products/ban-phim-co-corsair-k100-blk-rgb-bfc5fd2f-2430-46a4-a918-972efb34665e.png?v=1652082441000",
                    Genre = "Bàn phím",
                    Price = 18.69m
                },
                new Gaming
                {
                    Title = "Tai Nghe Gaming Corsair Stereo HS35",
                    Description = "https://bizweb.sapocdn.net/thumb/medium/100/329/122/products/tai-nghe-gaming-corsair-stereo-hs35-0.png?v=1638290556000",
                    Genre = "Tai nghe",
                    Price = 31.26m
                }
                );

                context.SaveChanges();
            }
        }
    }
}