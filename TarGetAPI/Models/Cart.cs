using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Cart
    {
        public int Id { get; set; } 
        public string CtPaid{ get; set; }    
        public string CtNote{ get; set; }    
    }
}
