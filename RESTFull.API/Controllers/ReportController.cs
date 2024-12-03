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

namespace RESTFull.API.Controllers
{
    [ApiController]
    public class ReportController : Controller
    {
        private IReportService _reportService;
        private ReportFromToDtoMapper _mapper;

        public ReportController(IReportService reportService, ReportFromToDtoMapper mapper)
        {
            _reportService = reportService;
            _mapper = mapper;
        }






        // GET: ReportController
        [HttpGet("/reports/")]
        public ActionResult<List<Report>> findAll()
        {
            List<Report> Reports = _reportService.findAll();
            return new ActionResult<List<Report>>(Reports);
        }

        // GET: ReportController/{id}
        [HttpGet("/reports/{id}")]
        public async Task<ActionResult<Report>> findById(String id)
        {

            Report Report = _reportService.findById(Guid.Parse(id));
            return new ActionResult<Report>(Report);
        }


        // POST: ReportController/Create
        [HttpPost("/reports/")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Report>> Create(ReportCreateDto dto)
        {
            try
            {
                Report Report = _reportService.create(dto);
                return CreatedAtAction(nameof(findById), Report.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // POST: ReportController/Edit/5
        [HttpPut("/reports/{id}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<Report>> Edit(String id, ReportUpdateDto dto)
        {
            try
            {
                Report Report = _reportService.update(dto);
                return CreatedAtAction(nameof(findById), Report.Id.ToString());
            }
            catch
            {
                return View();
            }
        }

        // Delete: ReportController/Delete/5
        [HttpDelete("/reports/{id}")]
        public ActionResult Delete(String id)
        {
            _reportService.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(findAll), _reportService.findAll());
        }

    }
}
