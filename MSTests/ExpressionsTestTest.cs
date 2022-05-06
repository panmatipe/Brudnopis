using Brudnopis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace MSTests
{
    [TestClass]
    public class ExpressionsTestTest
    {
        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void RunTest()
        {
            Stopwatch sw = new Stopwatch();
            new ExpessionsTest().RunTest();
            var t = sw.Elapsed;
        }
    }
}