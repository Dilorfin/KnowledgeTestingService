﻿namespace KnowledgeTestingService.API.Models.Test
{
    public class AnswerModel
    {
        public int Id { get; set; }

        public string AnswerText { get; set; }

        public int QuestionId { get; set; }
    }
}