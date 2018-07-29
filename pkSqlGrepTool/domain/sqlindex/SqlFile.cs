using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using pkSqlGrepTool.Properties;

namespace pkSqlGrepTool.domain.sqlindex
{
    public class SqlFile
    {
        /// <summary>
        /// Sqlファイルをリストアップします。
        /// 対象ディレクトリや対象の選定オプションはApplication Settingをもとに決定します。
        /// </summary>
        /// <returns></returns>
        public static List<string> ListupPathes()
        {
            return ListupPathes(Settings.Default.SqlFile_Directory, Settings.Default.SqlFile_ReadSubDir);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filepath"></param>
        /// <param name="reacursive"></param>
        /// <returns></returns>
        public static List<string> ListupPathes(string filepath, bool reacursive)
        {
            List<string> list = new List<string>();

            if (!Directory.Exists(filepath))
            {
                return list;
            }

            var files = Directory.GetFiles(filepath);
            list.AddRange(files);
            if (reacursive)
            {
                var dirs = Directory.GetDirectories(filepath);
                foreach (var dir in dirs)
                {
                    list.AddRange(ListupPathes(dir, reacursive));
                }
            }

            return list;
        }
    }
}
