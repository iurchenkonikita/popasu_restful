﻿using Microsoft.AspNetCore.Mvc;
using RESTFull.API.mapper;
using RESTFull.Service;
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
        public ActionResult<List<ReportPublicDto>> findAll()
        {
            List<ReportPublicDto> Reports = _reportService.findAll();
            return new ActionResult<List<ReportPublicDto>>(Reports);
        }

        // GET: ReportController/{id}
        [HttpGet("/reports/{id}")]
        public async Task<ActionResult<ReportPublicDto>> findById(String id)
        {

            ReportPublicDto Report = _reportService.findById(Guid.Parse(id));
            return new ActionResult<ReportPublicDto>(Report);
        }


        // POST: ReportController/Create
        [HttpPost("/reports/")]
        public async Task<ActionResult<ReportPublicDto>> Create([FromBody] ReportCreateDto dto)
        {
            try
            {
                ReportPublicDto Report = _reportService.create(dto);
                return CreatedAtAction(nameof(Create), Report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST: ReportController/Edit/5
        [HttpPut("/reports/{id}")]
        public async Task<ActionResult<ReportPublicDto>> Edit(String id, [FromBody] ReportUpdateDto dto)
        {
            try
            {
                ReportPublicDto Report = _reportService.update(dto);
                return CreatedAtAction(nameof(Edit), Report);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // Delete: ReportController/Delete/5
        [HttpDelete("/reports/{id}")]
        public ActionResult Delete(String id)
        {
            _reportService.delete(Guid.Parse(id));
            return CreatedAtAction(nameof(Delete), String.Format("Report '{0}' was deleted!", id));
        }

    }
}
