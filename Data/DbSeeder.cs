using LibraryAPI.Models;

namespace LibraryAPI.Data
{
    public static class DbSeeder
    {
        public static void Seed(LibraryContext context)
        {
            if (!context.Authors.Any())
            {
                var authors = new List<Author>
                {
                    new Author
                    {
                        Name = "George Orwell",
                        BirthDate = new DateTime(1903, 6, 25),
                        Books = new List<Book>
                        {
                            new Book { Title = "1984", PublishedYear = 1949, Price = 15.99M },
                            new Book { Title = "Animal Farm", PublishedYear = 1945, Price = 9.99M }
                        }
                    },
                    new Author
                    {
                        Name = "J.K. Rowling",
                        BirthDate = new DateTime(1965, 7, 31),
                        Books = new List<Book>
                        {
                            new Book { Title = "Harry Potter and the Sorcerer's Stone", PublishedYear = 1997, Price = 19.99M },
                            new Book { Title = "Harry Potter and the Chamber of Secrets", PublishedYear = 1998, Price = 19.99M }
                        }
                    }
                };

                context.Authors.AddRange(authors);
                context.SaveChanges();
            }
        }
    }
}
