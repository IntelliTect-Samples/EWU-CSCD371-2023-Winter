using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Calculate.Tests;

[TestClass]
public class ProgramTests
{
    [TestMethod]
    public void ReadLineWriteLine_SetInConstructor_BehavesAsExpected()
    {
        string testReadStringExp = "See me now, a ray of light in the moon-dance...";
        string testWriteStringExp = "She faded into a flower, that would bloom for one bright eve...";
        string testWriteStringAct = "";
        Program TestProgram = new()
        {
            WriteLine = (input) => { testWriteStringAct = input; },
            ReadLine = () => { return testReadStringExp; }
        };
        string testReadStringAct = TestProgram.ReadLine();
        TestProgram.WriteLine(testWriteStringExp);
        Assert.AreEqual<string>(testReadStringExp, testReadStringAct);
        Assert.AreEqual<string>(testWriteStringExp, testWriteStringAct);
    }
}