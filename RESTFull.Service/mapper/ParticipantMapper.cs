using RESTFull.Domain;
using RESTFull.Service.dto;

namespace RESTFull.Service.mapper
{
    public class ParticipantMapper
    {
        public ParticipantMapper()
        {
        }

        public Participant Map(ParticipantCreateDto createDto)
        {
            Participant participant = new Participant();

            participant.name = createDto.name;
            participant.role = createDto.role;
            participant.contactInfo = createDto.contactInfo;
            participant.organization = createDto.organization;

            return participant;

        }
        public Participant Map(ParticipantUpdateDto updateDto)
        {
            Participant participant = new Participant();

            participant.Id = updateDto.id;
            participant.name = updateDto.name;
            participant.role = updateDto.role;
            participant.contactInfo = updateDto.contactInfo;
            participant.organization = updateDto.organization;
            //participant.conferences = updateDto.conferences;
            //participant.reports = updateDto.reports;

            return participant;
        }

        public ParticipantPublicDto map(Participant participant)
        {
            ParticipantPublicDto result = new ParticipantPublicDto();

            result.id = participant.Id.ToString();
            result.name = participant.name;
            result.role = participant.role;
            result.contactInfo = participant.contactInfo;
            result.organization = participant.organization;
            result.conferences = participant.conferences.Aggregate(new List<ConferenceNoRefDto>(),
                (t, c) => { t.Add(ConferenceMapper.mapToNRDto(c)); return t; });
            result.reports = participant.reports.Aggregate(new List<ReportNoRefDto>(),
                (t, c) => { t.Add(ReportMapper.mapToNRDto(c)); return t; });


            return result;

        }

        public static ParticipantNoRefDto mapToNRDto(Participant participant)
        {
            ParticipantNoRefDto result = new ParticipantNoRefDto();

            result.id = participant.Id.ToString();
            result.name = participant.name;
            result.role = participant.role;
            result.contactInfo = participant.contactInfo;
            result.organization = participant.organization;
            result.conferences = participant.conferences.Aggregate(new List<String>(),
                (t, c) => { t.Add(c.Id.ToString()); return t; });
            result.reports = participant.reports.Aggregate(new List<String>(),
                (t, c) => { t.Add(c.Id.ToString()); return t; });

            return result;
        }
    }
}
