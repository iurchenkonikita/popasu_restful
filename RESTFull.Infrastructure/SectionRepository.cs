
using Microsoft.EntityFrameworkCore;
using RESTFull.Domain;
using RESTFull.Service.gateway;

namespace RESTFull.Infrastructure
{
    public class SectionRepository : ISectionReporitory
    {
            private Context Context { get; set; }
        
        public SectionRepository(Context context) {
            Context = context;
        }
        public Section Create(Section model)
        {
            Context.Sections.Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Sections
                .FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {
                Context.Sections.Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Section> GetAll()
        {
            return Context.Sections
                .Include(section => section.conference)
                .Include(Section=>Section.reports)
                .ToList();
        }

        public Section GetById(Guid id)
        {
            return Context.Sections
                .Include(section => section.conference)
                .Include(section => section.reports)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Section> GetById(List<Guid> ids)
        {
            return Context.Sections
                .Include(section => section.conference)
                .Include(section => section.reports)
                .Where(m => ids.Contains(m.Id))
                .ToList();
        }

        public Section Update(Section model)
        {
            var curModel = Context.Sections
                .Include(section => section.conference)
                .Include(section => section.reports)
                .Where(section => section.Id == model.Id)
                .First();
            if (curModel != null)
            {
                curModel.title = model.title;
                curModel.description = model.description;
                curModel.time = model.time;
                curModel.reports = model.reports;
                curModel.conference = model.conference;

                Context.Update(curModel);
                Context.SaveChanges();
                return curModel;
            }
            return null;
            
        }

        public Section Get(Guid id)
        {
            return Context.Sections
                .Include(section => section.conference)
                .Include(section => section.reports)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Section> GetByConferenceId(Guid conferenceId)
        {
            return Context.Sections
                .Include(section => section.conference)
                .Include(section => section.reports)
                .Where(c => c.conference.Id == conferenceId)
                .ToList();
        }
    }
}
