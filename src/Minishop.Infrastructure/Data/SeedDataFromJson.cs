using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MiniShop.Core.Entities;

namespace MiniShop.Infrastructure.Data
{
    public class SeedDataFromJson
    {
        public static async Task SeedAsync(MiniShopDbContext context, ILoggerFactory loggerFactory)
        {
            try
            {
                var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                if (!context.Authors.Any())
                {
                    var authorsData = File.ReadAllText(path + @"/Data/SeedData/authors.json");

                    var authors = JsonSerializer.Deserialize<List<Author>>(authorsData);

                    foreach (var item in authors)
                    {
                        context.Authors.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.BookCategories.Any())
                {
                    var bookCategoriesData = File.ReadAllText(path + @"/Data/SeedData/bookCategories.json");

                    var bookCategories = JsonSerializer.Deserialize<List<BookCategory>>(bookCategoriesData);

                    foreach (var item in bookCategories)
                    {
                        context.BookCategories.Add(item);
                    }

                    await context.SaveChangesAsync();
                }

                if (!context.Books.Any())
                {
                    var booksData = File.ReadAllText(path + @"/Data/SeedData/books.json");

                    var books = JsonSerializer.Deserialize<List<Book>>(booksData);

                    foreach (var item in books)
                    {
                        context.Books.Add(item);
                    }

                    await context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<SeedDataFromJson>();
                logger.LogError(ex.Message);
            }
        }
    }
}
