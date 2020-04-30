using KnowledgeTestingService.DAL.Entities.Base;

namespace KnowledgeTestingService.DAL.Entities
{
    public class Answer : Entity
    {
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
        public Question Question { get; set; }
    }
}