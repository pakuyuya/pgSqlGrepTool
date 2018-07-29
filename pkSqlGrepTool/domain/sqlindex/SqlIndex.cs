using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Json;

namespace pkSqlGrepTool.domain.sqlindex
{
    /// <summary>
    /// SQLの検索インデックスです
    /// </summary>
    public struct SqlIndex
    {
        public string title;
        public string sql;
        public DateTime createAt;
    }

    /// <summary>
    /// SQLファイルを読み込む機能です。
    /// </summary>
    public class SqlFileParaser
    {
        public SqlFileParaser()
        {

        }

        public List<SqlIndex> fromJson(Stream input)
        {
            var maptemplate = plainMaps();

            var setting = new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true,
            };
            var serializer = new DataContractJsonSerializer(maptemplate.GetType(), setting);

            var maps = (List < Dictionary<string, string> > )serializer.ReadObject(input);

            return maps.Select(map => map2index(map)).ToList();
        }

        private List<Dictionary<string, string>> plainMaps()
        {
            var maps = new List<Dictionary<string, string>>();
            return maps;
        }

        private SqlIndex map2index(Dictionary<string, string> map)
        {
            var idx = new SqlIndex();

            idx.createAt = new DateTime();

            idx.sql = Read(map, "sql") ?? "";

            var titles = (new List<string> { Read(map, "tag1") ?? "", Read(map, "tag2") ?? "", Read(map, "tag3") ?? "" }).Where(t => t != "").ToList();
            idx.title = string.Join("-", titles);

            return idx;
        }

        public string Read(Dictionary<string, string> map, string key)
        {
            return map.ContainsKey(key) ? map[key] : null;
        }


        public List<SqlIndex> fromCsv(Stream input)
        {
            var maptemplate = plainMaps();

            var setting = new DataContractJsonSerializerSettings()
            {
                UseSimpleDictionaryFormat = true,
            };
            var serializer = new DataContractJsonSerializer(maptemplate.GetType(), setting);

            var maps = (List<Dictionary<string, string>>)serializer.ReadObject(input);

            return maps.Select(map => map2index(map)).ToList();
        }
    }


    public static class SqlMatch
    {
        public static bool MatchBody(SqlIndex sqlIndex, string search, params Func<searchOpt, searchOpt>[] opts)
        {
            var opt = new searchOpt
            {
                regex = false,
                word = false
            };

            foreach (var optfunc in opts)
            {
                optfunc(opt);
            }

            var idx = SqlMacher.General(sqlIndex.sql, search, opt);

            return idx >= 0;
        }

        public static Func<searchOpt, searchOpt> withRegex(bool flg)
        {
            return (opt) =>
            {
                opt.regex = flg;
                return opt;
            };
        }
        public static Func<searchOpt, searchOpt> withWord(bool flg)
        {
            return (opt) =>
            {
                opt.word = flg;
                return opt;
            };
        }
    }
}
