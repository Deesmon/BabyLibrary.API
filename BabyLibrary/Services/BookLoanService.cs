using AutoMapper;
using BabyLibrary.Data;
using BabyLibrary.Domain.DTO;
using BabyLibrary.Domain.EFCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public class BookLoanService : IBookLoanService
    {
        DataContext _dataContext;
        private IMapper _mapper;

        public BookLoanService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<BookLoan>> GetUserBookLoansAsync(string userId)
        {
            var result =  await _dataContext.BookLoans.Where(x => x.UserId == userId).ToListAsync();

            return _mapper.Map<List<BookLoan>>(result);
        }

        public async Task<List<BookLoan>> GetBookLoansAsync(Guid bookId)
        {
            var result = await _dataContext.BookLoans.Where(x => x.BookId == bookId).ToListAsync();

            return _mapper.Map<List<BookLoan>>(result);
        }

        public async Task<BookLoan> GetBookLoanByIdAsync(Guid bookLoanId)
        {
            var result = await _dataContext.BookLoans.SingleOrDefaultAsync(x => x.Id == bookLoanId);

            return _mapper.Map<BookLoan>(result);
        }

        public async Task<BookLoan> CreateBookLoanAsync(BookLoan bookLoan)
        {
            var storeBookLoan = new BookLoanEFCore();

            _mapper.Map(bookLoan, storeBookLoan);

            await _dataContext.BookLoans.AddAsync(storeBookLoan);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<BookLoan>(storeBookLoan);
        }

        public async Task<BookLoan> UpdateBookLoanAsync(BookLoan bookLoan)
        {
            var storeBookLoan = await _dataContext.BookLoans.SingleAsync(x => x.Id == bookLoan.Id);

            _mapper.Map(bookLoan, storeBookLoan);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<BookLoan>(storeBookLoan);
        }

        public async Task<bool> DeleteBookLoanAsync(Guid bookLoanId)
        {
            var book = await _dataContext.BookLoans.SingleOrDefaultAsync(x => x.Id == bookLoanId);

            if (book is null)
                return false;

            _dataContext.BookLoans.Remove(book);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
