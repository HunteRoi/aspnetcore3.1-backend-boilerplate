using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using DAL.Repositories;
using Microsoft.AspNetCore.Authorization;
using Constants = DTO.Constants;
using DTOs = DTO.V1;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using v1 = Models.V1;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers.V1
{
    [
        ApiController,
        ApiVersion( "1.0" ),
        Route( "api/v{version:apiVersion}/[controller]" ),
        Produces("application/json"),
        
        AllowAnonymous
    ]
    public class PeopleController : ControllerBase
    {
        private readonly ILogger<PeopleController> _logger;
        private readonly IMapper _mapper;
        private readonly PersonRepository _repository;

        public PeopleController(ILogger<PeopleController> logger, IMapper mapper, PersonRepository repository)
        {
            _logger = logger;
            _mapper = mapper;
            _repository = repository;
        }

        [
            HttpGet(Name = nameof(GetAll)),
            SwaggerOperation(
                Summary = "Returns a certain number of people.",
                Description = "Requests a page of people not to load a lot of people on one request. The index and the page size are optional. The request returns an array of people based on the parameters."
            ),
            SwaggerResponse((int)HttpStatusCode.OK, "Returns an array of people.", typeof(IEnumerable<DTOs.Person>)),
            SwaggerResponse((int)HttpStatusCode.BadRequest),
            SwaggerResponse((int)HttpStatusCode.NotFound)
        ]
        public async Task<IActionResult> GetAll(string filter = null, int pageIndex = Constants.PageIndex, int pageSize = Constants.PageSize)
        {
            var totalCount = await _repository.CountAsync();

            var entities = await _repository.ReadAllWithFilterAsync(filter, pageIndex, pageSize);
            if (entities == null) return NotFound();

            Request.HttpContext.Response.Headers.Add("X-TotalCount", totalCount.ToString());
            Request.HttpContext.Response.Headers.Add("X-PageIndex", pageIndex.ToString());
            Request.HttpContext.Response.Headers.Add("X-PageSize", pageSize.ToString());

            return Ok(entities.Select(_mapper.Map<DTOs.Person>));
        }

        [
            HttpGet("{id}", Name = nameof(GetById)),
            SwaggerOperation(
                Summary = "Gets a single person.",
                Description = "Gets a single person."
            ),
            SwaggerResponse((int)HttpStatusCode.OK, "The person was successfully retrieved.", typeof(DTOs.Person)),
            SwaggerResponse((int)HttpStatusCode.NotFound, "The person does not exist.")
        ]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _repository.ReadAsync(id);
            if (person == null) return NotFound();
            return Ok(_mapper.Map<DTOs.Person>(person));
        }

        [
            HttpPost(Name = nameof(Post)),
            SwaggerOperation(
                Summary = "Places a new person.",
                Description = "Adds a new person to the database."
            ),
            SwaggerResponse((int)HttpStatusCode.Created, "The person was successfully placed.", typeof(DTOs.Person)),
            SwaggerResponse((int)HttpStatusCode.BadRequest, "The person is invalid.")
        ]
        public async Task<IActionResult> Post([FromBody] DTOs.Person person, ApiVersion version = null)
        {
            if (version == null)
                version = ApiVersion.Default;

            var newEntity = new v1.Person(person.Firstname, person.LastName, person.Email, person.Phone);
            await _repository.AddAsync(newEntity);
            await _repository.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = newEntity.Id, version = $"{version}" }, _mapper.Map<DTOs.Person>(newEntity));
        }

        [
            HttpPut("{id}", Name = nameof(Put)),
            SwaggerOperation(
                Summary = "Edits a person based on their identifier.",
                Description = "Change the entity of a requested person based on the provided identifier."
            ),
            SwaggerResponse((int)HttpStatusCode.Accepted, "The person was successfully edited.", typeof(DTOs.Person)),
            SwaggerResponse((int)HttpStatusCode.BadRequest),
            SwaggerResponse((int)HttpStatusCode.NotFound, "The person does not exist.")
        ]
        public async Task<IActionResult> Put(int id, [FromBody] DTOs.Person person, ApiVersion version = null)
        {
            if (version == null)
                version = ApiVersion.Default;

            var entityFound = await _repository.ReadAsync(id);
            if (entityFound == null) return NotFound();

            var updateCommand = new v1.Person(person.Firstname, person.LastName, person.Email, person.Phone);
            entityFound.Update(updateCommand);
            _repository.Edit(entityFound);

            return AcceptedAtAction(nameof(GetById), new { id = entityFound.Id, version = $"{version}" }, _mapper.Map<DTOs.Person>(entityFound));
            //return Ok(_mapper.Map<DTOs.Person>(entityFound));
        }

        [
            HttpDelete("{id}", Name = nameof(Delete)),
            SwaggerOperation(
                Summary = "Deletes a person based on their identifier.",
                Description = "Deletes the entity of a requested person based on the provided identifier."
            ),
            SwaggerResponse((int)HttpStatusCode.Accepted, "The person was successfully deleted."),
            SwaggerResponse((int)HttpStatusCode.NotFound, "The person does not exist.")
        ]
        public async Task<IActionResult> Delete(int id)
        {
            var entityFound = await _repository.ReadAsync(id);
            if (entityFound == null) return NotFound();

            _repository.Delete(entityFound);
            await _repository.SaveChangesAsync();
            return NoContent();
        }
    }
}