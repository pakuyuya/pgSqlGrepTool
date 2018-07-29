using Microsoft.VisualStudio.TestTools.UnitTesting;
using pkSqlGrepTool.domain.sqlindex;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace pkSqlGrepTool.domain.sqlindex.Tests
{
    [TestClass()]
    public class SqlFileParaserTests
    {
        [TestMethod()]
        public void SqlFileParaserTest()
        {
            //Assert.Fail();
        }

        struct JsonTextCase {

            public JsonTextCase(string json, Func<List<SqlIndex>, string> f)
            {
                this.json = json;
                this.f = f;
            }

            public string json;
            public Func<List<SqlIndex>, string> f;
        };

        [TestMethod()]
        public void fromJsonTest()
        {
            
            var testCases = new JsonTextCase[] {
                new JsonTextCase (
                    "[{\"sql\":\"select 1;\"}]",
                    (ary) =>
                    {
                        var row = ary[0];
                        return row.sql == "select 1;" ? "" : "sql attribute is not expected value.";
                    }
                )
            };

            foreach (var c in testCases)
            {
                var err = testJson(c.json, c.f);
                if (err != "")
                {
                    Assert.Fail(err);
                }
            }
        }

        private string testJson(string json, Func<List<SqlIndex>, string> testfunc)
        {
            var parser = new SqlFileParaser();

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var result = parser.fromJson(ms);

            return testfunc(result);
        }
    }
}