using DevDatum.Domain.ContractRepositories;
using DevDatum.Domain.Entities;
using DevDatum.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevDatum.Infra.Repositories
{
    public class FeesRepository : IFeesRepository
    {
        private readonly DevDatumContext _context;

        public FeesRepository(DevDatumContext context)
        {
            _context = context;
        }

        public void Create(Fees Fees)
        {
            _context.Fees.Add(Fees);
            _context.SaveChanges();
        }

        public IEnumerable<Fees> GetAll()
        {
            return _context.Fees.AsNoTracking().ToList();
        }

        public Fees GetById(int id)
        {
            return _context.Fees.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Fees Fees)
        {
            _context.Entry(Fees).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Fees Fees)
        {
            _context.Remove(Fees);
            _context.SaveChanges();
        }

        public bool IsExist(int id)
        {
            var fee = _context.Fees.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (fee != null) return true; 

            return false;
        }
    }
}
