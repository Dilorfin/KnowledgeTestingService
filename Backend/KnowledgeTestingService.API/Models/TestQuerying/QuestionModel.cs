using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.TestQuerying
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}