using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class UserAcc
    {
        public int UId { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }
        
        public string Title { get; set; }
        public string  UADateEntered{ get; set; }

    }
}
