using KnowledgeTestingService.BLL.Answers.Services;
using KnowledgeTestingService.Common;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeTestingService.BLL.Questions.Services
{
    public class QuestionValidator : IQuestionValidator
    {
        private readonly IAnswerValidator answerValidator;

        public QuestionValidator(IAnswerValidator answerValidator)
        {
            this.answerValidator = answerValidator;
        }

        public Result ValidateEditQuestionDto(EditQuestionDto questionDto)
        {
            if (string.IsNullOrWhiteSpace(questionDto.QuestionText))
            {
                return Result.Fail(-3);
            }

            if (!questionDto.Answers.Any())
            {
                return Result.Fail(-4);
            }

            return answerValidator.ValidateEditAnswerDtos(questionDto.Answers);
        }

        public Result ValidateEditQuestionDtos(IEnumerable<EditQuestionDto> questionDtos)
        {
            if(!questionDtos.Any() 
               || !questionDtos.All(q => this.ValidateEditQuestionDto(q).Success))
            {
                return Result.Fail(-2);
            }
            return Result.Ok();
        }

        public Result ValidateAddQuestionDto(AddQuestionDto questionDto)
        {
            if (string.IsNullOrWhiteSpace(questionDto.QuestionText))
            {
                return Result.Fail(-3);
            }

            if (!questionDto.Answers.Any())
            {
                return Result.Fail(-4);
            }

            return answerValidator.ValidateAddAnswerDtos(questionDto.Answers);
        }

        public Result ValidateAddQuestionDtos(IEnumerable<AddQuestionDto> questionDtos)
        {
            if(!questionDtos.Any() 
               || !questionDtos.All(q => this.ValidateAddQuestionDto(q).Success))
            {
                return Result.Fail(-2);
            }
            return Result.Ok();
        }
    }
}