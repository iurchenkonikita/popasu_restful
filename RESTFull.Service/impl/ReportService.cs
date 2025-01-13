using RESTFull.Domain;
using RESTFull.Service.dto;
using RESTFull.Service.gateway;
using RESTFull.Service.mapper;

namespace RESTFull.Service.impl
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;
        private readonly IParticipantRepository _participantRepository;
        private ISectionReporitory _sectionReporitory;

        private readonly ReportMapper _mapper;

        public ReportService(IReportRepository reportRepository, IParticipantRepository participantRepository, ISectionReporitory sectionReporitory, ReportMapper mapper)
        {
            _reportRepository = reportRepository;
            _participantRepository = participantRepository;
            _sectionReporitory = sectionReporitory;
            _mapper = mapper;
        }

        public ReportPublicDto create(ReportCreateDto createDto)
        {
            Report report = _mapper.Map(createDto);

            report.authors = _participantRepository.GetById(createDto.authors);
            report.section = _sectionReporitory.GetById(createDto.section);

            report = _reportRepository.Create(report);

            List<Participant> authors = _participantRepository.GetById(createDto.authors);
            report.authors = authors;

            return _mapper.map(report);
        }

        public void delete(Guid id)
        {
            _reportRepository.Delete(id);
        }

        public List<ReportPublicDto> findAll()
        {
            List<Report> reports = _reportRepository.GetAll();
            foreach (Report report in reports)
            {
                List<Participant> authors = _participantRepository.GetAllByReport(report.Id);
                report.authors = authors;
            }
            List<ReportPublicDto> dtos = reports.Aggregate(new List<ReportPublicDto>(), (t, c) => { t.Add(_mapper.map(c)); return t; });

            return dtos;
        }

        public ReportPublicDto findById(Guid id)
        {

            Report report = _reportRepository.GetById(id);

            List<Participant> authors = _participantRepository.GetAllByReport(report.Id);
            report.authors = authors;

            report.section = _sectionReporitory.GetById(report.section.Id);


            return _mapper.map(report);
        }

        public ReportPublicDto update(ReportUpdateDto updateDto)
        {
            Report report = _mapper.Map(updateDto);

            report.authors = _participantRepository.GetById(updateDto.authors);
            report.section = _sectionReporitory.GetById(updateDto.section);


            report = _reportRepository.Update(report);

            List<Participant> authors = _participantRepository.GetById(updateDto.authors);
            report.authors = authors;

            return _mapper.map(report);
        }
    }
}
