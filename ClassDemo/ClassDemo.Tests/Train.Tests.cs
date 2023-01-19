namespace ClassDemo.Tests

{ [TestClass]
    public class TrainTests
    {
        [TestMethod]
        public void Create_TrainWith5Carriages_Success()
        {
            Train train = new(model: "Steam", carriages: 5);

            Assert.AreEqual(5, train.Carriages);
        }

        [TestMethod]
        public void Create_GivenTrain_IsVehicle()
        {
            Train train = new("Steam", 6);
            Assert.IsTrue(train is Vehicle);
        }

        [TestMethod]
        public void Create_GivenCarriagesAndModel_Success()
        {
            Train train = new("Bullet", 6);
            Assert.AreEqual("Bullet", train.Model);
        }

        [TestMethod]
        public void Create_GivenNoCarriage_CarriagesEquals42()
        {
            Train train = new("Bullet");

            Assert.AreEqual(42, train.Carriages);
        }
    }
}
