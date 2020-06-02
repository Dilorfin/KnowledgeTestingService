using KnowledgeTestingService.BLL.Questions.Services;
using KnowledgeTestingService.Common;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public class TestValidator : ITestValidator
    {
        private readonly IQuestionValidator questionValidator;

        public TestValidator(IQuestionValidator questionValidator)
        {
            this.questionValidator = questionValidator;
        }

        public Result ValidateEditTestDto(EditTestDto editTestDto)
        {
            if (string.IsNullOrWhiteSpace(editTestDto.Title))
            {
                return Result.Fail(-1);
            }

            return questionValidator.ValidateEditQuestionDtos(editTestDto.Questions);
        }

        public Result ValidateAddTestDto(AddTestDto addTestDto)
        {
            if (string.IsNullOrWhiteSpace(addTestDto.Title))
            {
                return Result.Fail(-1);
            }

            return questionValidator.ValidateAddQuestionDtos(addTestDto.Questions);
        }
    }
}