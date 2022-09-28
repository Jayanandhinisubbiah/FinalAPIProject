using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class NewOrder
    {
        [Key]
        public int Id { get; set; }
        

        public string? Email { get; set; }
        public string? Image { get; set; }
        public string? FoodName { get; set; }
        public float? Price { get; set; }
        public int? Qnt { get; set; }
        public float? TotalPrice { get; set; }
        public string Status { get; set; }


        [ForeignKey("OrderId")]
        public int? OrderId { get; set; }
        public virtual OrderMaster? OrderMaster { get; set; }
    }
}
