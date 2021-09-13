using BabyLibrary.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public interface IBookService
    {
        Task<List<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(Guid bookId);

        Task<Book> CreateBookAsync(Book book);

        Task<Book> UpdateBookAsync(Book book);

        Task<bool> DeleteBookAsync(Guid bookId);
    }
}
