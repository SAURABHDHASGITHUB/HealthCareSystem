using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Healthcare.Infrastructure.Models;

public partial class AuditLog
{
    [Key]
    public int LogId { get; set; }

    public int? UserId { get; set; }

    [StringLength(200)]
    public string? Action { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Timestamp { get; set; }
}
