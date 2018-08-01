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
    public class CsvParserTests
    {
        [TestMethod()]
        public void ParseLineTest()
        {
            Func<string, List<string>, string> test = (raw, expect) =>
            {
                var ms = new MemoryStream(Encoding.UTF8.GetBytes(raw));
                var parser = new CsvParser();

                var result = parser.ParseLine(raw);
                ms.Close();

                return result.SequenceEqual(expect) ? "" : String.Format("expect: {0} != result: {1}", string.Join(",", expect), string.Join(",", result));
            };

            Assert.AreEqual("", test("a,b,c,d", new List<string> { "a", "b", "c", "d" }));
            Assert.AreEqual("", test("a,b\r\nc,d", new List<string> { "a", "b" }));
            Assert.AreEqual("", test("\"a\r\n\",\"b\"\r\n", new List<string> { "a\r\n", "b" }));
            Assert.AreEqual("", test("\"a\"\",b\"", new List<string> { "a\",b" }));
            Assert.AreEqual("", test("\"a\"\"\"\",b\"", new List<string> { "a\"\",b" }));
            Assert.AreEqual("", test("\"a\"\"\"\"\"\"\"\"\",b", new List<string> { "a\"\"\"\"", "b" }));
            Assert.AreEqual("", test("\"a\"\"aaa\n\"\"\n\na\",b", new List<string> { "a\"aaa\n\"\n\na", "b" }));
        }
    }
}