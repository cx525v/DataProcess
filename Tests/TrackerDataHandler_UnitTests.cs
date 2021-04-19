using DataProcess.DataAccess;
using DataProcess.Models.Tracker;
using DataProcess.Services;
using Moq;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class TrackerDataHandler_UnitTests
    {
        TrackerDataHandler dataHandler;
        string path = "MockTracker.json";

        [SetUp]
        public void SetUp()
        {
            TrackerRecord mockData = new TrackerRecord();
            mockData.PartnerId = 1;
            mockData.PartnerName = "Test";

            Mock<IJsonObjectReader<TrackerRecord>> jsonReader = new Mock<IJsonObjectReader<TrackerRecord>>();
            jsonReader.Setup(x => x.GetData(path)).Returns(mockData);
            dataHandler = new TrackerDataHandler(jsonReader.Object);
        }


        [Test]
        public void getTrackerRecord_Test()
        {
          var result =  dataHandler.GetTrackerRecord(path);
            Assert.AreEqual(1, result.PartnerId);
            Assert.AreEqual("Test", result.PartnerName);
        }
    }
}
