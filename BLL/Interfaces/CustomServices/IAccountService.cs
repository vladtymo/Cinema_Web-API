using Cinema.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Core.Interfaces
{
    public interface IAccountService
    {
        Task RegisterAsync(RegisterUserDTO data);
        Task<AuthorizationDTO> LoginAsync(string email, string password);
        //Task LogoutAsync();
    }
}
