using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary
{
    public class Database : IDatabase
    {
        private IEnumerable<Book> books = new List<Book>();

        public void DeleteBook(int id)
        {
            var found = books.First(b => b.BookId == id);

            if(found != null)
            {
                books.ToList().Remove(found);
            }
        }

        public Book GetBook(int id)
        {
            return (from b in books
                   where b.BookId == id
                   select b).First();
        }

        public IEnumerable<Book> GetBooks(string searchParam = "")
        {
            return from b in books
                   where searchParam != "" && b.Title.StartsWith(searchParam)
                   orderby b.Title
                   select b;
        }

        public Book InsertBook(Book book)
        {

            books.Append(book);

            return books.Last();
        }

        public Book UpdateBook(Book book)
        {
            var found = books.First(b => b.BookId == book.BookId);

            if(found != null)
            {
                found = book;

            }

            return found;
        }
    }
}
