﻿using System;

namespace KnowledgeTestingService.BLL.Tests
{
    public class TestInfoDto
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public TimeSpan Time { get; set; }
    }
}