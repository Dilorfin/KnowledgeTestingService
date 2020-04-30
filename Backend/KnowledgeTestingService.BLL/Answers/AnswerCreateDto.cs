namespace KnowledgeTestingService.BLL.Answers
{
    public class AnswerCreateDto
    {
        public string AnswerText { get; set; }

        public bool IsCorrect { get; set; }

        public int QuestionId { get; set; }
    }
}