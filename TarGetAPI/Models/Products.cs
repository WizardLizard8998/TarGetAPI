using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string PName { get; set; }
        public string PImage{ get; set; }
        public string Description { get; set; }
        public float UnitPrice{ get; set; }
        public float Discount{ get; set; }
        public float TotalWeight{ get; set; }
        public float UnitWeight{ get; set; }
        public int ProducerId{ get; set; }
        public int CategoryId{ get; set; }
    }
}
