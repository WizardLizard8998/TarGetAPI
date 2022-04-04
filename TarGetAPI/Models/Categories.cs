using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Categories
    {
        [Key]
        public int C_Id { get; set; }
        public string C_Name{ get; set; }
    }
}
