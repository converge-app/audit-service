using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Database;
using Application.Models.Entities;
using MongoDB.Driver;

namespace Application.Repositories
{
    public interface IAuditRepository
    {
        Task<List<Audit>> Get();
        Task<Audit> GetById(string id);
        Task<List<Audit>> GetByProject(string projectId);
        Task<List<Audit>> GetByFreelancerId(string freelancerId);
        Task<List<Audit>> GetByProjectAndFreelancer(string projectId, string freelancerId);
        Task<Audit> Create(Audit audit);
        Task Update(string id, Audit auditIn);
        Task Remove(Audit auditIn);
        Task Remove(string id);
    }

    public class AuditRepository : IAuditRepository
    {
        private readonly IMongoCollection<Audit> _audit;

        public AuditRepository(IDatabaseContext dbContext)
        {
            if (dbContext.IsConnectionOpen())
                _audit = dbContext.Audit;
        }

        public async Task<List<Audit>> Get()
        {
            return await (await _audit.FindAsync(audit => true)).ToListAsync();
        }

        public async Task<Audit> GetById(string id)
        {
            return await (await _audit.FindAsync(audit => audit.Id == id)).FirstOrDefaultAsync();
        }

        public async Task<List<Audit>> GetByProject(string projectId)
        {
            return await (await _audit.FindAsync(audit => audit.ProjectId == projectId)).ToListAsync();
        }

        public async Task<List<Audit>> GetByFreelancerId(string freelancerId)
        {
            return await (await _audit.FindAsync(audit => audit.FreelancerId == freelancerId)).ToListAsync();
        }

        public async Task<List<Audit>> GetByProjectAndFreelancer(string projectId, string freelancerId)
        {
            return await (
                await _audit.FindAsync(
                    audit => audit.ProjectId == projectId && audit.FreelancerId == freelancerId)
            ).ToListAsync();
        }

        public async Task<Audit> Create(Audit audit)
        {
            await _audit.InsertOneAsync(audit);
            return audit;
        }

        public async Task Update(string id, Audit auditIn)
        {
            await _audit.ReplaceOneAsync(audit => audit.Id == id, auditIn);
        }

        public async Task Remove(Audit auditIn)
        {
            await _audit.DeleteOneAsync(audit => audit.Id == auditIn.Id);
        }

        public async Task Remove(string id)
        {
            await _audit.DeleteOneAsync(audit => audit.Id == id);
        }
    }
}