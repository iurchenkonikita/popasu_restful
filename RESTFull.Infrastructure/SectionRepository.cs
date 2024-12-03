using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Context.Set<Section>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<Section>().FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {
                Context.Set<Section>().Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Section> GetAll()
        {
            return Context.Set<Section>().ToList();
        }

        public Section GetById(Guid id)
        {
            return Context.Set<Section>().FirstOrDefault(m => m.Id == id);
        }

        public List<Section> GetById(List<Guid> ids)
        {
            return Context.Set<Section>().Where(m => ids.Contains(m.Id)).ToList();
        }

        public Section Update(Section model)
        {
            var curModel = Context.Set<Section>().FirstOrDefault(m => m.Id == model.Id);
            if (curModel != null)
            {
                var toUpdate = model;
                Context.Update(toUpdate);
                Context.SaveChanges();
                return toUpdate;
            }
            return null;
            
        }

        public Section Get(Guid id)
        {
            return Context.Set<Section>().FirstOrDefault(m => m.Id == id);
        }

        public List<Section> GetByConferenceId(Guid conferenceId)
        {
            return Context.Set<Section>().Where(c => c.conference.Id == conferenceId).ToList();
        }
    }
}
