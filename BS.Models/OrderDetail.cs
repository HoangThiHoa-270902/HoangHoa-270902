namespace BS.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int OrderId { get; set; }

        [Key]
        [Column(Order = 2)]
        public int BookId { get; set; }

        public int Quantity { get; set; }

        public virtual Order Order { get; set; }

        public virtual Book Book { get; set; }
    }
}
