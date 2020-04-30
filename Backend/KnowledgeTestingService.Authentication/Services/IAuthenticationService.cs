using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.Authentication.Services
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Logs in user
        /// </summary>
        /// <param name="userLogInDto">User log in model</param>
        /// <returns>Returns auth token model</returns>
        Task<Result<TokenDto>> LogIn(UserLogInDto userLogInDto);

        /// <summary>
        /// Registers user
        /// </summary>
        /// <param name="userRegisterDto">User registration model</param>
        /// <returns>Returns collection of errors</returns>
        Task<IEnumerable<IdentityError>> Register(UserRegisterDto userRegisterDto);
    }
}