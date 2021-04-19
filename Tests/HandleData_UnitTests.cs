using DataProcess.DataAccess;
using DataProcess.Models.Device;
using DataProcess.Models.Tracker;
using DataProcess.Services;
using Moq;
using NUnit.Framework;
namespace Tests
{
    [TestFixture]
    public class HandleData_UnitTests
    {
        HandleData handleData;


        [SetUp]
        public void SetUp()
        {
            DeviceRecord mockDataDevice = new DeviceRecord();
            mockDataDevice.CompanyId = 1;
            mockDataDevice.Company = "Test1";
          

            TrackerRecord mockDataTracker = new TrackerRecord();
            mockDataTracker.PartnerId = 2;
            mockDataTracker.PartnerName = "Test2";



            Mock<ITrackerDataHandler> mockTrackerHandler = new Mock<ITrackerDataHandler>();
            Mock<IDeviceDataHandler> mockDeviceHandler = new Mock<IDeviceDataHandler>();

            mockTrackerHandler.Setup(x => x.GetTrackerRecord(It.IsAny<string>())).Returns(mockDataTracker);

            mockDeviceHandler.Setup(x => x.GetDeviceRecord(It.IsAny<string>())).Returns(mockDataDevice);

            handleData = new HandleData(mockDeviceHandler.Object, mockTrackerHandler.Object);

        }

        [Test]
        public void GettContent_Test()
        {
            var result = handleData.MergeData("","");

            Assert.AreEqual(0, result.Count);
        }

        // more testing
    }
}
