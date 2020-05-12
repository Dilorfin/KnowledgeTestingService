using KnowledgeTestingService.API.Models.Test.Answer;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.Test.Question
{
    public class EditQuestionModel
    {
        public int Id { get; set; }

        public int TestId { get; set; }
        public string QuestionText { get; set; }

        public IEnumerable<EditAnswerModel> Answers { get; set; }
    }
}