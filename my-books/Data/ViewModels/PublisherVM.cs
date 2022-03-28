using System.Collections.Generic;

namespace my_books.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class PublisherWithBooksVM
    {
        public string FullName { get; set; }
        public List<string> BookTitles { get; set; }
    }
}
