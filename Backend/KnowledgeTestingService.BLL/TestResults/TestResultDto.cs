namespace KnowledgeTestingService.BLL.TestResults
{
    public class TestResultDto
    {
        public int Id { get; set; }

        public string TestTitle { get; set; }

        public long AttemptDate { get; set; }
        public double Result { get; set; }
    }
}