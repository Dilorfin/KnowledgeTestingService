using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.TestResults
{
    public class TestResultCreateDto
    {
        public string UserId { get; set; }

        public int TestId { get; set; }

        public IEnumerable<KeyValuePair<int, int>> Answers { get; set; }
    }
}