using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Assignment.Tests;

[TestClass]
public class AddressTests
{
    readonly Address testAddress = new("4127 S. Sullivan Rd", "Veradale", "WA", "99037");

    [TestMethod]
    public void Address_SetsProperties_Success()
    {
        Assert.AreEqual<string>("4127 S. Sullivan Rd", testAddress.StreetAddress);
        Assert.AreEqual<string>("Veradale", testAddress.City);
        Assert.AreEqual<string>("WA", testAddress.State);
        Assert.AreEqual<string>("99037", testAddress.Zip);
    }

    [TestMethod]
    public void Address_ToStringOverride_Works()
    {
        Assert.AreEqual<string>("4127 S. Sullivan Rd, Veradale WA, 99037", testAddress.ToString());
    }
}
