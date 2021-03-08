using DevDatum.Domain.ContractRepositories;
using DevDatum.Domain.Entities;
using DevDatum.Infra.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DevDatum.Infra.Repositories
{
    public class InterestRepository : IInterestRepository
    {
        private readonly DevDatumContext _context;

        public InterestRepository(DevDatumContext context)
        {
            _context = context;
        }

        public void Create(Interest interest)
        {
            _context.Interest.Add(interest);
            _context.SaveChanges();
        }

        public IEnumerable<Interest> GetAll()
        {
            return _context.Interest.AsNoTracking().ToList();
        }

        public Interest GetById(int id)
        {
            return _context.Interest.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }

        public void Update(Interest interest)
        {
            _context.Entry(interest).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Interest interest)
        {
            _context.Remove(interest);
            _context.SaveChanges();
        }

        public bool IsExist(int id)
        {
            var fee = _context.Interest.AsNoTracking().FirstOrDefault(x => x.Id == id);

            if (fee != null) return true;

            return false;
        }
    }
}
