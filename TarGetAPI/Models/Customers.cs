using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Customers
    {
        [Key]
        public int C_Id { get; set; }
        public string C_FName{ get; set; }
        public string C_LName { get; set; }
        public string C_Address { get; set; }
        public int D_Id { get; set; }
        public string C_PostalCode{ get; set; }
        public string C_Phone { get; set; }
        public string C_Email{ get; set; }
        public int C_UAID{ get; set; }
    }
}
