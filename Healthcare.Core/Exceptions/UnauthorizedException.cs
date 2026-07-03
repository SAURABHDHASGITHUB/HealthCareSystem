using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Core.Exceptions
{
    public class UnauthorizedException: AppException
    {
        public UnauthorizedException(string message)
          : base(message, 401, "UNAUTHORIZED")
        {
        }
    }
}
