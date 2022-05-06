using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Brudnopis
{
    internal class ExpessionsTest
    {
        Func<int, bool> comparer = num => num < 5;

        Expression<Func<int, bool>> comparerExpression = num => num < 5;

        internal void RunTest()
        {
            var t1 = comparer.Invoke(5);

            var ce = comparerExpression.Compile();
            var t2 = ce.Invoke(5);

            var numParam = Expression.Parameter(typeof(int), "num");
            Expression<Func<int, bool>> comparerExpression2 =
                Expression.Lambda<Func<int, bool>>(
                    Expression.LessThan(
                        numParam,
                        Expression.Constant(5)),
                    numParam);
            var ce2 = comparerExpression2.Compile();
            var t3 = ce2.Invoke(5);
        }
    }

    [TestClass]
    public class ExrpessionTest
    {
        [TestMethod]
        public void RunTest()
        {
            new ExpessionsTest().RunTest();
        }
    }
}
