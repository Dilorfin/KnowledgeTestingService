using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.TestManagement
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