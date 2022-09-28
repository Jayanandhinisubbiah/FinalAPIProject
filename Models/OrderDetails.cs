using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("OrderId")]
        public int? OrderId { get; set; }
        [ForeignKey("FoodId")]
        public int? FoodId { get; set; }
        public int Qnt { get; set; }
        public float Price { get; set; }
        public float TotalPrice { get; set; }
        public virtual OrderMaster? OrderMaster { get; set; }
        public virtual Food? Food { get; set; }
    }
}
