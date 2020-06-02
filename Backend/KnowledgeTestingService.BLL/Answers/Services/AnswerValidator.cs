using KnowledgeTestingService.Common;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeTestingService.BLL.Answers.Services
{
    public class AnswerValidator : IAnswerValidator
    {
        public Result ValidateEditAnswerDto(EditAnswerDto answerDto)
        {
            if (string.IsNullOrWhiteSpace(answerDto.AnswerText))
            {
                return Result.Fail(-7);
            }
            return Result.Ok();
        }

        public Result ValidateEditAnswerDtos(IEnumerable<EditAnswerDto> answerDtos)
        {
            if (!answerDtos.Any(a => a.IsCorrect))
            {
                return Result.Fail(-5);
            }
            if(answerDtos.Any(a => ValidateEditAnswerDto(a).Failure))
            {
                return Result.Fail(-6);
            }

            return Result.Ok();
        }

        public Result ValidateAddAnswerDto(AddAnswerDto answerDto)
        {
            if (string.IsNullOrWhiteSpace(answerDto.AnswerText))
            {
                return Result.Fail(-7);
            }
            return Result.Ok();
        }

        public Result ValidateAddAnswerDtos(IEnumerable<AddAnswerDto> answerDtos)
        {
            if (!answerDtos.Any(a => a.IsCorrect))
            {
                return Result.Fail(-5);
            }
            if(answerDtos.Any(a => ValidateAddAnswerDto(a).Failure))
            {
                return Result.Fail(-6);
            }

            return Result.Ok();
        }
    }
}