using RESTFull.Domain;
using RESTFull.Service.dto;
using RESTFull.Service.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service.mapper
{
    public class ReportMapper
    {

        private ISectionReporitory _sectionReporitory;

        public ReportMapper(ISectionReporitory sectionReporitory)
        {
            _sectionReporitory = sectionReporitory;
        }

        public Report Map(ReportCreateDto createDto)
        {
            Report report = new Report();

            report.title = createDto.title;
            report.section = _sectionReporitory.GetById(Guid.Parse(createDto.section));
            report.annotation = createDto.annotation;
            report.presentationTime = createDto.presentationTime;

            return report;

        }
        public Report Map(ReportUpdateDto updateDto)
        {
            Report report = new Report();

            report.Id = updateDto.id;
            report.title = updateDto.title;
            report.section = _sectionReporitory.GetById(Guid.Parse(updateDto.section));
            report.annotation = updateDto.annotation;
            report.presentationTime = updateDto.presentationTime;

            return report;
        }
    }
}
