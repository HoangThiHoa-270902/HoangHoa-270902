namespace BS.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    [Table("Category")]
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CateId { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name ="Thể Loại")]
        public string CateName { get; set; }

        [StringLength(200)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}