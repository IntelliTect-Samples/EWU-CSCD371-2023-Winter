using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_07_LINQ;
[TestClass]
public class DeferredExecution
{
    [TestMethod]
    public void MyTestMethod()
    {
        int count = 0;
        List<int> numbers = Enumerable.Range(1, 10).ToList();
        Assert.AreEqual(10, numbers.Count);
        IEnumerable<int> evens = numbers.Where(item =>
        {
            count++;
            return item % 2 == 0;

        });
        IEnumerable<int> triples = evens.Where(item =>
        {
            count++;
            return item % 3 == 0;

        });
        Assert.AreEqual<int>(1, triples.Count());

        Assert.AreEqual<int>(15, count);
    }
}
