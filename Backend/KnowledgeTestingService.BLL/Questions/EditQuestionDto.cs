using KnowledgeTestingService.BLL.Answers;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Questions
{
    public class EditQuestionDto
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public IEnumerable<EditAnswerDto> Answers { get; set; }
    }
}