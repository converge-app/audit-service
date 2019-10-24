using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Database;
using Application.Models.Entities;
using MongoDB.Driver;

namespace Application.Repositories
{
    public interface IAuditRepository
    {
        Task<Audit> Create(Audit audit);
        Task<List<Audit>> GetByUserId(string userId);
        List<Audit> GetByUserId(string userId, int pageSize, int pageNumber);
    }

    public class AuditRepository : IAuditRepository
    {
        private readonly IMongoCollection<Audit> _audit;

        public AuditRepository(IDatabaseContext dbContext)
        {
            if (dbContext.IsConnectionOpen())
                _audit = dbContext.Audit;
        }

        public async Task<Audit> Create(Audit audit)
        {
            await _audit.InsertOneAsync(audit);
            return audit;
        }

        public async Task<List<Audit>> GetByUserId(string userId)
        {
            return (await (await _audit.FindAsync(audit => audit.UserId == userId)).ToListAsync()).OrderBy(o => o.Timestamp).ToList().OrderBy(a => a.Timestamp).ToList();
        }

        public List<Audit> GetByUserId(string userId, int pageSize, int pageNumber)
        {
            var context = _audit.AsQueryable<Audit>();
            var query = context.Where(a => a.UserId == userId).OrderBy(a => a.Timestamp).Skip(pageNumber * pageSize - 1).Take(pageSize);
            return query.ToList();
        }
    }
}