using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pkSqlGrepTool.csv
{
    public class CsvParser // : TextParser
    {
        private CsvParseOption option;
        public CsvParser(params Func<CsvParseOption, CsvParseOption>[] opts)
        {
            option = new CsvParseOption();
            foreach (var opt in opts)
            {
                option = opt(option);
            }
        }

        public List<string> ParseLine(string line)
        {
            var reader = new StreamReader(new MemoryStream(Encoding.UTF8.GetBytes(line)), System.Text.Encoding.GetEncoding("UTF-8"));
            return _rowstart(reader);
        }
        private List<string> _rowstart(TextReader reader)
        {
            var cols = new List<string>();
            int c;
            while (true)
            {
                c = reader.Read();
                if (!isLineFeed(c))
                {
                    break;
                }
            }
            if (c == -1)
            {
                return cols;
            }

            while (true)
            {
                var sb = new StringBuilder();
                var ret = _colstart(c, ref sb, reader);
                var col = sb.ToString();
                cols.Add(col);
                c = -2;

                if (!ret)
                {
                    break;
                }
            }

            return cols;
        }
        private bool _colstart(int prevc, ref StringBuilder sb, TextReader reader)
        {
            int quote = -1;
            if (prevc == -1)
            {
                return false;
            }

            while (option.SkipHeadSpace && Char.IsWhiteSpace((char)prevc))
            {
                prevc = reader.Read();
            }
            if (isQuote(prevc))
            {
                quote = prevc;
            }
            if (prevc == -1 || isLineFeed(prevc))
            {
                return false;
            }
            return _coldata(prevc, quote, ref sb, reader);
        }

        private bool _coldata(int prevc, int quote, ref StringBuilder sb, TextReader reader)
        {
            if (prevc >= 0 && !isQuote(prevc))
            {
                sb.Append((char)prevc);
            }

            bool prevIsQuoteEnd = false;
            while (true)
            {
                bool crtIsQuoteEnd = false;
                var c = reader.Read();

                if (c == -1)
                {
                    return false;
                }
                else if (isLineFeed(c) && !isQuote(quote))
                {
                    return false;
                }
                else if (c == quote)
                {
                    crtIsQuoteEnd = true;
                    quote = -1;
                }
                else if (isQuote(c))
                {
                    quote = c;
                    if (prevIsQuoteEnd && prevc == c)
                    {
                        sb.Append((char)c);
                    }
                }
                else if (!isQuote(quote) && c == option.delimiter)
                {
                    break;
                }
                else
                {
                    sb.Append((char)c);
                }

                prevc = c;
                prevIsQuoteEnd = crtIsQuoteEnd;
            }

            return true;
        }

        private bool isLineFeed(int c)
        {
            return c == '\r' || c == '\n';
        }
        private bool isQuote(int c)
        {
            return option.Quotes.IndexOf((char)c) >= 0;
        }
    }
    public class CsvParseOption
    {
        public bool SkipHeadSpace = false;
        public string Quotes = "\"'";
        public char delimiter = ',';
    }
}
