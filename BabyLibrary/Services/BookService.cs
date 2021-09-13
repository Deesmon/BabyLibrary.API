using AutoMapper;
using BabyLibrary.Data;
using BabyLibrary.Domain.DTO;
using BabyLibrary.Domain.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public class BookService : IBookService
    {
        DataContext _dataContext;
        private IMapper _mapper;

        public BookService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            var result =  await _dataContext.Books.ToListAsync();

            return _mapper.Map<List<Book>>(result);
        }

        public async Task<Book> GetBookByIdAsync(Guid bookId)
        {
            var result = await _dataContext.Books.SingleOrDefaultAsync(x => x.Id == bookId);

            return _mapper.Map<Book>(result);
        }

        public async Task<Book> CreateBookAsync(Book book)
        {
            var storeBook = new BookEFCore();

            _mapper.Map(book, storeBook);

            await _dataContext.Books.AddAsync(storeBook);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Book>(storeBook);
        }

        public async Task<Book> UpdateBookAsync(Book book)
        {
            var storeBook = await _dataContext.Books.SingleAsync(x => x.Id == book.Id);

            _mapper.Map(book, storeBook);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<Book>(storeBook);
        }

        public async Task<bool> DeleteBookAsync(Guid bookId)
        {
            var book = await _dataContext.Books.SingleOrDefaultAsync(x => x.Id == bookId);

            if (book is null)
                return false;

            _dataContext.Books.Remove(book);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
