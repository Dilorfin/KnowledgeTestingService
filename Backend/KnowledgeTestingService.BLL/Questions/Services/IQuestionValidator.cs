﻿using KnowledgeTestingService.Common;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Questions.Services
{
    public interface IQuestionValidator
    {
        Result ValidateEditQuestionDto(EditQuestionDto questionDto);
        Result ValidateEditQuestionDtos(IEnumerable<EditQuestionDto> questionDtos);
    }
}