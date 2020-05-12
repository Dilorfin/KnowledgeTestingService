namespace KnowledgeTestingService.BLL.Answers
{
    public class EditAnswerDto
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int QuestionId { get; set; }

        public bool IsCorrect { get; set; }
    }
}