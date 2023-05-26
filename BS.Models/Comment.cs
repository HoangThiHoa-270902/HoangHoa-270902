namespace BS.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Comment")]
    public class Comment
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        public int? BookId { get; set; }
        [StringLength(200)]
        public string Content { get; set; }

        public DateTime? CreateDate { get; set; }

        public bool IsActive { get; set; }
        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }
    }
}