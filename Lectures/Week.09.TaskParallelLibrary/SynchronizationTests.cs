using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskParallelLibrary;
[TestClass]
public class SynchronizationTests
{
    static int _Count = 0;
    [TestMethod]
    public void Count_StaticField_Synchronized()
    {
        Object locker = new();

        int count = 0;
        for (int i = 0; i < 1000; i++)
        {
            Task decrementCount = Task.Run(() =>
            {
                lock (locker)
                {
                    count--;
                }
            });
            Task incrementCount = Task.Run(() =>
            {
                lock (locker)
                {
                    count++;
                }
            });
            Task.WaitAll(decrementCount, incrementCount);
        }
        //Assert
        Assert.AreNotEqual<int>(0, count);
    }
    public static void DecrementCount()
    {
        _Count--;
    }
    public static void IncrementCount()
    {
        _Count++;
    }
}
