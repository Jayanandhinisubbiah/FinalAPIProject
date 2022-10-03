using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIProject.Models
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }
      

       
        public int Qnt { get; set; }
        //public virtual ICollection<UserList>? User { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
        public virtual UserList UserList { get; set; }
        [ForeignKey("FoodId")]
        public int FoodId { get; set; }
        public virtual Food? Food { get; set; }

       
    }
}
