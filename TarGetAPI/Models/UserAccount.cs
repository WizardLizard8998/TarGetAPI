using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TarGetAPI.Models
{
    public class UserAccount
    {
        [Key]
        public int UA_Id { get; set; }

        public string UA_Email { get; set; }
        
        public string UA_Password { get; set; }
        
        public string UA_Title { get; set; }
        public string  UA_DateEntered{ get; set; }

    }
}
