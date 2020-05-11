using System.Collections.Generic;

namespace KnowledgeTestingService.API.Models.Test
{
    public class UserAnswersModel
    {
        public int TestId { get; set; }

        public IEnumerable<KeyValuePair<int, int>> Answers { get; set; }
    }
}