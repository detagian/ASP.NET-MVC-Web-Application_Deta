using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MCCApplication.Models
{
    [Table("TB_M_TransactionItem")]
    public class TransactionItem
    {
        [Key]
        public int IdTI { get; set; }
        public int Quantity { get; set; }
        public int IdItem { get; set; }
        [ForeignKey ("IdItem")] 
        public virtual Item Item { get; set; }
    }
}