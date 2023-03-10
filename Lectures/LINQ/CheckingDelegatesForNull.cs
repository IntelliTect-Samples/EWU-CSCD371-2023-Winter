using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week_07_LINQ;
[TestClass]

public class CheckingDelegateForNull
{
    [TestMethod]
    public void Null_Delegate_Checking()
    {
        bool isInvoked = false;
        void SetInvoked()
        {
            isInvoked = true;
        }
        //Action action = new Action(() => isInvoked = true);a
        Action action = new Action(SetInvoked);
        action();
        Assert.IsTrue(isInvoked);
    }
}
