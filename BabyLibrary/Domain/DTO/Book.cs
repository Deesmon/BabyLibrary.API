using System;

namespace BabyLibrary.Domain.DTO
{
    public class Book
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Synopsis { get; set; }
    }
}
