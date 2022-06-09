using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace TarGetAPI.Models
{
    public class CartDetails
    {
        
        [Key]
        public int CD_Id { get; set; }

        public int Pt_ID{ get; set; }
        public int Ct_Id{ get; set; }
        public double CD_Quantity{ get; set; }
        public double CD_TotalPrice{ get; set; }
        public DateTime CD_date{ get; set; }
    }
}
