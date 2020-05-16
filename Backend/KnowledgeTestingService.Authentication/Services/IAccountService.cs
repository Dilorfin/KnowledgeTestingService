using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.Authentication.Services
{
    public interface IAccountService
    {
        /// <summary>
        /// Gets user's information
        /// </summary>
        /// <returns>User's data</returns>
        Task<Result<UserDto>> GetUserById(string userId);

        /// <summary>
        /// Get count of users starting from offset 
        /// </summary>
        /// <param name="offset">Number of users to skip</param>
        /// <param name="count">Number of users to return</param>
        /// <returns>List of users</returns>
        Task<IEnumerable<UserDto>> GetAll(int offset, int count);

        /// <summary>
        /// Gets number of users
        /// </summary>
        /// <returns>Number of users</returns>
        Task<long> GetUsersCount();

        /// <summary>
        /// Adds to user admin role
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Returns collection of errors</returns>
        Task<IEnumerable<IdentityError>> SetAdmin(string id);

        /// <summary>
        /// Remove from user admin role
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Returns collection of errors</returns>
        Task<IEnumerable<IdentityError>> RemoveAdmin(string id);

        /// <summary>
        /// Bans user forever
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Returns collection of errors</returns>
        Task<IEnumerable<IdentityError>> BanUser(string id);

        /// <summary>
        /// Unbans user
        /// </summary>
        /// <param name="id">User's id</param>
        /// <returns>Returns collection of errors</returns>
        Task<IEnumerable<IdentityError>> UnbanUser(string id);
    }
}