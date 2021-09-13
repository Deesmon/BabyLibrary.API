using Microsoft.AspNetCore.Identity;
using System;

namespace BabyLibrary.Domain.DTO
{
    public class BookReservation
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        public IdentityUser User { get; set; }

        public Guid BookId { get; set; }

        public Book Book { get; set; }

        public DateTime RequestTime { get; set; }

        public bool Pending { get; set; }

        public bool Accepted { get; set; }
    }
}
