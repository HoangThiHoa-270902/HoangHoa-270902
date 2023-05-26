using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BS.Models
{
    [Serializable]
    public class CartItem
    {
        
        public Book Books { get; set; }
        public int Quantity { get; set; }

    }
}
