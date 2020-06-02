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
        private readonly ITestValidator testValidator;
        private readonly IMapper mapper;

        public TestService(IUnitOfWork dataStorage, ITestValidator testValidator,IMapper mapper)
        {
            this.dataStorage = dataStorage;
            this.testValidator = testValidator;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TestInfoDto>> GetTestsInfoRange(int offset, int count)
        {
            var tests = await dataStorage.Tests.GetRange(offset, count);
            return mapper.Map<IEnumerable<TestInfoDto>>(tests);
        }

        public async Task<IEnumerable<TestInfoDto>> GetTestsInfoRange(int offset, int count, string filter)
        {
            var tests = await dataStorage.Tests.GetRange(offset, count, filter);
            return mapper.Map<IEnumerable<TestInfoDto>>(tests);
        }

        public async Task<long> GetTestsCount()
        {
            return await dataStorage.Tests.LongCountAsync();
        }

        public async Task<long> GetTestsCount(string filter)
        {
            return await dataStorage.Tests.LongCountAsync(filter);
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

        public async Task<Result> AddTest(AddTestDto addTestDto)
        {
            var validationResult = testValidator.ValidateAddTestDto(addTestDto);
            if (validationResult.Failure)
            {
                return validationResult;
            }

            var test = mapper.Map<Test>(addTestDto);
            dataStorage.Tests.Add(test);

            await dataStorage.SaveChangesAsync();
            
            return Result.Ok();
        }

        public async Task<Result> UpdateTest(EditTestDto editTestDto)
        {
            var validationResult = testValidator.ValidateEditTestDto(editTestDto);
            if (validationResult.Failure)
            {
                return validationResult;
            }

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
    }
}