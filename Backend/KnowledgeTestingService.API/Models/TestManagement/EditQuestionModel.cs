using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.TestManagement
{
    public class EditQuestionModel
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public IEnumerable<EditAnswerModel> Answers { get; set; }
    }
}