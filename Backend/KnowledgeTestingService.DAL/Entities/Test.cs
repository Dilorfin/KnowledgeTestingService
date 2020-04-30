using KnowledgeTestingService.DAL.Entities.Base;
using System;
using System.Collections.Generic;

namespace KnowledgeTestingService.DAL.Entities
{
    public class Test : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Time { get; set; }

        public ICollection<Question> Questions { get; set; }
        public ICollection<TestResult> TestResults { get; set; }
    }
}