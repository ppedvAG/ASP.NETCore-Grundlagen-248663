using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BusinessModel.Models
{
    [PrimaryKey("Id")]
    public class OrderItem
    {
        [Key, Column("OrderItemId")]
        public long Id { get; set; }

        [ForeignKey("Recipe")]
        public int RecipeId { get; set; }

        public Recipe? Recipe { get; set; }

        [ForeignKey("Order")]
        public long OrderId { get; set; }

        public Order? Order { get; set; }

        public int Quantity { get; set; }

        public float Rating { get; set; }
    }
}
