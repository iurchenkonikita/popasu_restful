using RESTFull.Domain;
using RESTFull.Service.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTFull.Infrastructure
{
    public class ConferenceRepository : IConferenceRepository
    {

        private Context Context { get; set; }

        public ConferenceRepository(Context context)
        {
            Context = context;
        }
        public Conference Create(Conference model)
        {
            Context.Set<Conference>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<Conference>().FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {

                Context.Set<Conference>().Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Conference> GetAll()
        {
            return Context.Set<Conference>().ToList();
        }

        public Conference GetById(Guid id)
        {
            return Context.Set<Conference>().FirstOrDefault(m => m.Id == id);
        }

        public List<Conference> GetById(List<Guid> ids)
        {
            return Context.Set<Conference>().Where(m => ids.Contains(m.Id)).ToList();
        }

        public Conference Update(Conference model)
        {
            var curModel = Context.Set<Conference>().Find(model.Id);
            if (curModel != null)
            {
                curModel.status = model.status;
                curModel.title = model.title;
                curModel.description = model.description;
                curModel.sections = model.sections;
                curModel.startDate = model.startDate;
                curModel.endDate = model.endDate;
                curModel.location = model.location;
                curModel.participants = model.participants;

                Context.Update(curModel);
                Context.SaveChanges();
                return curModel;
            }
            return null;

        }

        public List<Conference> getAllByParticipant(Guid participantId)
        {
            return Context.Set<Conference>().Where(c => c.participants.Any(p => p.Id == participantId)).ToList();
        }
    }
}
