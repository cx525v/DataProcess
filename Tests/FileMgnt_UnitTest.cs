using DataProcess.FiileMgnt;
using Moq;
using NUnit.Framework;
using System.IO;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class FileMgnt_UnitTest
    {
        FileMgr fileMgr;
        [SetUp]
        public void SetUp()
        {

            Mock<IStreamReader> mockStreamReader = new Mock<IStreamReader>();
          
            byte[] fakeFileBytes = Encoding.UTF8.GetBytes("TestContent");

            MemoryStream fakeMemoryStream = new MemoryStream(fakeFileBytes);

            mockStreamReader.Setup(fileManager => fileManager.GetReader(It.IsAny<string>()))
                           .Returns(() => new StreamReader(fakeMemoryStream));

            fileMgr = new FileMgr(mockStreamReader.Object);

        }

        [Test]
        public void GettContent_Test()
        {
            var result = fileMgr.GetContent(string.Empty);
            Assert.AreEqual("TestContent", result);

        }
       
    }
}
