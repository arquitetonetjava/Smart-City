using SmartTeste.Domain.Models;
using NetDevPack.Data;

namespace SmartTeste.Domain.Interfaces
{
    public interface IPeopleRepository : IRepository<People>
    {
        Task<People> GetById(Guid id);
        Task<People> GetByEmail(string email);
        Task<IEnumerable<People>> GetAll();

        void Add(People people);
        void Update(People people);
        void Remove(People people);
    }
}
