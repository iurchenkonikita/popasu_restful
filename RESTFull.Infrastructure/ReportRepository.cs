using RESTFull.Domain;
using RESTFull.Service.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace RESTFull.Infrastructure
{
    public class ReportRepository : IReportRepository
    {
        private Context Context { get; set; }

        public ReportRepository(Context context)
        {
            Context = context;
        }
        public Report Create(Report model)
        {
            Context.Set<Report>().Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Set<Report>().FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {
           
                Context.Set<Report>().Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Report> GetAll()
        {
            return Context.Set<Report>().ToList();
        }

        public Report GetById(Guid id)
        {
            return Context.Set<Report>().FirstOrDefault(m => m.Id == id);
        }

        public List<Report> GetById(List<Guid> ids)
        {
            return Context.Set<Report>().Where(m => ids.Contains(m.Id)).ToList();
        }

        public Report Update(Report model)
        {
            var curModel = Context.Set<Report>().FirstOrDefault(m => m.Id == model.Id);
            if (curModel != null)
            {
                var toUpdate = model;
                Context.Update(toUpdate);
                Context.SaveChanges();
                return toUpdate;
            }
            return null;

        }

        public Report Get(Guid id)
        {
            return Context.Set<Report>().FirstOrDefault(m => m.Id == id);
        }

        public List<Report> getAllBySection(Guid sectionId)
        {
            return Context.Set<Report>().Where(r=>r.section.Id == sectionId).ToList();
        }

        public List<Report> getAllByParticipant(Guid participantId)
        {
            return Context.Set<Report>().Where(r => r.authors.Any(a=>a.Id==participantId)).ToList();
        }
    }
}
