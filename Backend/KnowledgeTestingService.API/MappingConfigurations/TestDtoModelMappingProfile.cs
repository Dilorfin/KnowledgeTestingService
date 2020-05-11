﻿using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.BLL.Answers;
using KnowledgeTestingService.BLL.Questions;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.BLL.Tests;

namespace KnowledgeTestingService.API.MappingConfigurations
{
    public class TestDtoModelMappingProfile : Profile
    {
        public TestDtoModelMappingProfile()
        {
            CreateMap<FullTestDto, FullTestModel>();
            CreateMap<TestInfoDto, TestInfoModel>();
            CreateMap<QuestionDto, QuestionModel>();
            CreateMap<AnswerDto, AnswerModel>();

            CreateMap<UserAnswersModel, TestResultCreateDto>();

            CreateMap<TestResultDto, TestResultModel>();
        }
    }
}