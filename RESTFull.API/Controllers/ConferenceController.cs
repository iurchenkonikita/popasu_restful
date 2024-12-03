using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTFull.Domain;
using RESTFull.Domain.Base;
using RESTFull.Service;
using RESTFull.Service.mapper;
using RESTFull.Service.gateway;
using RESTFull.Infrastructure;
using RESTFull.API.mapper;
using RESTFull.API.dto;
using RESTFull.Service.dto;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace RESTFull.API.Controllers
{
    [ApiController]
    public class ConferenceController : Controller
    {
        private IConferenceService _conferenceService;
        private ConferenceFormToDtoMapper _mapper;

        public ConferenceController(IConferenceService conferenceService, ConferenceFormToDtoMapper mapper)
        {
            _conferenceService = conferenceService;
            _mapper = mapper;
        }






        // GET: ConferenceController
        [HttpGet("/")]
        public ActionResult<List<Conference>> findAll()
        {
            List<Conference> conferences = _conferenceService.findAll();
            return new ActionResult<List<Conference>>(conferences);
        }

        // GET: ConferenceController/{id}
        [HttpGet("/{id}")]
        public async Task<ActionResult<Conference>> findById(String id)
        {

            Conference conference = _conferenceService.findById(Guid.Parse(id));
            return new ActionResult<Conference>(conference);
        }
  

        // POST: ConferenceController/Create
        [HttpPost("/")]
        public async Task<ActionResult<Conference>> Create(IFormCollection collection)
        {
            try
            {
                ConferenceCreateDto conferenceDto = _mapper.mapToCreateDto(collection);
                Conference conference = _conferenceService.create(conferenceDto);
                return CreatedAtAction(nameof(Create), conference);
            }
            catch
            {
                return View();
            }
        }

        // POST: ConferenceController/Edit/5
        [HttpPut("/{id}")]
        public async Task<ActionResult<Conference>> Edit(String id, IFormCollection collection)
        {
            try
            {
                ConferenceUpdateDto conferenceDto = _mapper.mapToUpdateDto(collection);
                Conference conference = _conferenceService.update(conferenceDto);
                return CreatedAtAction(nameof(findById), conference.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // Delete: ConferenceController/Delete/5
        [HttpDelete("/{id}")]
        public ActionResult Delete(String id)
        {
            _conferenceService.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(findAll), _conferenceService.findAll());
        }

    }
}
