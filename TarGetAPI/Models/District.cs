using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class District
    {
        public int DId { get; set; } 
        public string DName { get; set; } 
        public int CId { get; set; }    

    }
}
