﻿using System;
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
    }
}
