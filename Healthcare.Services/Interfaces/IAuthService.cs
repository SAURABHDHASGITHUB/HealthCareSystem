using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Healthcare.Core.Common;
using Healthcare.Core.DTOs.Auth;

namespace Healthcare.Services.Interfaces
{
    public interface IAuthService
    {
        Task<int> RegisterAsync(RegisterDTO dto);
        Task<LoginResponseDTO> LoginAsync(LoginDTO dto);
        // change repo
    }
}
