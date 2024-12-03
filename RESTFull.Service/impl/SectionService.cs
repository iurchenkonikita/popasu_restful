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
    public class SectionService : ISectionService
    {
        private readonly ISectionReporitory _sectionReporitory;
        private readonly IReportRepository _reportRepository;
        private readonly SectionMapper _mapper;

        public SectionService(ISectionReporitory sectionReporitory, IReportRepository reportRepository, SectionMapper mapper)
        {
            _sectionReporitory = sectionReporitory;
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public Section create(SectionCreateDto createDto)
        {
            Section section = _mapper.map(createDto);

            section = _sectionReporitory.Create(section);


            return section;
        }

        public void delete(Guid id)
        {
            _sectionReporitory.Delete(id);
        }

        public List<Section> findAll()
        {
            List<Section> sections = _sectionReporitory.GetAll();
            foreach (Section section in sections)
            {
                List<Report> reports = _reportRepository.getAllBySection(section.Id);
                section.reports = reports;
            }

            return sections;
        }

        public Section findById(Guid id)
        {
            Section section = _sectionReporitory.GetById(id);

            List<Report> reports = _reportRepository.getAllBySection(section.Id);
            section.reports = reports;


            return section;
        }

        public Section update(SectionUpdateDto updateDto)
        {
            Section section = _mapper.map(updateDto);

            section = _sectionReporitory.Create(section);

            List<Report> reports = _reportRepository.getAllBySection(section.Id);
            section.reports = reports;

            return section;
        }



    }
}
