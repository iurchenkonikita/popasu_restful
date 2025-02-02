﻿using Microsoft.AspNetCore.Mvc;
using RESTFull.API.mapper;
using RESTFull.Service;
using RESTFull.Service.dto;

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
        [HttpGet("/participants/")]
        public ActionResult<List<ParticipantPublicDto>> findAll()
        {
            List<ParticipantPublicDto> Participants = _service.findAll();
            return new ActionResult<List<ParticipantPublicDto>>(Participants);
        }

        // GET: ParticipantController/{id}
        [HttpGet("/participants/{id}")]
        public async Task<ActionResult<ParticipantPublicDto>> findById(String id)
        {

            ParticipantPublicDto Participant = _service.findById(Guid.Parse(id));
            return new ActionResult<ParticipantPublicDto>(Participant);
        }


        // POST: ParticipantController/Create
        [HttpPost("/participants/")]
        public async Task<ActionResult<ParticipantPublicDto>> Create([FromBody] ParticipantCreateDto dto)
        {
            try
            {
                ParticipantPublicDto Participant = _service.create(dto);
                return CreatedAtAction(nameof(Create), Participant);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: ParticipantController/Edit/5
        [HttpPut("/participants/{id}")]
        public async Task<ActionResult<ParticipantPublicDto>> Edit(String id, [FromBody] ParticipantUpdateDto dto)
        {
            try
            {
                ParticipantPublicDto Participant = _service.update(dto);
                return CreatedAtAction(nameof(Edit), Participant);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Delete: ParticipantController/Delete/5
        [HttpDelete("/participants/{id}")]
        public ActionResult Delete(String id)
        {
            _service.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(Delete), String.Format("Participant '{0}' was deleted!", id));
        }
    }
}
