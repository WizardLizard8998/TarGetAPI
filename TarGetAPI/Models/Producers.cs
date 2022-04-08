using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Producers
    {
        [Key]
        public int P_Id { get ; set; }  
        public string P_Name { get ; set; }  
        public byte P_Picture { get ; set; }  
        public string P_Description{ get ; set; }  
        public string P_Address{ get ; set; }  
        public int D_Id{ get ; set; }  
        public string P_PostalCode{ get ; set; }  
        public string P_Phone{ get ; set; }  
        public string P_Email{ get ; set; }  
        public int P_UAID{ get ; set; }  
    }
}
