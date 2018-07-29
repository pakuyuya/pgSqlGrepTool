using pkSqlGrepTool.domain.sqlindex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pkSqlGrepTool.Properties;

namespace pkSqlGrepTool.appcore
{
    public static class SqlFileFacade
    {
        public static SqlIndexRepository SqlRepository;

        static SqlFileFacade()
        {
            InitSqlIndexRepository();
        }

        public static void InitSqlIndexRepository()
        {
            SqlRepository = new SqlIndexRepository();
        }

        public static Task RequestRefleshRepos()
        {
            return Task.Run(() =>
            {
                var pathes = SqlFile.ListupPathes();
                var loader = Settings.Default.SqlFile_Format == "json" ? SqlIndexLoader.FromJsonFiles(pathes) : SqlIndexLoader.FromCsvFiles(pathes);

                SqlRepository.Clear();
                SqlRepository.Load(loader);
            });
        }
        public static Task<List<SqlIndex>> RequestSearch(string search, params Func<searchOpt, searchOpt>[] opts)
        {
            return Task.Run(() => SqlRepository.Search(search, opts));
        }
    }
}
