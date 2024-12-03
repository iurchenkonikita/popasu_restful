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
        public Report create(ReportCreateDto createDto);
        public Report update(ReportUpdateDto updateDto);
        public void delete(Guid id);
        public Report findById(Guid id);
        public List<Report> findAll();
    }
}
