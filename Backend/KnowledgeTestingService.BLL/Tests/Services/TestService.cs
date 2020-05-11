using AutoMapper;
using KnowledgeTestingService.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;
using KnowledgeTestingService.Common;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public class TestService : ITestService
    {
        private readonly IUnitOfWork dataStorage;
        private readonly IMapper mapper;

        public TestService(IUnitOfWork dataStorage, IMapper mapper)
        {
            this.dataStorage = dataStorage;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TestInfoDto>> GeAllTestsInfo()
        {
            var tests = await dataStorage.Tests.GetAll();
            return mapper.Map<IEnumerable<TestInfoDto>>(tests);
        }

        public async Task<IEnumerable<TestInfoDto>> GeAllTestsInfo(int offset, int count)
        {
            var tests = await dataStorage.Tests.GetAll(offset, count);
            return mapper.Map<IEnumerable<TestInfoDto>>(tests);
        }

        public async Task<Result<FullTestDto>> GetFullTest(int id)
        {
            var test = await dataStorage.Tests.GetAsync(id);
            if (test is null)
            {
                return Result.Fail<FullTestDto>(-1);
            }

            var fullTestDto = mapper.Map<FullTestDto>(test);
            return Result.Ok(fullTestDto);
        }

        public async Task<Result<TestInfoDto>> GeTestInfo(int id)
        {
            var test = await dataStorage.Tests.GetAsync(id);
            if (test is null)
            {
                return Result.Fail<TestInfoDto>(-1);
            }

            var testInfoDto = mapper.Map<TestInfoDto>(test);
            return Result.Ok(testInfoDto);
        }

        public async Task<long> GetTestsCount()
        {
            return await dataStorage.Tests.LongCountAsync();
        }
    }
}