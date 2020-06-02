using KnowledgeTestingService.BLL.Questions;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Tests
{
    public class AddTestDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public long Time { get; set; }

        public IEnumerable<AddQuestionDto> Questions { get; set; }
    }
}