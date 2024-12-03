using Microsoft.Extensions.Primitives;
using RESTFull.API.dto;
using RESTFull.Domain;
using RESTFull.Service.dto;

namespace RESTFull.API.mapper
{
    public class ConferenceFormToDtoMapper
    {
        public ConferenceFormToDtoMapper()
        {
        }

        public ConferenceCreateDto mapToCreateDto(IFormCollection collection)
        {
            String title = collection["title"];
            String status = collection["status"];
            String location = collection["location"];
            String desctiption = collection["desctiption"];
            DateTime startDate = DateTime.Parse(collection["startDate"]);
            DateTime endDate = DateTime.Parse(collection["endDate"]);
            List<String> org = new List<string>();




            ConferenceCreateDto conference = new ConferenceCreateDto(
                title,
                status,
                startDate,
                endDate,
                location,
                desctiption,
                org);

            return conference;
        }
        public ConferenceUpdateDto mapToUpdateDto(IFormCollection collection)
        {
            Guid id = Guid.Parse(collection["id"]);
            String title = collection["title"];
            String status = collection["status"];
            String location = collection["location"];
            String desctiption = collection["desctiption"];
            DateTime startDate = DateTime.Parse(collection["startDate"]);
            DateTime endDate = DateTime.Parse(collection["endDate"]);
            List<String> org = new List<string>();
            List<String> prog = new List<string>();
            List<String> sect = new List<string>();
            List<String> part = new List<string>();


            ConferenceUpdateDto conference = new ConferenceUpdateDto(
                id,
                title,
                status,
                startDate,
                endDate,
                location,
                desctiption,
                org,
                prog,
                sect,
                part);

            return conference;
        }
    }
}
