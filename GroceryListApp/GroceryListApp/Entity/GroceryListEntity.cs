using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryListApp.Entity
{
    [Table("tblGroceryList")]
    public class GroceryListEntity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Item_Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public bool Checked { get; set; }
        public string Description { get; set; }
        [Required]
        public DateTime Expiry_Date { get; set; }
    }
}
