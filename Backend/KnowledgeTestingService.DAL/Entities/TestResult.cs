using KnowledgeTestingService.DAL.Entities.Base;

namespace KnowledgeTestingService.DAL.Entities
{
    public class TestResult : Entity
    {
        public string UserId { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public double Result { get; set; }
    }
}