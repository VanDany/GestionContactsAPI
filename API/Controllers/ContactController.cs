using API.Models.Forms;
using BxlForm.DemoSecurity.Models.Client.Data;
using BxlForm.DemoSecurity.Models.Client.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactRepository _contact;

        public ContactController(IContactRepository contact)
        {
            _contact = contact;
        }

        // GET: api/<ContactController>
        [HttpGet("{userid}/{id}")]
        public Contact Get(int userid, int id)
        {
            return _contact.Get(userid, id);
        }

        // GET api/<ContactController>/5
        [HttpGet("{userid}")]
        public IEnumerable<Contact> Get(int userid)
        {
            return _contact.Get(userid);

        }

        [HttpGet("/ByCategory/{userId}/{categoryId}")]
        public IEnumerable<Contact> GetByCategory(int categoryId, int userId)
        {
            return _contact.GetByCategory(categoryId, userId);
        }

        //// POST api/<ContactController>
        [HttpPost]
        public IActionResult Post([FromBody] ContactForm contactform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact contact = new Contact(contactform.LastName, contactform.FirstName, contactform.Email, contactform.CategoryId, contactform.UserId);

            _contact.Insert(contact);

            return Ok();
        }

        //// PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UpdateContactForm contactform)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Contact contact = new Contact(contactform.LastName, contactform.FirstName, contactform.Email, contactform.CategoryId, contactform.UserId);

            _contact.Update(id, contact);

            return Ok();
        }

        //// DELETE api/<ContactController>/5
        [HttpDelete("{userid}/{id}")]
        public IActionResult Delete(int userid, int id)
        {
            if (_contact.Get(userid, id) is null)
            {
                return BadRequest();
            }
            _contact.Delete(userid, id);

            return Ok();
        }
    }
}
