using Microsoft.AspNetCore.Mvc;
using PersonSkillsService.Application.DataTransfer.Commands;
using PersonSkillsService.Application.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PersonSkillsService.Controllers
{
    /// <summary>
    /// Класс контроллеров, для получения ввода пользователя, его обработки
    /// и отправки обратно результатов обработки
    /// </summary>
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

         // GET: api/v1/<controller>
        [HttpGet]
        public IActionResult Get()
        {

            var personDtoCollection = _personService.GetAllPerson();

            if (personDtoCollection != null)
                return Ok(personDtoCollection);
            else
                return NotFound();
        }

        // GET api/v1/<PersonController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var personDto = _personService.GetPersonById(id);
            
            if(personDto != null)
                return Ok(personDto);
            else
                return NotFound();
        }   

        // PUT api/v1/<controller>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SavePersonDto savePersonDto)
        {
            if (savePersonDto.Id == null)
            {
                savePersonDto.Id = id;
                var personDto = _personService.UpdatePerson(savePersonDto);

                if (personDto != null)
                    return Ok(personDto);
                else
                    return NotFound();
            }
            else
                return BadRequest();
        }

        // POST api/v1/<controller>
        [HttpPost("")]
        public IActionResult Post([FromBody] SavePersonDto savePersonDto)
        {
            if (savePersonDto.Id == null)
            {
                var personDto = _personService.CreatePerson(savePersonDto);
                return Ok(personDto);
            }
            else
                return BadRequest();
        }

        // DELETE api/v1/<controller>/5
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
