using RESTFull.Service.dto;

namespace RESTFull.API.mapper
{
    public class ParticipantFormToDtoMapper
    {
        public ParticipantFormToDtoMapper()
        {
        }

        public ParticipantCreateDto mapToCreateDto(IFormCollection collection)
        {
            ParticipantCreateDto dto = new ParticipantCreateDto(
                collection["name"],
                collection["role"],
                collection["contactInfo"],
                collection["organization"]
                );

            return dto;
        }
        public ParticipantUpdateDto mapToUpdateDto(IFormCollection collection)
        {
            ParticipantUpdateDto dto = new ParticipantUpdateDto(
                Guid.Parse(collection["id"].ToString()),
                collection["name"],
                collection["role"],
                collection["contactInfo"],
                collection["organization"],
                new List<Guid>(),
                new List<Guid>()
            );

            return dto;
        }
    }
}
