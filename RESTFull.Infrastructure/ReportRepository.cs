using Microsoft.EntityFrameworkCore;
using RESTFull.Domain;
using RESTFull.Service.gateway;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
            Context.Reports.Add(model);
            Context.SaveChanges();
            return model;
        }

        public void Delete(Guid id)
        {
            var toDelete = Context.Reports.FirstOrDefault(m => m.Id == id);
            if (toDelete != null)
            {
           
                Context.Reports.Remove(toDelete);
                Context.SaveChanges();
            }
        }

        public List<Report> GetAll()
        {
            return Context.Reports
                .Include(r=>r.section)
                .Include(r=>r.authors) 
                .ToList();
        }

        public Report GetById(Guid id)
        {
            return Context.Reports
                .Include(r => r.section)
                .Include(r => r.authors)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Report> GetById(List<Guid> ids)
        {
            return Context.Reports
                .Include(r => r.section)
                .Include(r => r.authors)
                .Where(m => ids.Contains(m.Id))
                .ToList();
        }

        public Report Update(Report model)
        {
            var curModel = Context.Reports
                .Include(r=>r.authors)
                .Include(r=>r.section)
                .FirstOrDefault(c => c.Id == model.Id);

            if (curModel == null)
                throw new KeyNotFoundException(String.Format("Conference not found! ", model.Id));


            Context.Entry(curModel).CurrentValues.SetValues(model);

            curModel.section = Context.Sections.Where(s => model.section.Equals(s)).First();
            curModel.authors = Context.Participants.Where(s => model.authors.Contains(s)).ToList();

            Context.SaveChanges();
            return curModel;
           

        }

        public Report Get(Guid id)
        {
            return Context.Reports
                .Include(r => r.section)
                .Include(r => r.authors)
                .FirstOrDefault(m => m.Id == id);
        }

        public List<Report> getAllBySection(Guid sectionId)
        {
            return Context.Reports
                .Include(r => r.section)
                .Include(r => r.authors)
                .Where(r=>r.section.Id == sectionId)
                .ToList();
        }

        public List<Report> getAllByParticipant(Guid participantId)
        {
            return Context.Reports
                .Include(r => r.section)
                .Include(r => r.authors)
                .Where(r => r.authors.Any(a=>a.Id==participantId))
                .ToList();
        }
    }
}
