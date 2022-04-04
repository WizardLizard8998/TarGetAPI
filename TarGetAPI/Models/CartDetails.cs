using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class CartDetails
    {
        
        [Key]
        public int CD_Id { get; set; }

        public int Pt_ID{ get; set; }
        public int Ct_Id{ get; set; }
        public float CD_Quantity{ get; set; }
        public float CD_TotalPrice{ get; set; }
        public string CD_date{ get; set; }
    }
}
