using Mecalux.Models;
using Mecalux.Models.POCO;

namespace Mecalux.Service
{
    public interface ITextProcessService
    {
        TextStatistics GenerateStatistics(string text);
        IEnumerable<string> GetAllOrderTypes();
        bool isValidOrderOption(string orderOption);
        string OrderText(string textToOrder, OrderOption orderType);
    }
}
