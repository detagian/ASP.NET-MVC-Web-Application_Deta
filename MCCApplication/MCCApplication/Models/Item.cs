using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCCApplication.Models
{
    [Table ("TB_M_Item")]
    public class Item
    {
        [Key]
        public int IdItem { get; set; }
        public  string ItemName { get; set; }
        public double Price { get; set; }
        public int Stock { get; set; }
        public int Id { get; set; }
        [ForeignKey("Id")]
        public virtual Supplier Supplier { get; set; }
    }
}