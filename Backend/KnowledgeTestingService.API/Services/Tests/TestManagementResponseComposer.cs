﻿using AutoMapper;
using KnowledgeTestingService.API.Models.TestManagement;
using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestingService.API.Services.Tests
{
    public class TestManagementResponseComposer : ITestManagementResponseComposer
    {
        private readonly IMapper mapper;

        public TestManagementResponseComposer(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult ComposeForGetEditTest(Result<EditTestDto> result)
        {
            if (result.Success)
            {
                return new OkObjectResult(mapper.Map<EditTestModel>(result.Value));
            }

            if (result.Status == -1)
            {
                return new NotFoundResult();
            }

            return new BadRequestResult();
        }

        public IActionResult ComposeAddTest(Result result)
        {
            if (result.Success)
            {
                return new OkResult();
            }

            if (result.Status == -1)
            {
                return new BadRequestObjectResult("Incorrect test title.");
            }
            if (result.Status == -2)
            {
                return new BadRequestObjectResult("Some questions are incorrect.");
            }

            return new BadRequestResult();
        }

        public IActionResult ComposeUpdateTest(Result result)
        {
            if (result.Success)
            {
                return new OkResult();
            }

            if (result.Status == -1)
            {
                return new BadRequestObjectResult("Incorrect test title.");
            }
            if (result.Status == -2)
            {
                return new BadRequestObjectResult("Some questions are incorrect.");
            }

            return new BadRequestResult();
        }
    }
}