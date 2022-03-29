using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Customers
    {
        public int CId { get; set; }
        public string FName{ get; set; }
        public string LName { get; set; }
        public string Address { get; set; }
        public int D_Id { get; set; }
        public string PostalCode{ get; set; }
        public string Phone { get; set; }
        public string Email{ get; set; }
        public string UAID{ get; set; }
    }
}
