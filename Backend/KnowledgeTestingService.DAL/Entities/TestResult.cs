using KnowledgeTestingService.DAL.Entities.Base;
using System;

namespace KnowledgeTestingService.DAL.Entities
{
    public class TestResult : Entity
    {
        public string UserId { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public DateTime AttemptDate { get; set; }
        public double Result { get; set; }
    }
}