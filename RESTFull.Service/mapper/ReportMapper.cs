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
            report.section = _sectionReporitory.GetById(createDto.section);
            report.annotation = createDto.annotation;
            report.presentationTime = createDto.presentationTime;

            return report;

        }
        public Report Map(ReportUpdateDto updateDto)
        {
            Report report = new Report();

            report.Id = updateDto.id;
            report.title = updateDto.title;
            report.section = _sectionReporitory.GetById(updateDto.section);
            report.annotation = updateDto.annotation;
            report.presentationTime = updateDto.presentationTime;

            return report;
        }

        public ReportPublicDto map(Report report)
        {
            ReportPublicDto result = new ReportPublicDto();

            result.Id = report.Id.ToString();
            result.title = report.title;
            result.annotation = report.annotation;
            result.presentationTime = report.presentationTime;
            result.section = SectionMapper.mapToNRDto(report.section);
            result.authors = report.authors.Aggregate(new List<ParticipantNoRefDto>(), 
                (t, c)=> { t.Add(ParticipantMapper.mapToNRDto(c)); return t; });  

            return result;
        }

        public static ReportNoRefDto mapToNRDto(Report report)
        {
            ReportNoRefDto result = new ReportNoRefDto();

            result.Id = report.Id.ToString() ;
            result.title = report.title;
            result.annotation = report.annotation; 
            result.presentationTime = report.presentationTime;
            result.section = report.section.Id.ToString();
            result.authors = report.authors.Aggregate(new List<String>(), 
                (t, c) => { t.Add(c.Id.ToString()); return t; });

            return result;
        }
    }
}
