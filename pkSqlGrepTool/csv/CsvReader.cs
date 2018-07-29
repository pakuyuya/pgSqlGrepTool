using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pkSqlGrepTool.csv
{
    public class CsvReader // : TextReader
    {
        private TextReader reader;
        private CsvReadOption option;
        public CsvReader(Stream stream, params Func<CsvReadOption, CsvReadOption>[] opts)
        {
            option = new CsvReadOption();
            this.reader = new StreamReader(stream);
            foreach (var opt in opts)
            {
                option = opt(option);
            }
        }

        public string ReadLine()
        {
            StringBuilder sb = new StringBuilder();

            while (_rowstart(ref sb));

            return sb.ToString();
        }
        private bool _rowstart(ref StringBuilder sb)
        {
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
                return false;
            }

            while (_colstart(c, ref sb))
            {
                c = option.delimiter;
            }

            return false;
        }
        private bool _colstart(int prevc, ref StringBuilder sb)
        {
            int quote = -1;
            if (prevc >= 0) {
                while(option.SkipHeadSpace && Char.IsWhiteSpace((char)prevc))
                {
                    prevc = reader.Read();
                }
                if (isQuote(prevc))
                {
                    quote = prevc;
                }
            }
            if (prevc == -1 || isLineFeed(prevc))
            {
                return false;
            }
            return _coldata(prevc, quote, ref sb);
        }
        
        private bool _coldata(int prevc, int quote, ref StringBuilder sb)
        {
            if (prevc == -1)
            {
                return false;
            }
            else
            {
                sb.Append((char)prevc);
            }

            bool prevIsQuoteEnd = false;
            while (true)
            {
                bool crtIsQuoteEnd = false;
                var c = reader.Read();

                if (c == -1) {
                    return false;
                }
                else if(isLineFeed(c) && !isQuote(quote))
                {
                    return false;
                }
                else if (c == quote)
                {
                    crtIsQuoteEnd = true;
                    quote = -1;
                    sb.Append((char)c);
                }
                else if (isQuote(c))
                {
                    quote = c;
                    if (c == prevc)
                    {
                        // skip. cascaded double quote.
                    }
                    else
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
    public class CsvReadOption
    {
        public bool SkipHeadSpace = false;
        public bool IgnoreHeader = false;
        public string Quotes = "\"'";
        public char delimiter = ',';

        public static Func<CsvReadOption, CsvReadOption> withIgnoreHeader(bool flg)
        {
            return (opt) =>
            {
                opt.IgnoreHeader = true;
                return opt;
            };
        }
    }
}
