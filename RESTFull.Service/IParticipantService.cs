using RESTFull.Domain;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Service
{
    public interface IParticipantService
    {
        public Participant create(ParticipantCreateDto createDto);
        public Participant update(ParticipantUpdateDto updateDto);
        public void delete(Guid id);
        public Participant findById(Guid id);
        public List<Participant> findAll();
    }
}
