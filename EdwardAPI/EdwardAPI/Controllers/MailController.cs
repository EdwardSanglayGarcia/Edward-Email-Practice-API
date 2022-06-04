using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EdwardAPI.Controllers
{
    using EdwardAPI.Model;
    using EdwardAPI.Data;
    using Microsoft.EntityFrameworkCore;
    using System.ComponentModel.DataAnnotations;

    [Route("api/[controller]/[action]")]

    [ApiController]
    public class MailController : ControllerBase
    {
        private EdwardDBContext _context;
        public MailController(EdwardDBContext context)
        {
            this._context = context;
        }

        #region Get All
        [HttpGet]
        public async Task<IEnumerable<Mail>> Get()
        {
            var operation = await _context.Mails.ToListAsync();
            return operation;
        }
        #endregion

        #region Get By Id
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById([RegularExpression("^[0-9]+$")]int id) //if negative nums @"^-?[0-9][0-9,\.]+$"
        {
            var operation = await _context.Mails.FindAsync(id);
            return operation != null ? Ok(operation) : NotFound();
        }
        #endregion

        #region Insert
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Send(Mail mail)
        {
            await _context.Mails.AddAsync(mail);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Send),new { id = mail.Id}, mail);
        }


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateUser(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(CreateUser), new { id = user.Id }, user);
        }
        #endregion

        #region Update
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, Mail mail)
        {

            if (id != mail.Id)
            {
                return BadRequest();
            }
            else
            {
                _context.Entry(mail).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        #endregion

        #region Delete
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int id)
        {
            var operation = await _context.Mails.FindAsync(id);
            if (operation == null)
            {
                return NotFound();
            }
            else
            {
                _context.Mails.Remove(operation);
                await _context.SaveChangesAsync();
                return NoContent();
            }
        }
        #endregion

        #region Test
        [HttpGet]
        public async Task<IQueryable<User>> GetUsersQueryable()
        {
            //var operation = await _context.Users.ToListAsync();
            var operation = await _context.Users.Include(x => x.Person).ToListAsync();
            return operation.AsQueryable();
            //Sample
            //return operation.ToList().Select(myOperation =>
            //new User
            //{
            //    Id = myOperation.Id,
            //    Person = myOperation.Person
            //}
            //).AsQueryable();
            //Test ko lang muna yung mga markdown

        }
        #endregion
    }
}
