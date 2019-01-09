using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using pkSqlGrepTool.Properties;
using System.IO;

namespace pkSqlGrepTool.appcore
{
    public static class Global
    {
        /// <summary>
        /// Load application name from config file.
        /// </summary>
        /// <returns>caption text, or empty string when failed to read file.</returns>
        public static Task<string> GetAppName()
        {
            return Task.Factory.StartNew(() =>
            {
                string filename = Settings.Default.File_TitleCaption;
                if (!File.Exists(filename) || Directory.Exists(filename))
                {
                    return "";
                }

                try
                {
                    return System.IO.File.ReadAllText(filename);
                }
                catch (Exception ex)
                {
                    return "";
                }
            });
        }
    }
}
