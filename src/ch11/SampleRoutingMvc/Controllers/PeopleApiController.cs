﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleRoutingMvc.Data;
using SampleRoutingMvc.Models;

namespace SampleRoutingMvc.Controllers
{
    [Route("api/People")]
    [ApiController]
    public class PeopleApiController : ControllerBase
    {
        private readonly MvcdbContext _context;

        public PeopleApiController(MvcdbContext context)
        {
            _context = context;
        }

        // GET: api/PeopleApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPerson()
        {
          if (_context.Person == null)
          {
              return NotFound();
          }
            return await _context.Person.ToListAsync();
        }

        [HttpGet]
        [Route("search/name/{value}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByName(string value)
        {
            if (_context.Person == null)
            {
                return NotFound();
            }
            return await _context.Person.Where(t => t.Name.Contains(value)).ToListAsync();
        }

        [HttpGet]
        [Route("search/name/{value}")]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersonByAge(int value)
        {
            if (_context.Person == null)
            {
                return NotFound();
            }
            return await _context.Person.Where(t => t.Age >= value).ToListAsync();
        }


        // GET: api/PeopleApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
          if (_context.Person == null)
          {
              return NotFound();
          }
            var person = await _context.Person.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/PeopleApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.Id)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PeopleApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
          if (_context.Person == null)
          {
              return Problem("Entity set 'MvcdbContext.Person'  is null.");
          }
            _context.Person.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.Id }, person);
        }

        // ブラウザにあわせて POST にする
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Person>> Create(Person person)
        {
            return await PostPerson(person);
        }

        // ブラウザにあわせて POST にする
        [HttpPost]
        [Route("Update/{id}")]
        public async Task<IActionResult> Update(int id, Person person)
        {
            return await PutPerson(id, person);
        }



        // DELETE: api/PeopleApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.Person == null)
            {
                return NotFound();
            }
            var person = await _context.Person.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Person.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.Person?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
