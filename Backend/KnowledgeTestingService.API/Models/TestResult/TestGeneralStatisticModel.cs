namespace KnowledgeTestingService.API.Models.TestResult
{
    public class TestGeneralStatisticModel
    {
        public int TestId { get; set; }
        public string TestTitle { get; set; }
        public double ResultsAverage { get; set; }
        public int AttemptsNumber { get; set; }       
    }
}