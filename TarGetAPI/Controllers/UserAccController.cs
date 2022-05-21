using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TarGetAPI.Contexts;
using TarGetAPI.Models;
using System;


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
        public IActionResult GetUserAccById(int Id)
        {
            var tempUserAcc = _userAccContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == Id);

            if(tempUserAcc == null) { return NotFound(); }


            return Ok(tempUserAcc);

        }

        [HttpGet("{Mail}/{Password}")]
        public IActionResult GetUserAccByData(string Mail,string Password)
        {
            var tempUserAcc= _userAccContext.UserAccount.FirstOrDefault(ua => ua.UA_Email == Mail && ua.UA_Password == Password);

            if( tempUserAcc == null    )  { return NotFound(); }

            return Ok(tempUserAcc);


        }

        [HttpPost]
        public IActionResult PostUserAcc([FromBody] UserAccount userAcc)
        { 
            if(userAcc == null ) { return NotFound(); }

            userAcc.UA_DateEntered= DateTime.Now;

            _userAccContext.UserAccount.Add(userAcc);
            _userAccContext.SaveChanges();

            return Ok();

        
        }


        [HttpPut("{Id}")]
        public IActionResult PutUserAcc([FromBody] UserAccount userAcc , int Id)
        {
            var tempUserAcc = _userAccContext.UserAccount.FirstOrDefault(ua => ua.UA_Id == Id);

            if(tempUserAcc ==null) { return NotFound(); }

            userAcc.UA_Id = tempUserAcc.UA_Id;
            userAcc.UA_DateEntered = DateTime.Now;

            _userAccContext.Entry<UserAccount>(tempUserAcc).CurrentValues.SetValues(userAcc);
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
