using CloudIceTaskOne.Data;
using Microsoft.EntityFrameworkCore;

namespace CloudIceTaskOne.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CloudIceTaskOneContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CloudIceTaskOneContext>>()))
            {
                // Look for any CarModels
                if (context.CarModels.Any())
                {
                    return;   // DB has been seeded
                }
                context.CarModels.AddRange(
                    new CarModels
                    {
                        CarModel = "ford",
                        ReleaseDate = DateTime.Parse("1989-2-12"),
                        CarType = "car",
                        Price = 70000000.99M

                        
                    },
                    new CarModels
                    {
                        CarModel = "toyota ",
                        ReleaseDate = DateTime.Parse("1984-3-13"),
                        CarType = "van",
                        Price = 877744.99M
                    },
                    new CarModels
                    {
                        CarModel = "lamborghini",
                        ReleaseDate = DateTime.Parse("1986-2-23"),
                        CarType = "bus",
                        Price = 9855526.99M
                    },
                    new CarModels
                    {
                        CarModel = "ferrari",
                        ReleaseDate = DateTime.Parse("1959-4-15"),
                        CarType = "bike",
                        Price = 352200.99M
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
