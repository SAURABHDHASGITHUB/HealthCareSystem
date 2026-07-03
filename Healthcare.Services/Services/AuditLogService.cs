using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.AuditLog;
using Healthcare.Infrastructure.Models;
using Healthcare.Repository;
using Healthcare.Services.Interfaces;

namespace Healthcare.Services.Services
{
    public class AuditLogService : IAuditLogService
    {
        private readonly IGenericRepository<AuditLog> _logRepo;

        public AuditLogService(IGenericRepository<AuditLog> logRepo)
        {
            _logRepo = logRepo;  
        }
        public async Task<string> CreateLog(CreateAuditLogDTO dto)
        {
            var log = new AuditLog
            {
                UserId = dto.UserId,
                Action = dto.Action,
                Timestamp = DateTime.Now
            };
            await _logRepo.AddAsync(log);

            await _logRepo.SaveAsync();

            return "Audit log recorded";
        }

        public async Task<IEnumerable<AuditLog>> GetLogs()
        {
            return await _logRepo.GetAllAsync();
        }
    }
}
