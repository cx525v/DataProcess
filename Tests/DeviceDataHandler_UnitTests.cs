using DataProcess.DataAccess;
using DataProcess.Models.Device;
using DataProcess.Models.Tracker;
using DataProcess.Services;
using Moq;
using NUnit.Framework;


namespace Tests
{
    public class DeviceDataHandler_UnitTests
    {
        DeviceDataHandler dataHandler;
        string path = "MockDevice.json";

        [SetUp]
        public void SetUp()
        {
            DeviceRecord mockData = new DeviceRecord();
            mockData.CompanyId = 1;
            mockData.Company = "Test";

            Mock<IJsonObjectReader<DeviceRecord>> jsonReader = new Mock<IJsonObjectReader<DeviceRecord>>();
            jsonReader.Setup(x => x.GetData(path)).Returns(mockData);
            dataHandler = new DeviceDataHandler(jsonReader.Object);
        }


        [Test]
        public void getTrackerRecord_Test()
        {
            var result = dataHandler.GetDeviceRecord(path);
            Assert.AreEqual(1, result.CompanyId);
            Assert.AreEqual("Test", result.Company);
        }
    }
}
