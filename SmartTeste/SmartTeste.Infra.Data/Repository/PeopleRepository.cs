using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using SmartTeste.Domain.Interfaces;
using SmartTeste.Domain.Models;
using SmartTeste.Infra.Data.Context;

namespace SmartTeste.Infra.Data.Repository
{
    public class PeopleRepository : IPeopleRepository
    {
        protected readonly SmartContext Db;
        protected readonly DbSet<People> DbSet;

        public PeopleRepository(SmartContext context)
        {
            Db = context;
            DbSet = Db.Set<People>();
        }

        public IUnitOfWork UnitOfWork => Db;

        public async Task<People> GetById(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public async Task<IEnumerable<People>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<People> GetByEmail(string email)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Email == email);
        }

        public void Add(People people)
        {
            DbSet.Add(people);
        }

        public void Update(People people)
        {
            DbSet.Update(people);
        }

        public void Remove(People people)
        {
            DbSet.Remove(people);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
