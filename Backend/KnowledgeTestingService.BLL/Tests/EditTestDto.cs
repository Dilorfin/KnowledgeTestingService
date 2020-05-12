﻿using KnowledgeTestingService.BLL.Questions;
using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Tests
{
    public class EditTestDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public long Time { get; set; }

        public IEnumerable<EditQuestionDto> Questions { get; set; }
    }
}