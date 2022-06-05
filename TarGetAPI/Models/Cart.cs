using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Cart
    {
        [Key]
        public int Ct_Id { get; set; } 
        public int Cust_Id { get; set; }
        public int Ct_Paid{ get; set; }    
        public string Ct_note{ get; set; }    
    }
}
