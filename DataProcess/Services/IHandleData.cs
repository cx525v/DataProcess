using DataProcess.Models;
using System.Collections.Generic;

namespace DataProcess.Services
{
   public interface IHandleData
    {
        List<SensorStat> MergeData(string trackerFile, string deviceFile);
    }
}
