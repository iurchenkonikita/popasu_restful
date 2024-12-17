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
        public ActionResult<List<ConferencePublicDto>> findAll()
        {
            List<ConferencePublicDto> conferences = _conferenceService.findAll();
            return new ActionResult<List<ConferencePublicDto>>(conferences);
        }

        // GET: ConferenceController/{id}
        [HttpGet("/{id}")]
        public async Task<ActionResult<ConferencePublicDto>> findById(String id)
        {

            var conference = _conferenceService.findById(Guid.Parse(id));
            return new ActionResult<ConferencePublicDto>(conference);
        }
  

        // POST: ConferenceController/Create
        [HttpPost("/")]
        public async Task<ActionResult> Create(ConferenceCreateDto dto)
        {
            try
            {
                
                var conference = _conferenceService.create(dto);
                return CreatedAtAction(nameof(Create), conference);
            }
            catch(Exception ex) {
            
                return View(ex.Message);
            }
        }

        // POST: ConferenceController/Edit/5
        [HttpPut("/{id}")]
        public async Task<ActionResult> Edit(String id, ConferenceUpdateDto dto)
        {
            try
            {
                var conference = _conferenceService.update(dto);
                return CreatedAtAction(nameof(Edit), conference);
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
            return CreatedAtAction(nameof(Delete), String.Format("Conference '{0}' was deleted!",id));
        }

    }
}
