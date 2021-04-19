using DataProcess.DataAccess;
using DataProcess.FiileMgnt;
using DataProcess.Models.Device;
using DataProcess.Models.Tracker;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.IO;
using System.Text;
namespace Tests
{
    [TestFixture]
    public class JsonObjectReader_unitTests
    {
        JsonObjectReader<TrackerRecord> jsonObjectReaderTracker;
        JsonObjectReader<DeviceRecord> jsonObjectReaderDevice;
        string mockTrackerPath = "MockTracker.json";
        string mockDevicePath = "MockDevice.json";
        string mockTrackerData;
        string mockDeviceData;

        [SetUp]
        public void SetUp()
        {
        
            var srTracker = new StreamReader(mockTrackerPath);
            mockTrackerData = srTracker.ReadToEnd();

            var srDevice = new StreamReader(mockDevicePath);
            mockDeviceData = srDevice.ReadToEnd();

            Mock<IFileMgr> mockFileMgr = new Mock<IFileMgr>();


            mockFileMgr.Setup(fm => fm.GetContent(mockTrackerPath)).Returns(mockTrackerData);

            mockFileMgr.Setup(fm => fm.GetContent(mockDevicePath)).Returns(mockDeviceData);

            jsonObjectReaderTracker = new JsonObjectReader<TrackerRecord>(mockFileMgr.Object);

            jsonObjectReaderDevice = new JsonObjectReader<DeviceRecord>(mockFileMgr.Object);

        }

        [Test]
        public void GetData_Test()
        {
            var result1 = jsonObjectReaderTracker.GetData(mockTrackerPath);
            var expected1 = JsonConvert.DeserializeObject<TrackerRecord>(mockTrackerData);
            Assert.AreEqual(JsonConvert.SerializeObject(expected1), JsonConvert.SerializeObject(result1));


            var result2 = jsonObjectReaderDevice.GetData(mockDevicePath);
            var expected2 = JsonConvert.DeserializeObject<DeviceRecord>(mockDeviceData);
            Assert.AreEqual(JsonConvert.SerializeObject(expected2), JsonConvert.SerializeObject(result2));

        }
    }
}
