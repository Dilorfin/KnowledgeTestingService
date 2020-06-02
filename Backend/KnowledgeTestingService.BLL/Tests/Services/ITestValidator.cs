using KnowledgeTestingService.Common;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public interface ITestValidator
    {
        Result ValidateEditTestDto(EditTestDto editTestDto);
        Result ValidateAddTestDto(AddTestDto addTestDto);
    }
}