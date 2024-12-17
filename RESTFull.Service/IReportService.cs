using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
