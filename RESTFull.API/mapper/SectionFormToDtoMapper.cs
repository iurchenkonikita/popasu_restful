namespace RESTFull.API.mapper
{
    public class SectionFormToDtoMapper
    {
        public SectionFormToDtoMapper()
        {
        }

        //public SectionCreateDto mapToCreateDto(IFormCollection collection)
        //{
        //    SectionCreateDto sectionDto = new SectionCreateDto(
        //        collection["title"],
        //        collection["description"],
        //        collection["conference"],
        //        DateTime.Parse(collection["time"])
        //        );

        //    return sectionDto;
        //}
        //public SectionUpdateDto mapToUpdateDto(IFormCollection collection)
        //{
        //    SectionUpdateDto sectionDto = new SectionUpdateDto(
        //        Guid.Parse(collection["id"].ToString()),
        //        collection["title"],
        //        collection["description"],
        //        collection["conference"],
        //        DateTime.Parse(collection["time"]),
        //        new List<Guid>()
        //    );

        //    return sectionDto;
        //}
    }
}
