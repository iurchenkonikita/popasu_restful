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
    public class ParticipantRepository :IParticipantRepository
    {

        private Context Context { get; set; }

        public ParticipantRepository(Context context)
        {
            Context = context;
        }
        public Participant Create(Participant model)
        {
            Context.Participants.Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Participants.FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {

                Context.Participants.Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Participant> GetAll()
        {
            return Context.Participants
                .Include(p => p.conferences)
                .Include(p => p.reports)
                .ToList();
        }

        public Participant GetById(Guid id)
        {
            return Context.Participants
                .Include(p => p.conferences)
                .Include(p => p.reports)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Participant> GetById(List<Guid> ids)
        {
            return Context.Participants
                .Include(p => p.conferences)
                .Include(p => p.reports)
                .Where(m => ids.Contains(m.Id)).ToList();
        }

        public Participant Update(Participant model)
        {
            var curModel = Context.Participants
                .Include(p => p.conferences)
                .Include(p => p.reports)
                .FirstOrDefault(c => c.Id == model.Id);

            if (curModel == null)
            {
                throw new KeyNotFoundException("Participant not found");
            }


            Context.Entry(curModel).CurrentValues.SetValues(model);


            curModel.conferences = Context.Conferences.Where(c => model.conferences.Contains(c)).ToList();

            curModel.reports = Context.Reports.Where(r => model.reports.Contains(r)).ToList();

            Context.SaveChanges();
            return curModel;
            

        }

        public List<Participant> GetAllByReport(Guid reportId)
        {
            return Context.Participants
                .Include(p => p.conferences)
                .Include(p => p.reports)
                .Where(c => c.reports.Any(p => p.Id == reportId))
                .ToList();
        }

        public List<Participant> GetAllByConferenceId(Guid conferenceId)
        {
            return Context.Participants
                .Include(p => p.conferences)
                .Include(p => p.reports)
                .Where(c => c.conferences.Any(p => p.Id == conferenceId))
                .ToList();
            
        }
    }
}
