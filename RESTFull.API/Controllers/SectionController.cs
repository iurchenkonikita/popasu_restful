using Microsoft.AspNetCore.Mvc;
using RESTFull.API.mapper;
using RESTFull.Service;
using RESTFull.Service.dto;

namespace RESTFull.API.Controllers
{

    public class SectionController : Controller
    {

        private ISectionService _sectionService;
        private SectionFormToDtoMapper _mapper;

        public SectionController(ISectionService sectionService, SectionFormToDtoMapper mapper)
        {
            _sectionService = sectionService;
            _mapper = mapper;
        }






        // GET: SectionController
        [HttpGet("/sections/")]
        public ActionResult<List<SectionPublicDto>> findAll()
        {
            List<SectionPublicDto> Sections = _sectionService.findAll();
            return new ActionResult<List<SectionPublicDto>>(Sections);
        }

        // GET: SectionController/{id}
        [HttpGet("/sections/{id}")]
        public async Task<ActionResult<SectionPublicDto>> findById(String id)
        {

            SectionPublicDto Section = _sectionService.findById(Guid.Parse(id));
            return new ActionResult<SectionPublicDto>(Section);
        }


        // POST: SectionController/Create
        [HttpPost("/sections/")]

        public async Task<ActionResult<SectionPublicDto>> Create([FromBody] SectionCreateDto dto)
        {
            try
            {
                SectionPublicDto Section = _sectionService.create(dto);
                return CreatedAtAction(nameof(Create), Section);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: SectionController/Edit/5
        [HttpPut("/sections/{id}")]
        public async Task<ActionResult<SectionPublicDto>> Edit(String id, [FromBody] SectionUpdateDto dto)
        {
            try
            {
                SectionPublicDto Section = _sectionService.update(dto);
                return CreatedAtAction(nameof(Edit), Section);
            }
            catch (FormatException e)
            {
                return BadRequest("Incorrect format of 'guid' to reference entity");

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);

            }
        }

        // Delete: SectionController/Delete/5
        [HttpDelete("/sections/{id}")]
        public ActionResult Delete(String id)
        {
            _sectionService.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(Delete), String.Format("Section '{0}' was deleted!", id));
        }
    }
}
