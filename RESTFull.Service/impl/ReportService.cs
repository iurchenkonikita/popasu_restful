using RESTFull.Domain;
using RESTFull.Service.dto;
using RESTFull.Service.gateway;
using RESTFull.Service.mapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.impl
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IParticipantRepository _participantRepository;
        private readonly ReportMapper _mapper;

        public ReportService(IReportRepository reportRepository, IParticipantRepository participantRepository, ReportMapper mapper)
        {
            _reportRepository = reportRepository ?? throw new ArgumentNullException(nameof(reportRepository));
            _participantRepository = participantRepository ?? throw new ArgumentNullException(nameof(participantRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public Report create(ReportCreateDto createDto)
        {
            Report report = _mapper.Map(createDto);

            report = _reportRepository.Create(report);

            List<Participant> authors = _participantRepository.GetById(createDto.authors.Select(i=>Guid.Parse(i)).ToList());
            report.authors = authors;

            return report;
        }

        public void delete(Guid id)
        {
            _reportRepository.Delete(id);
        }

        public List<Report> findAll()
        {
            List<Report> reports = _reportRepository.GetAll();
            foreach (Report report in reports)
            {
                List<Participant> authors = _participantRepository.GetAllByReport(report.Id);
                report.authors = authors;
            }

            return reports;
        }

        public Report findById(Guid id)
        {
            
            Report report = _reportRepository.GetById(id);

            List<Participant> authors = _participantRepository.GetAllByReport(report.Id);
            report.authors = authors;
            

            return report;
        }

        public Report update(ReportUpdateDto updateDto)
        {
            Report report = _mapper.Map(updateDto);

            report = _reportRepository.Create(report);

            List<Participant> authors = _participantRepository.GetById(updateDto.authors.Select(i => Guid.Parse(i)).ToList());
            report.authors = authors;

            return report;
        }
    }
}
