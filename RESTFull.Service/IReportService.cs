using RESTFull.Service.dto;

namespace RESTFull.Service
{
    public interface IReportService
    {
        public ReportPublicDto create(ReportCreateDto createDto);
        public ReportPublicDto update(ReportUpdateDto updateDto);
        public void delete(Guid id);
        public ReportPublicDto findById(Guid id);
        public List<ReportPublicDto> findAll();
    }
}
