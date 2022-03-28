using System;
using System.Linq;
using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class PublishersService
    {
        private AppDbContext _context;
        public PublishersService(AppDbContext context)
        {
            _context = context;
        }

        public void AddPublisher(PublisherVM publisher)
        {
            var localPublisher = new Publisher()
            {
                Name = publisher.Name
            };

            _context.Publishers.Add(localPublisher);
            _context.SaveChanges();
        }

        public PublisherWithBooksVM GetPublisherWithBooks(int publisherId)
        {
            var publisher = _context.Publishers.Where(n => n.Id == publisherId).Select(n => new PublisherWithBooksVM()
            {
                FullName = n.Name,
                BookTitles = n.Books.Select(n => n.Title).ToList()
            }).FirstOrDefault();

            return publisher;   
        }
    }
}
