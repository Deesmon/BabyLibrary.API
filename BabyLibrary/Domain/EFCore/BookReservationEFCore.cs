using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BabyLibrary.Domain.EFCore
{
    [Table("BookReservation")]
    public class BookReservationEFCore
    {
        [Key]
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; }

        public Guid BookId { get; set; }

        [ForeignKey(nameof(BookId))]
        public BookEFCore Book { get; set; }

        public DateTime RequestTime { get; set; }

        public bool Pending { get; set; }

        public bool Accepted { get; set; }
    }
}
