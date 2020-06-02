using KnowledgeTestingService.BLL.Answers;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Questions
{
    public class AddQuestionDto
    {
        public string QuestionText { get; set; }

        public IEnumerable<AddAnswerDto> Answers { get; set; }
    }
}