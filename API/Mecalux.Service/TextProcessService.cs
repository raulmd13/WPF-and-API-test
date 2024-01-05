using Mecalux.Models;
using Mecalux.Models.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Mecalux.Service
{
    public class TextProcessService : ITextProcessService
    {
        public TextStatistics GenerateStatistics(string text)
        {
            return new TextStatistics(text);
        }

        public IEnumerable<string> GetAllOrderTypes()
        {
            return Enum.GetNames(typeof(OrderOption)).Cast<string>();
        }

        public bool isValidOrderOption(string orderOption)
        {
            return Enum.TryParse(orderOption, out OrderOption OrderType);
        }

        public string OrderText(string textToOrder, OrderOption orderType)
        {

            char[] delimiters = new char[] { ' ', '\r', '\n', '-' };
            List<string> words = textToOrder.Split(delimiters).ToList();

            switch (orderType)
            {
                case OrderOption.AlphabeticDesc:

                    words = words.OrderByDescending(x => x).ToList();
                    return String.Join(" ", words);

                case OrderOption.AlphabeticAsc:

                    words = words.OrderBy(x => x).ToList();
                    return String.Join(" ", words);

                case OrderOption.LenghtAsc:

                    words = words.OrderBy(x => x.Length).ToList();
                    return String.Join(" ", words);

            }

            return textToOrder;
        }
    }
}
