using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.TestQuerying
{
    public class FullTestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public long Time { get; set; }

        public IEnumerable<QuestionModel> Questions { get; set; }
    }
}