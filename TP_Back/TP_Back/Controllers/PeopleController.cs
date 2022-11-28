using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TP_Back.DataAccess;
using TP_Back.DataAccess.UnitOfWork;
using TP_Back.Entities;

namespace TP_Back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly IUnitOfWork uow;
        private readonly ILogger<PeopleController> logger;

        public PeopleController(IUnitOfWork uow, ILogger<PeopleController> logger)
        {
            this.uow = uow;
            this.logger = logger;
        }

        // GET: api/People
        [HttpGet]
        public ActionResult<IEnumerable<Person>> GetPeople()
        {
            return Ok(uow.PeopleRepo.GetAll());
        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            var person = await uow.PeopleRepo.GetAsync(q => q.Id == id);

            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        // PUT: api/People/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> EditPerson(int id, Person personEdited)
        {
            if (personEdited.Name is null || personEdited.Id < 1)
                return BadRequest("Invalidad name or invalid person");

            var ActualPerson = await uow.PeopleRepo.GetAsync(q => q.Id == id);
            if (ActualPerson is null)
                return NotFound();

            ActualPerson.Name = personEdited.Name;
            ActualPerson.PhoneNumber = personEdited.PhoneNumber;
            ActualPerson.Email = personEdited.Email;


            uow.PeopleRepo.update(ActualPerson);
            await uow.SaveAsync();

            return NoContent();
        }

        // POST: api/People
        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Person>> CreatePerson(Person person)
        {
            if (person.Name is null || person.Name == string.Empty)
                return BadRequest("Name is required");

            await uow.PeopleRepo.InsertAsync(person);
            await uow.SaveAsync();
            Ok();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePerson(int id)
        {
            var person = await uow.PeopleRepo.GetAsync(q => q.Id == id);
            if (person == null)
            {
                return NotFound();
            }

            uow.PeopleRepo.Delete(person);
            await uow.SaveAsync();

            return NoContent();
        }

    }
}
