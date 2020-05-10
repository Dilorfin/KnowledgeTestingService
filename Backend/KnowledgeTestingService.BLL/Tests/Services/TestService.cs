using AutoMapper;
using KnowledgeTestingService.DAL.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task<FullTestDto> GetFullTest(int id)
        {
            var test = await dataStorage.Tests.GetAsync(id);
            var fullTestDto = mapper.Map<FullTestDto>(test);
            return fullTestDto;
        }

        public async Task<TestInfoDto> GeTestInfo(int id)
        {
            var test = await dataStorage.Tests.GetAsync(id);
            var testInfoDto = mapper.Map<TestInfoDto>(test);
            return testInfoDto;
        }

        public async Task<long> GetTestsCount()
        {
            return await dataStorage.Tests.LongCountAsync();
        }
    }
}