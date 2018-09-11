using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using pkSqlGrepTool.Properties;
using System.ComponentModel;
using System.Diagnostics;

namespace pkSqlGrepTool.appcore
{
    public class ExternalProgramFacade
    {
        /// <summary>
        /// 渡された引数をtempファイルに書き込み、設定されたファイルopenコマンドを実行します。
        /// </summary>
        /// <param name="text">tempファイルに書き込む内容</param>
        /// <returns>Start後のProcess</returns>
        /// <exception cref="Exception">コマンドが失敗した</exception>
        public static System.Diagnostics.Process OpenAsTempFile(string text)
        {
            var ext = Settings.Default.OpenTempfileExt;
            var tempFilePath = TempFileHolder.Global.NewFile(ext);

            using (var sw = new StreamWriter(File.OpenWrite(tempFilePath)))
            {
                sw.Write(text);
                sw.Flush();
            }

            var cmd = Settings.Default.OpenCommand;
            var exts = String.Format(Settings.Default.OpenArguments, tempFilePath);

            try
            {
                return System.Diagnostics.Process.Start(cmd, exts);
            }
            catch (Win32Exception ex)
            {
                throw new Exception("コマンド '" + cmd + " " + exts + "' の実行に失敗しました", ex);
            }
        }
    }
}
