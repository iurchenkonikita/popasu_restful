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
        public ActionResult<List<ParticipantPublicDto>> findAll()
        {
            List<ParticipantPublicDto> Participants = _service.findAll();
            return new ActionResult<List<ParticipantPublicDto>>(Participants);
        }

        // GET: ParticipantController/{id}
        [HttpGet("/Participants/{id}")]
        public async Task<ActionResult<ParticipantPublicDto>> findById(String id)
        {

            ParticipantPublicDto Participant = _service.findById(Guid.Parse(id));
            return new ActionResult<ParticipantPublicDto>(Participant);
        }


        // POST: ParticipantController/Create
        [HttpPost("/Participants/")]
        public async Task<ActionResult<ParticipantPublicDto>> Create(ParticipantCreateDto dto)
        {
            try
            {
                ParticipantPublicDto Participant = _service.create(dto);
                return CreatedAtAction(nameof(Create), Participant);
            }
            catch
            {
                return View();
            }
        }

        // POST: ParticipantController/Edit/5
        [HttpPut("/Participants/{id}")]
        public async Task<ActionResult<ParticipantPublicDto>> Edit(String id, ParticipantUpdateDto dto)
        {
            try
            {
                ParticipantPublicDto Participant = _service.update(dto);
                return CreatedAtAction(nameof(Edit), Participant);
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
