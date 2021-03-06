﻿using KnowledgeTestingService.Common;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Answers.Services
{
    public interface IAnswerValidator
    {
        Result ValidateEditAnswerDto(EditAnswerDto answerDto);
        Result ValidateEditAnswerDtos(IEnumerable<EditAnswerDto> answerDtos);

        Result ValidateAddAnswerDto(AddAnswerDto answerDto);
        Result ValidateAddAnswerDtos(IEnumerable<AddAnswerDto> answerDtos);
    }
}