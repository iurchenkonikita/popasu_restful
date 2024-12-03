using RESTFull.API.dto;
using RESTFull.Service.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Domain
{
    public interface IConferenceService
    {
        public Conference findById(Guid id);
        public List<Conference> findAll();
        public Conference create(ConferenceCreateDto createDto);
        public Conference update(ConferenceUpdateDto updateDto);
        public void delete(Guid id);

        }
}
