using ContactBook_Application.Service.Abstraction;
using ContactBook_Domain.Dtos.Request;
using ContactBook_Domain.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ContactBookApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }


        // GET: api/<ContactController>
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var result = await _contactService.GetAllContacts();
            return Ok(result);
        }

        // GET api/<ContactController>/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task <IActionResult> GetContactById(int id)
        {
            var result = await _contactService.GetContactById(id);
            return Ok(result);
        }

        // POST api/<ContactController>
        [Authorize]
        [HttpGet("email/{email}")]
        public async Task<IActionResult> GetContactById(string email)
        {
            var result = await _contactService.GetContactByEmail(email);
            return Ok(result);
        }



        // PUT api/<ContactController>/5
        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateContact(int id,[FromBody] ContactRequestDto requestDto)
        {
            var result = await _contactService.UpdateContact(id, requestDto);
            return Ok(result);
        }

    // DELETE api/<ContactController>/5
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var result = await _contactService.DeleteContact(id);
            return Ok(result);
        }
    }
}
