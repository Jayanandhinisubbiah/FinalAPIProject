using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class OrderMaster
    {
        [Key]
        public int OrderId { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public float TotalPrice { get; set; }
        [Display(Name = "Payment Type")]
        public string? Type { get; set; }
        public string? BankName { get; set; }

        public string? CardNo { get; set; }

        public int? CCV { get; set; }
        public virtual UserList? User { get; set; }
        public virtual ICollection<OrderDetails>? OrderDetails { get; set; }
        public virtual ICollection<NewOrder>? NewOrder { get; set; }
        //public virtual NewOrder? NewOrder { get; set; }

    }
}
