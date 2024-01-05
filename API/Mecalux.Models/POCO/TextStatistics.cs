using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mecalux.Models.POCO
{
    public class TextStatistics
    {
        public int hyphensQuantity { get; set; }
        public int wordQuantity { get; set; }
        public int spacesQuantity { get; set; }

        public TextStatistics(string text)
        {
            GenerateStatistics(text);
        }

        public TextStatistics()
        {
        }

        public void GenerateStatistics(string text)
        {
            hyphensQuantity = text.Count(x => x == '-');
            spacesQuantity = text.Count(x => x == ' ');

            char[] delimiters = new char[] { ' ', '\r', '\n', '-' };
            wordQuantity = System.Text.RegularExpressions.Regex.Split(text, @"\s{1,}").Length;
        }

        public bool Equals(Object other)
        {
            if (other == null || !this.GetType().Equals(other.GetType()))
            {
                return false;
            }
            else
            {
                TextStatistics t = (TextStatistics)other;
                return (hyphensQuantity == t.hyphensQuantity && wordQuantity == t.wordQuantity && spacesQuantity == t.spacesQuantity);
            }
        }
    }
}
