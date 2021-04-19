using Microsoft.AspNetCore.Mvc;
using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonSkillsService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

         // GET: api/<controller>
        [HttpGet]
        public IActionResult Get()
        {

            var personDtoCollection = _personService.GetAllPerson();

            if (personDtoCollection != null)
                return Ok(personDtoCollection);
            else
                return NotFound();
        }

        // GET api/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var personDto = _personService.GetPersonById(id);
            
            if(personDto != null)
                return Ok(personDto);
            else
                return NotFound();
        }   

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SavePersonDto savePersonDto)
        {
            var personDto = _personService.UpdatePerson(id, savePersonDto);

            if(personDto != null)
                return Ok(personDto);
            else
                return NotFound();
        }

        // POST api/<controller>
        [HttpPost("")]
        public IActionResult Post([FromBody] SavePersonDto savePersonDto)
        {
            var personDto = _personService.CreatePerson(savePersonDto);
            return Ok(personDto);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var isStatus =_personService.RemovePerson(id);
            if (isStatus)
                return Ok();
            else
                return NotFound();

        }      

    }
}
