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
    public class BookReservationService : IBookReservationService
    {
        DataContext _dataContext;
        private IMapper _mapper;

        public BookReservationService(DataContext dataContext, IMapper mapper)
        {
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public async Task<List<BookReservation>> GetUserBookReservationsAsync(string userId)
        {
            var result =  await _dataContext.BookReservations.Where(x => x.UserId == userId).ToListAsync();

            return _mapper.Map<List<BookReservation>>(result);
        }

        public async Task<List<BookReservation>> GetBookReservationsAsync(Guid bookId)
        {
            var result = await _dataContext.BookReservations.Where(x => x.BookId == bookId).ToListAsync();

            return _mapper.Map<List<BookReservation>>(result);
        }

        public async Task<BookReservation> GetBookReservationByIdAsync(Guid bookReservationId)
        {
            var result = await _dataContext.BookReservations.SingleOrDefaultAsync(x => x.Id == bookReservationId);

            return _mapper.Map<BookReservation>(result);
        }

        public async Task<BookReservation> CreateBookReservationAsync(BookReservation bookReservation)
        {
            var storeBookReservation = new BookReservationEFCore();

            _mapper.Map(bookReservation, storeBookReservation);

            await _dataContext.BookReservations.AddAsync(storeBookReservation);
            await _dataContext.SaveChangesAsync();

            return _mapper.Map<BookReservation>(storeBookReservation);
        }

        public async Task<BookReservation> UpdateBookReservationAsync(BookReservation bookReservation)
        {
            var storeBookReservation = await _dataContext.BookReservations.SingleAsync(x => x.Id == bookReservation.Id);

            _mapper.Map(bookReservation, storeBookReservation);

            await _dataContext.SaveChangesAsync();

            return _mapper.Map<BookReservation>(storeBookReservation);
        }

        public async Task<bool> DeleteBookReservationAsync(Guid bookReservationId)
        {
            var book = await _dataContext.BookReservations.SingleOrDefaultAsync(x => x.Id == bookReservationId);

            if (book is null)
                return false;

            _dataContext.BookReservations.Remove(book);
            var deleted = await _dataContext.SaveChangesAsync();

            return deleted > 0;
        }
    }
}
