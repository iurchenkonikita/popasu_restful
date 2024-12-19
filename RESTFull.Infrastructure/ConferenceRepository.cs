using Microsoft.EntityFrameworkCore;
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
            Context.Conferences.Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Conferences
                .FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {

                Context.Conferences.Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Conference> GetAll()
        {
            return Context.Conferences
                .Include(conf=>conf.participants)
                .Include(conf=>conf.sections)
                .ToList();
        }

        public Conference GetById(Guid id)
        {
            return Context.Conferences
                .Include(conf => conf.participants)
                .Include(conf => conf.sections)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Conference> GetById(List<Guid> ids)
        {
            return Context.Conferences
                .Include(conf => conf.participants)
                .Include(conf => conf.sections)
                .Where(m => ids.Contains(m.Id)).ToList();
        }

        public Conference Update(Conference model)
        {
            var curModel = Context.Conferences
                .Include(conf => conf.participants)
                .Include(conf => conf.sections)
                .FirstOrDefault(c => c.Id == model.Id);

            if (curModel == null)
                throw new KeyNotFoundException(String.Format("Conference not found! ", model.Id));


            Context.Entry(curModel).CurrentValues.SetValues(model);

            curModel.sections = Context.Sections.Where(s => model.sections.Contains(s)).ToList();
            curModel.participants = Context.Participants.Where(p => model.participants.Contains(p)).ToList();

            Context.SaveChanges();
            return curModel;
         

        }

        public List<Conference> getAllByParticipant(Guid participantId)
        {
            return Context.Conferences
                .Include(conf => conf.participants)
                .Include(conf => conf.sections)
                .Where(c => c.participants.Any(p => p.Id == participantId))
                .ToList();
        }
    }
}
