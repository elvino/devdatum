using DevDatum.Domain.Entities;
using System.Collections.Generic;

namespace DevDatum.Domain.ContractRepositories
{
    public interface IInterestRepository
    {
        void Create(Interest interest);
        void Update(Interest interest);
        void Delete(Interest interest);
        Interest GetById(int id);
        IEnumerable<Interest> GetAll();
        bool IsExist(int id);
    }
}
