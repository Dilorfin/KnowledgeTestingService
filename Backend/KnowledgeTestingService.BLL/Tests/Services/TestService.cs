using AutoMapper;
using KnowledgeTestingService.Common;
using KnowledgeTestingService.DAL.Entities;
using KnowledgeTestingService.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Result<EditTestDto>> GetEditTest(int id)
        {
            var test = await dataStorage.Tests.GetAsync(id);
            if (test is null)
            {
                return Result.Fail<EditTestDto>(-1);
            }

            var editTestDto = mapper.Map<EditTestDto>(test);
            return Result.Ok(editTestDto);
        }

        public async Task<Result> AddTest(EditTestDto editTestDto)
        {
            var test = mapper.Map<Test>(editTestDto);
            dataStorage.Tests.Add(test);

            await dataStorage.SaveChangesAsync();
            
            return Result.Ok();
        }

        public async Task<Result> UpdateTest(EditTestDto editTestDto)
        {
            var questions = mapper.Map<IEnumerable<Question>>(editTestDto.Questions);
            var storedTest = await dataStorage.Tests.GetAsync(editTestDto.Id);
            var except = storedTest.Questions.Where(st => questions.FirstOrDefault(q => q.Id == st.Id) is null);

            foreach (var question in except)
            {
                dataStorage.Questions.Delete(question);
            }
            
            
            var enumerable = storedTest.Questions.SelectMany(
                sq => sq.Answers.Where(st=> questions.SelectMany(q=>q.Answers).FirstOrDefault(a => a.Id == st.Id) is null)
            );

            foreach (var answer in enumerable)
            {
                dataStorage.Answers.Delete(answer);
            }
            
            storedTest.Questions = questions as ICollection<Question>;
            
            storedTest.Title = editTestDto.Title;
            storedTest.Time = TimeSpan.FromMilliseconds(editTestDto.Time);
            storedTest.Description = editTestDto.Description;

            dataStorage.Tests.Update(storedTest);
            
            await dataStorage.SaveChangesAsync();
            return Result.Ok();
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