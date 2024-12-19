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
        private readonly IConferenceRepository _conferenceRepository;
        private readonly IReportRepository _reportRepository;
        private readonly SectionMapper _mapper;

        public SectionService(ISectionReporitory sectionReporitory, IConferenceRepository conferenceRepository, IReportRepository reportRepository, SectionMapper mapper)
        {
            _sectionReporitory = sectionReporitory;
            _conferenceRepository = conferenceRepository;
            _reportRepository = reportRepository;
            _mapper = mapper;
        }

        public SectionPublicDto create(SectionCreateDto createDto)
        {
            Section section = _mapper.map(createDto);

            section.conference = _conferenceRepository.GetById(createDto.conference);
            section.reports = _reportRepository.getAllBySection(section.Id);

            section = _sectionReporitory.Create(section);


            return _mapper.map(section);
        }

        public void delete(Guid id)
        {
            _sectionReporitory.Delete(id);
        }

        public List<SectionPublicDto> findAll()
        {
            List<Section> sections = _sectionReporitory.GetAll();
            foreach (Section section in sections)
            {
                List<Report> reports = _reportRepository.getAllBySection(section.Id);
                section.reports = reports;
            }

            List < SectionPublicDto > dtos = sections.Aggregate(new List<SectionPublicDto>(), (t, c) => { t.Add(_mapper.map(c)); return t; });

            return dtos;
        }

        public SectionPublicDto findById(Guid id)
        {
            Section section = _sectionReporitory.GetById(id);

            section.reports = _reportRepository.getAllBySection(section.Id);


            return _mapper.map(section);
        }

        public SectionPublicDto update(SectionUpdateDto updateDto)
        {
            Section section = _mapper.map(updateDto);

            section.conference = _conferenceRepository.GetById(updateDto.conference);
            section.reports = _reportRepository.GetById(updateDto.reports);

            section = _sectionReporitory.Update(section);

            section.conference = _conferenceRepository.GetById(updateDto.conference);
            section.reports = _reportRepository.getAllBySection(section.Id);

            return _mapper.map(section);
        }



    }
}
