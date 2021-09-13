using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BabyLibrary.Domain.EFCore
{
    [Table("Book")]
    public class BookEFCore
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
        
        public string Synopsis { get; set; }
    }
}
