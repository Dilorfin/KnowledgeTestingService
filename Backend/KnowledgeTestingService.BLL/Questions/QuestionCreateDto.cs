using KnowledgeTestingService.BLL.Answers;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Questions
{
    public class QuestionCreateDto
    {
        public int TestId { get; set; }

        public string QuestionText { get; set; }

        public IEnumerable<AnswerCreateDto> Answers { get; set; }
    }
}