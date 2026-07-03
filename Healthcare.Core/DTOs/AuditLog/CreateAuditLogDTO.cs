using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.DTOs.AuditLog
{
    public class CreateAuditLogDTO
    {
        public int UserId { get; set; }

        public string Action { get; set; }

    }
}
