using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Products
    {
        [Key]
        public int Pt_Id { get; set; }
        public string Pt_Name { get; set; }
        public string Pt_Image{ get; set;  }
        public string Pt_Description { get; set; }
        public double  Pt_UnitPrice{ get; set; }
        public double  Pt_Discount{ get; set; }
        public double  Pt_TotalWeight{ get; set; }
        public double Pt_UnitWeight { get; set; }
        public int P_Id{ get; set; }
        public int C_Id{ get; set; }

        
    }
}
