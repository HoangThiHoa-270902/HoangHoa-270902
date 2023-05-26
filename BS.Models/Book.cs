namespace BS.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    [Table("Book")]
    public class Book
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookId { get; set; }

        [StringLength(50)]
        [Required]
        [Display(Name ="Tên Sách")]
        public string Title { get; set; }

        [Display(Name = "Thể Loại Sách")]
        public int? CateId { get; set; }
        [Display(Name = "Tác Giả")]
        public int? AuthorId { get; set; }
        [Display(Name = "Nhà Xuất Bản")]
        public int? PubId { get; set; }

        [Display(Name = "Tóm Tắt")]
        public string Summary { get; set; }

        [StringLength(250)]
        [Display(Name = "Upload file")]
        public string ImgUrl { get; set; }
        [Display(Name = "Giá")]
        public decimal Price { get; set; }
        [Display(Name = "Số Lượng")]
        public int Quantity { get; set; }
        [Display(Name = "Ngày Nhập")]
        [DataType(DataType.Date)]
        public DateTime? CreateDate { get; set; }
        [Display(Name = "Ngày Sửa")]
        [DataType(DataType.Date)]
        public DateTime? ModifierDate { get; set; }
        [Display(Name = "Active")]
        public bool IsActive { get; set; }
        [ForeignKey("CateId")]
        public virtual Category Category { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        [ForeignKey("PubId")]
        public virtual Publisher Publisher { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

    }
}