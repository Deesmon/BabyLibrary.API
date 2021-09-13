using Microsoft.AspNetCore.Identity;
using System;

namespace BabyLibrary.Domain.DTO
{
    public class BookLoan
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public Guid BookId { get; set; }

        public Book Book { get; set; }

        public Guid? BookLoanId { get; set; }

        public BookReservation BookReservation { get; set; }

        public DateTime LoanStartedTime { get; set; }

        public DateTime LoanScheduledEndTime { get; set; }

        public DateTime? LoanReturnedTime { get; set; }
    }
}
