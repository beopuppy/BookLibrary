using BookLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibrary
{
    public interface IDatabase
    {

        IEnumerable<Book> GetBooks(string searchParam = "");

        Book GetBook(int id);

        Book InsertBook(Book book);

        Book UpdateBook(Book book);

        void DeleteBook(int id);
        
    }
}
