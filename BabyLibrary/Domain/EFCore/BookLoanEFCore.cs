using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyLibrary.Domain.EFCore
{
    [Table("BookLoan")]
    public class BookLoanEFCore
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        public Guid BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public BookEFCore Book { get; set; }

        public Guid? BookReservationId { get; set; }

        [ForeignKey(nameof(BookReservationId))]
        public BookReservationEFCore BookReservation { get; set; }

        public DateTime LoanStartedTime { get; set; }

        public DateTime LoanScheduledEndTime { get; set; }

        public DateTime? LoanReturnedTime { get; set; }
    }
}
