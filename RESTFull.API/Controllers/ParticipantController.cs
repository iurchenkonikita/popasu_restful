using Microsoft.AspNetCore.Mvc;
using RESTFull.API.mapper;
using RESTFull.Domain;
using RESTFull.Service.dto;
using RESTFull.Service;

namespace RESTFull.API.Controllers
{
    [ApiController]
    public class ParticipantController : Controller
    {
        private IParticipantService _service;
        private ParticipantFormToDtoMapper _mapper;

        public ParticipantController(IParticipantService service, ParticipantFormToDtoMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }






        // GET: ParticipantController
        [HttpGet("/Participants/")]
        public ActionResult<List<Participant>> findAll()
        {
            List<Participant> Participants = _service.findAll();
            return new ActionResult<List<Participant>>(Participants);
        }

        // GET: ParticipantController/{id}
        [HttpGet("/Participants/{id}")]
        public async Task<ActionResult<Participant>> findById(String id)
        {

            Participant Participant = _service.findById(Guid.Parse(id));
            return new ActionResult<Participant>(Participant);
        }


        // POST: ParticipantController/Create
        [HttpPost("/Participants/")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Participant>> Create(IFormCollection collection)
        {
            try
            {
                ParticipantCreateDto ParticipantDto = _mapper.mapToCreateDto(collection);
                Participant Participant = _service.create(ParticipantDto);
                return CreatedAtAction(nameof(findById), Participant.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // POST: ParticipantController/Edit/5
        [HttpPut("/Participants/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Participant>> Edit(String id, IFormCollection collection)
        {
            try
            {
                ParticipantUpdateDto ParticipantDto = _mapper.mapToUpdateDto(collection);
                Participant Participant = _service.update(ParticipantDto);
                return CreatedAtAction(nameof(findById), Participant.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // Delete: ParticipantController/Delete/5
        [HttpDelete("/Participants/{id}")]
        public ActionResult Delete(String id)
        {
            _service.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(findAll), _service.findAll());
        }
    }
}
