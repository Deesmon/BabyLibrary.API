using System;

namespace BabyLibrary.Contracts.V1.Responses
{
    public class CreateBookResponse
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Synopsis { get; set; }
    }
}
