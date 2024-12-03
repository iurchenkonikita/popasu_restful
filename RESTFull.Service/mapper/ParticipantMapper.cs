using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
