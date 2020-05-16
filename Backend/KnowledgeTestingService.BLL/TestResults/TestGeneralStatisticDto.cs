namespace KnowledgeTestingService.BLL.TestResults
{
    public class TestGeneralStatisticDto
    {
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public double ResultsAverage { get; set; }
        public int AttemptsNumber { get; set; }   
    }
}