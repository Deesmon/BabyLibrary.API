using BabyLibrary.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public interface IBookLoanService
    {
        Task<List<BookLoan>> GetUserBookLoansAsync(string userId);
        Task<List<BookLoan>> GetBookLoansAsync(Guid bookId);
        Task<BookLoan> GetBookLoanByIdAsync(Guid bookLoanId);
        Task<BookLoan> CreateBookLoanAsync(BookLoan bookLoan);
        Task<BookLoan> UpdateBookLoanAsync(BookLoan bookLoan);
        Task<bool> DeleteBookLoanAsync(Guid bookLoanId);
    }
}
