using RESTFull.Domain;
using RESTFull.Service.dto;
using RESTFull.Service.gateway;
using RESTFull.Service.mapper;

namespace RESTFull.Service.impl
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly IReportRepository _reportRepository;
        private readonly IConferenceRepository _conferenceRepository;
        private readonly ParticipantMapper _mapper;

        public ParticipantService(IParticipantRepository participantRepository, IReportRepository reportRepository, IConferenceRepository conferenceRepository, ParticipantMapper mapper)
        {
            _participantRepository = participantRepository;
            _reportRepository = reportRepository;
            _conferenceRepository = conferenceRepository;
            _mapper = mapper;
        }

        public ParticipantPublicDto create(ParticipantCreateDto createDto)
        {
            Participant participant = _mapper.Map(createDto);

            participant = _participantRepository.Create(participant);

            return _mapper.map(participant);
        }

        public void delete(Guid id)
        {
            _participantRepository.Delete(id);
        }

        public List<ParticipantPublicDto> findAll()
        {
            List<Participant> participants = _participantRepository.GetAll();
            foreach (Participant participant in participants)
            {
                List<Report> reports = _reportRepository.getAllByParticipant(participant.Id);
                List<Conference> conferences = _conferenceRepository.getAllByParticipant(participant.Id);

                participant.reports = reports;
                participant.conferences = conferences;
            }
            List<ParticipantPublicDto> dtos = participants.Aggregate(new List<ParticipantPublicDto>(), (t, c) => { t.Add(_mapper.map(c)); return t; });
            return dtos;
        }

        public ParticipantPublicDto findById(Guid id)
        {

            Participant participant = _participantRepository.GetById(id);

            List<Conference> conferences = _conferenceRepository.getAllByParticipant(participant.Id);
            participant.conferences = conferences;

            List<Report> reports = _reportRepository.getAllByParticipant(participant.Id);
            participant.reports = reports;


            return _mapper.map(participant);
        }

        public ParticipantPublicDto update(ParticipantUpdateDto updateDto)
        {
            Participant participant = _mapper.Map(updateDto);

            participant.conferences = _conferenceRepository.GetById(updateDto.conferences);
            participant.reports = _reportRepository.GetById(updateDto.reports);

            participant = _participantRepository.Update(participant);

            List<Report> reports = _reportRepository.getAllByParticipant(participant.Id);
            List<Conference> conferences = _conferenceRepository.getAllByParticipant(participant.Id);

            participant.reports = reports;
            participant.conferences = conferences;

            return _mapper.map(participant);
        }
    }
}
