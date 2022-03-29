using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class CartDetails
    {
        
        public int Id { get; set; }

        public int ProductID{ get; set; }
        public int CartId{ get; set; }
        public float Quantity{ get; set; }
        public float TotalPrice{ get; set; }
        public string date{ get; set; }
    }
}
