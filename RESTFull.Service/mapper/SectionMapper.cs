using RESTFull.Domain;
using RESTFull.Service.dto;

namespace RESTFull.Service.mapper
{
    public class SectionMapper
    {
        public SectionMapper()
        {
        }

        public Section map(SectionCreateDto createDto)
        {
            Section section = new Section();

            section.title = createDto.title;
            section.description = createDto.description;
            section.time = createDto.time;


            return section;
        }
        public Section map(SectionUpdateDto updateDto)
        {
            Section section = new Section();

            section.Id = updateDto.id;
            section.title = updateDto.title;
            section.description = updateDto.description;
            section.time = updateDto.time;

            return section;
        }
        public SectionPublicDto map(Section section)
        {
            SectionPublicDto result = new SectionPublicDto();

            result.Id = section.Id.ToString();
            result.description = section.description;
            result.time = section.time;
            result.title = section.title;
            result.reports = section.reports.Aggregate(new List<ReportNoRefDto>(),
                (t, c) => { t.Add(ReportMapper.mapToNRDto(c)); return t; });
            result.conference = ConferenceMapper.mapToNRDto(section.conference);

            return result;
        }
        public static SectionNoRefDto mapToNRDto(Section section)
        {
            SectionNoRefDto result = new SectionNoRefDto();

            result.Id = section.Id.ToString();
            result.description = section.description;
            result.time = section.time;
            result.title = section.title;
            result.reports = section.reports.Aggregate(new List<Guid>(), (t, c) => { t.Add(c.Id); return t; });
            result.conference = section.conference.Id;

            return result;
        }
    }
}
