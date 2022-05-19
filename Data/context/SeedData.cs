using Domain.models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.context
{
    public static class SeedData
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new HelpDeskDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<HelpDeskDbContext>>()))
            {
                // Look for any movies.
                if (context.Categories.Any())
                {
                    return;   // DB has been seeded
                }

                context.Categories.AddRange(
                    new Category
                    {
                        CategoryId = 1,
                        Name = "Telefonía",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 2,
                        Name = "Cómputo",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 3,
                        Name = "Navegación",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 4,
                        Name = "Permisos a sistemas ",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 5,
                        Name = "Correo electrónico",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 6,
                        Name = "Falla en portales ",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 7,
                        Name = "Instalación de software",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 8,
                        Name = "Licencias",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 9,
                        Name = "Antivirus",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    },
                    new Category
                    {
                        CategoryId = 10,
                        Name = "Otras",
                        Description = "",
                        CreatedAt = DateTime.UtcNow,
                        UpdateddAt = DateTime.UtcNow
                    }
                );
                //context.SaveChanges();
            }
        }
    }
}
