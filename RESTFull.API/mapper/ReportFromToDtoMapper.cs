using RESTFull.API.dto;
using RESTFull.Service.dto;

namespace RESTFull.API.mapper
{
    public class ReportFromToDtoMapper
    {
        public ReportFromToDtoMapper()
        {
        }

        public ReportCreateDto mapToCreateDto(IFormCollection collection)
        {
            ReportCreateDto reportDto = new ReportCreateDto(
                collection["title"],
                collection["annotation"],
                new List<string>(),
                DateTime.Parse(collection["presentationTime"]),
                collection["section"]
                );

            return reportDto;
        }
        public ReportUpdateDto mapToUpdateDto(IFormCollection collection)
        {
            ReportUpdateDto conference = new ReportUpdateDto(
                Guid.Parse(collection["id"].ToString()),
                collection["title"],
                collection["annotation"],
                new List<string>(),
                DateTime.Parse(collection["presentationTime"]),
                collection["section"]
            );

            return conference;
        }
    }
}
