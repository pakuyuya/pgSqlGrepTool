using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pkSqlGrepTool.appcore
{
    public class TempFileHolder
    {
        public static TempFileHolder Global = new TempFileHolder();

        public TempFileHolder()
        {

        }

        ~TempFileHolder()
        {
            clearTempFiles();
        }

        private List<string> pathes = new List<string>();
        
        public string NewFile(string ext)
        {
            // 恐ろしい実装
            while (true)
            {
                var filename = "tmp" + Path.GetRandomFileName() + ext;
                var newp = Path.Combine(Path.GetTempPath(), filename);

                if (!File.Exists(newp))
                {
                    pathes.Add(newp);
                    return newp;
                }
            }

        }

        public void clearTempFiles()
        {
            Parallel.ForEach(pathes, (p) =>
            {
                if (File.Exists(p))
                {
                    try
                    {
                        File.Delete(p);
                    }
                    catch (IOException)
                    {
                        // do nothing
                    }
                }
            });
            
        }
    }
}
