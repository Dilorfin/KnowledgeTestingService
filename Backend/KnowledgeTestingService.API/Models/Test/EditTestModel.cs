using KnowledgeTestingService.API.Models.Test.Question;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.Test
{
    public class EditTestModel
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public long Time { get; set; }

        public IEnumerable<EditQuestionModel> Questions { get; set; }
    }
}