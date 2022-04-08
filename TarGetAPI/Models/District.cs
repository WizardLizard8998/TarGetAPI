using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class District
    {
        [Key]
        public int D_Id { get; set; } 
        public string D_Name { get; set; } 
        public int CityId { get; set; }    

    }
}
