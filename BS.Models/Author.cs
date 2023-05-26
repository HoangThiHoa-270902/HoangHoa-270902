
namespace BS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Author")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AuthorId { get; set; }

        [StringLength(50)]
        public string AuthorName { get; set; }

        [StringLength(100)]
        public string History { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
