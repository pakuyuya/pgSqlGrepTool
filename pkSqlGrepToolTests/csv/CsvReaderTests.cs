using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkSqlGrepTool.csv;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pkSqlGrepTool.csv.Tests
{
    [TestClass()]
    public class CsvReaderTests
    {
        [TestMethod()]
        public void ReadLineTest()
        {
            Func<string, int, string, bool> test = (string raw, int time, string expect) =>
            {
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(raw));
                var reader = new CsvReader(ms);

                string result = "";
                for (var i = 0; i < time; i++) {
                    result = reader.ReadLine();
                }
                ms.Close();

                return expect == result;
            };

            Assert.IsTrue(test("a,b,c,d", 1, "a,b,c,d"));
            Assert.IsTrue(test("a,b\r\nc,d", 1, "a,b"));
            Assert.IsTrue(test("a,b\rc,d", 1, "a,b"));
            Assert.IsTrue(test("a,b\nc,d", 1, "a,b"));
            Assert.IsTrue(test("a,b\r\nc,d", 2, "c,d"));
            Assert.IsTrue(test("a,b\rc,d", 2, "c,d"));
            Assert.IsTrue(test("a,b\nc,d", 2, "c,d"));
            Assert.IsTrue(test("a,b\r\n\r\nc,d", 2, "c,d"));
            Assert.IsTrue(test("\"a\",\"b\"", 1, "\"a\",\"b\""));
            Assert.IsTrue(test("\"a\r\n\",\"b\"", 1, "\"a\r\n\",\"b\""));
            Assert.IsTrue(test("\"a\r\n\",\"b\"\r\n", 1, "\"a\r\n\",\"b\""));
            Assert.IsTrue(test("\"a\r\n\",\"b\"\r\n", 2, ""));
        }
    }
}