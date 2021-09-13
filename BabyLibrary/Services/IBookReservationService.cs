using BabyLibrary.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BabyLibrary.Services
{
    public interface IBookReservationService
    {
        Task<List<BookReservation>> GetUserBookReservationsAsync(string userId);
        Task<List<BookReservation>> GetBookReservationsAsync(Guid bookId);
        Task<BookReservation> GetBookReservationByIdAsync(Guid bookReservationId);
        Task<BookReservation> CreateBookReservationAsync(BookReservation bookReservation);
        Task<BookReservation> UpdateBookReservationAsync(BookReservation bookReservation);
        Task<bool> DeleteBookReservationAsync(Guid bookReservationId);
    }
}
