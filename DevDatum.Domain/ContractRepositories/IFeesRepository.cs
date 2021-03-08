using DevDatum.Domain.Entities;
using System.Collections.Generic;

namespace DevDatum.Domain.ContractRepositories
{
    public interface IFeesRepository
    {
        void Create(Fees fee);
        void Update(Fees fee);
        void Delete(Fees fee);
        Fees GetById(int id);
        IEnumerable<Fees> GetAll();
        bool IsExist(int id);
    }
}
