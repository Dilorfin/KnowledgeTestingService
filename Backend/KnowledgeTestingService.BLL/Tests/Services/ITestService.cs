using KnowledgeTestingService.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public interface ITestService
    {
        /// <summary>
        /// Gets range of tests' information.
        /// </summary>
        /// <param name="offset">Number of entities to skip</param>
        /// <param name="count">Number of entities to return</param>
        /// <returns>Returns range of tests' info</returns>
        Task<IEnumerable<TestInfoDto>> GetTestsInfoRange(int offset, int count);
        
        /// <summary>
        /// Gets filtered range of tests' information.
        /// </summary>
        /// <param name="offset">Number of entities to skip</param>
        /// <param name="count">Number of entities to return</param>
        /// <param name="filter">String to contain</param>
        /// <returns>Returns range of tests' info</returns>
        Task<IEnumerable<TestInfoDto>> GetTestsInfoRange(int offset, int count, string filter);

        /// <summary>
        /// Get count of tests.
        /// </summary>
        /// <returns>Number of tests</returns>
        Task<long> GetTestsCount();

        /// <summary>
        /// Get count of tests containing filter.
        /// </summary>
        /// <param name="filter">String to contain</param>
        /// <returns>Number of tests with filter</returns>
        Task<long> GetTestsCount(string filter);

        /// <summary>
        /// Get full test by id.
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Returns status of operation and full test on success</returns>
        Task<Result<FullTestDto>> GetFullTest(int id);
        
        /// <summary>
        /// Get test info by id.
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Returns status of operation and test info on success</returns>
        Task<Result<TestInfoDto>> GeTestInfo(int id);
        
        /// <summary>
        /// Get test for editing by id.
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Returns status of operation and test for editing on success</returns>
        Task<Result<EditTestDto>> GetEditTest(int id);

        /// <summary>
        /// Adds test.
        /// </summary>
        /// <param name="addTestDto">Test adding model</param>
        /// <returns>Returns status of operation result</returns>
        Task<Result> AddTest(AddTestDto addTestDto);
        
        /// <summary>
        /// Updates test.
        /// </summary>
        /// <param name="editTestDto">Test editing model</param>
        /// <returns>Returns status of operation result</returns>
        Task<Result> UpdateTest(EditTestDto editTestDto);
    }
}