using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GroceryListApp.Model
{
    public class GroceryListModel
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string itemName { get; set; }
        public int quantity { get; set; }
        public decimal price { get; set; }
        public string description { get; set; }
        public DateTime expiryDate { get; set; }
        public bool isChecked { get; set; }
    }
}
