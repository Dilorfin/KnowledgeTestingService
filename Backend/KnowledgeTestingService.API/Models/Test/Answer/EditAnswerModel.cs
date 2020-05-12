namespace KnowledgeTestingService.API.Models.Test.Answer
{
    public class EditAnswerModel
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}