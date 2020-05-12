using KnowledgeTestingService.API.Models.Test.Answer;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.Test.Question
{
    public class QuestionModel
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public IEnumerable<AnswerModel> Answers { get; set; }
    }
}