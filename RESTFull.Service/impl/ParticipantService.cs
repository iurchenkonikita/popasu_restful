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
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ParticipantMapper _mapper;

        public Participant create(ParticipantCreateDto createDto)
        {
            Participant participant = _mapper.Map(createDto);

            participant = _participantRepository.Create(participant);

            return participant;
        }

        public void delete(Guid id)
        {
            _participantRepository.Delete(id);
        }

        public List<Participant> findAll()
        {
            List<Participant> participants = _participantRepository.GetAll();
            foreach (Participant participant in participants)
            {
                List<Report> reports = _reportRepository.getAllByParticipant(participant.Id);
                List<Conference> conferences = _conferenceRepository.getAllByParticipant(participant.Id);

                participant.reports = reports;
                participant.conferences = conferences;
            }

            return participants;
        }

        public Participant findById(Guid id)
        {

            Participant participant = _participantRepository.GetById(id);

            List<Conference> conferences = _conferenceRepository.getAllByParticipant(participant.Id);
            participant.conferences = conferences;

            List<Report> reports= _reportRepository.getAllByParticipant(participant.Id);
            participant.reports = reports;


            return participant;
        }

        public Participant update(ParticipantUpdateDto updateDto)
        {
            Participant  participant = _mapper.Map(updateDto);

            participant = _participantRepository.Create(participant);

            List<Report> reports = _reportRepository.getAllByParticipant(participant.Id);
            List<Conference> conferences = _conferenceRepository.getAllByParticipant(participant.Id);

            participant.reports = reports;
            participant.conferences = conferences;

            return participant;
        }
    }
}
