using RESTFull.Domain;
using RESTFull.Service.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Infrastructure
{
    public class ParticipantRepository :IParticipantRepository
    {

        private Context Context { get; set; }

        public ParticipantRepository(Context context)
        {
            Context = context;
        }
        public Participant Create(Participant model)
        {
            Context.Set<Participant>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<Participant>().FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {

                Context.Set<Participant>().Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Participant> GetAll()
        {
            return Context.Set<Participant>().ToList();
        }

        public Participant GetById(Guid id)
        {
            return Context.Set<Participant>().FirstOrDefault(m => m.Id == id);
        }

        public List<Participant> GetById(List<Guid> ids)
        {
            return Context.Set<Participant>().Where(m => ids.Contains(m.Id)).ToList();
        }

        public Participant Update(Participant model)
        {
            var curModel = Context.Set<Participant>().FirstOrDefault(m => m.Id == model.Id);
            if (curModel != null)
            {
                var toUpdate = model;
                Context.Update(toUpdate);
                Context.SaveChanges();
                return toUpdate;
            }
            return null;

        }

        public List<Participant> GetAllByReport(Guid reportId)
        {
            return Context.Set<Participant>().Where(c => c.reports.Any(p => p.Id == reportId)).ToList();
        }

        public List<Participant> GetAllByConferenceId(Guid conferenceId)
        {
            return Context.Set<Participant>().Where(c => c.conferences.Any(p => p.Id == conferenceId)).ToList();
            
        }
    }
}
