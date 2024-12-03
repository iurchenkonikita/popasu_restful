using Microsoft.AspNetCore.Mvc;
using RESTFull.API.mapper;
using RESTFull.Domain;
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
        [HttpGet("/Sections/")]
        public ActionResult<List<Section>> findAll()
        {
            List<Section> Sections = _sectionService.findAll();
            return new ActionResult<List<Section>>(Sections);
        }

        // GET: SectionController/{id}
        [HttpGet("/Sections/{id}")]
        public async Task<ActionResult<Section>> findById(String id)
        {

            Section Section = _sectionService.findById(Guid.Parse(id));
            return new ActionResult<Section>(Section);
        }


        // POST: SectionController/Create
        [HttpPost("/Sections/")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Section>> Create(IFormCollection collection)
        {
            try
            {
                SectionCreateDto SectionDto = _mapper.mapToCreateDto(collection);
                Section Section = _sectionService.create(SectionDto);
                return CreatedAtAction(nameof(findById), Section.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // POST: SectionController/Edit/5
        [HttpPut("/Sections/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Section>> Edit(String id, IFormCollection collection)
        {
            try
            {
                SectionUpdateDto SectionDto = _mapper.mapToUpdateDto(collection);
                Section Section = _sectionService.update(SectionDto);
                return CreatedAtAction(nameof(findById), Section.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // Delete: SectionController/Delete/5
        [HttpDelete("/Sections/{id}")]
        public ActionResult Delete(String id)
        {
            _sectionService.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(findAll), _sectionService.findAll());
        }
    }
}
