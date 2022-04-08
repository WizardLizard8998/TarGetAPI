using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;



namespace TarGetAPI.Controllers
{

    [Route("TarGet/[controller]")]
    [ApiController]
    public class UserAccController : ControllerBase
    {
        private UserAccountContext _userAccContext;

        public UserAccController(UserAccountContext userAccContext) { _userAccContext = userAccContext; }

        [HttpGet]

        public IEnumerable<UserAccount> GetUserAccs()
        {
            return _userAccContext.UserAccount;
        }


        [HttpGet("{Id}")]
        public IActionResult GetUserAccById(int id)
        {
            var tempUserAcc = _userAccContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == id);

            if(tempUserAcc == null) { return NotFound(); }


            return Ok(tempUserAcc);

        }


        [HttpPost]
        public IActionResult PostUserAcc([FromBody] UserAccount userAcc)
        { 
            if(userAcc == null ) { return NotFound(); }


            _userAccContext.UserAccount.Add(userAcc);
            _userAccContext.SaveChanges();

            return Ok();

        
        }


        [HttpPut("{Id}")]
        public IActionResult PutUserAcc([FromBody] UserAccount userAcc , int id)
        {
            var tempUserAcc = _userAccContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == id);

            if(tempUserAcc ==null) { return NotFound(); }

            _userAccContext.Entry<UserAccount>(userAcc).CurrentValues.SetValues(userAcc);
            _userAccContext.SaveChanges(true);

            return Ok();



        }



        [HttpDelete("{Id}")]
        public IActionResult DeleteUserAcc(int id)
        {
            var tempUserAcc = _userAccContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == id);

            if( tempUserAcc == null ) { return NotFound(); }

            if( tempUserAcc != null )
            {
                _userAccContext.UserAccount.Remove(tempUserAcc);
                _userAccContext.SaveChanges() ;
                return Ok();
            }

            return  BadRequest();

        }



    }
}
