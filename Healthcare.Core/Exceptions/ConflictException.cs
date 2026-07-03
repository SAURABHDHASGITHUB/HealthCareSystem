using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.Exceptions
{
    public class ConflictException: AppException
    {
        public ConflictException(string message)
            : base(message, 409, "CONFLICT") { }
    }
}
