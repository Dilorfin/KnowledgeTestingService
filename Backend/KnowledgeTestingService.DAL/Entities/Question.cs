using KnowledgeTestingService.DAL.Entities.Base;
using System.Collections.Generic;

namespace KnowledgeTestingService.DAL.Entities
{
    public class Question : Entity
    {
        public string QuestionText { get; set; }

        public int TestId { get; set; }
        public Test Test { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}