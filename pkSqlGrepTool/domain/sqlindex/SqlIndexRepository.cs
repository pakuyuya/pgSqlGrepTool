using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace pkSqlGrepTool.domain.sqlindex
{
    /// <summary>
    /// SqlIndexのリポジトリ
    /// </summary>
    public class SqlIndexRepository
    {
        bool _isLoading = false;
        public bool IsLoading { get { return _isLoading; } }
        public List<SqlIndex> Sqls { get; } = new List<SqlIndex>();

        public void Clear()
        {
            Sqls.Clear();
        }
        public SqlIndexRepository Load(Func<List<SqlIndex>> loader)
        {
            _isLoading = true;
            var indices = loader();
            Sqls.AddRange(indices);
            _isLoading = false;
            return this;
        }

        public List<SqlIndex> Search(string search, params Func<searchOpt, searchOpt>[] opts)
        {
            var list = new List<SqlIndex>();
            return Sqls.Where((sql) => SqlMatch.MatchBody(sql, search, opts)).ToList();
        }
    }

    public struct searchOpt
    {
        public bool regex;
        public bool word;
        public bool ignoreCase;
        public bool includesCaption;
    }

    public static class SqlMacher
    {
        public static int General(string body, string search, searchOpt opt)
        {
            var wk_pattern = search;
            var regopt = RegexOptions.None;

            if (!opt.regex)
            {
                wk_pattern = Regex.Escape(wk_pattern);
            }

            if (opt.word)
            {
                wk_pattern = "(^|\\W)(" + wk_pattern + ")($|\\W)";
            }

            if (opt.ignoreCase)
            {
                regopt |= RegexOptions.IgnoreCase;
            }

            var reg = new Regex(wk_pattern, regopt);

            var match = reg.Match(body);
            return match.Success ? match.Index : -1;
        }
    }

    /// <summary>
    /// SqlIndexLoaderのルーチンを生成し返却します。
    /// </summary>
    public static class SqlIndexLoader
    {
        public static Func<List<SqlIndex>> FromJsonFiles(List<string> filepaths)
        {
            return () =>
            {
                var parser = new SqlFileParaser();
                var list = new List<SqlIndex>();

                foreach (var filepath in filepaths)
                {
                    if (!File.Exists(filepath) || Directory.Exists(filepath))
                    {
                        continue;
                    }

                    // TODO: Exceptionどうしよう？アプリ的にはメッセージをpipeするstreamが別口であればいいけど、うーん
                    try
                    {
                        using (var fs = File.OpenRead(filepath))
                        {
                            var readLists = parser.FromJson(fs);
                            list.AddRange(readLists);
                        }
                    }
                    catch (Exception ex)
                    {
                        // にぎりつぶして次に？
                        Console.Error.WriteLine(ex);
                    }
                }
                return list;
            };
        }
        public static Func<List<SqlIndex>> FromCsvFiles(List<string> filepaths)
        {
            return () =>
            {
                var parser = new SqlFileParaser();
                var list = new List<SqlIndex>();

                foreach (var filepath in filepaths)
                {
                    if (!File.Exists(filepath) || Directory.Exists(filepath))
                    {
                        continue;
                    }

                    // TODO: Exceptionどうしよう？アプリ的にはメッセージをpipeするstreamが別口であればいいけど、うーん
                    try
                    {
                        using (var fs = File.OpenRead(filepath))
                        {
                            var readLists = parser.FromCsv(fs);
                            list.AddRange(readLists);
                        }
                    }
                    catch (Exception ex)
                    {
                        // にぎりつぶして次に？
                        Console.Error.WriteLine(ex);
                    }
                }
                return list;
            };
        }
    }
}
