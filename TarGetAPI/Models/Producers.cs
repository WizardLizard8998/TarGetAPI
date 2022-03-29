using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class Producers
    {
        public int P_ID { get ; set; }  
        public string P_Name { get ; set; }  
        public byte P_Picture { get ; set; }  
        public string Description{ get ; set; }  
        public string Address{ get ; set; }  
        public int D_Id{ get ; set; }  
        public string PostalCode{ get ; set; }  
        public string Phone{ get ; set; }  
        public string Email{ get ; set; }  
        public int UAID{ get ; set; }  
    }
}
