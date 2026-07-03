using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.DTOs.AuditLog;
using Healthcare.Infrastructure.Models;

namespace Healthcare.Services.Interfaces
{
    public interface IAuditLogService
    {
        Task<string> CreateLog(CreateAuditLogDTO dto);

        Task<IEnumerable<AuditLog>> GetLogs();

    }
}
