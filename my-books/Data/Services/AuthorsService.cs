using System;
using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class AuthorsService
    {
        private AppDbContext _context;
        public AuthorsService(AppDbContext context)
        {
            _context = context;
        }

        public void AddAuthor(AuthorVM author)
        {
            var localAuthor = new Author()
            {
                FullName = author.FullName,
            };

            _context.Authors.Add(localAuthor);
            _context.SaveChanges();
        }
    }
}
