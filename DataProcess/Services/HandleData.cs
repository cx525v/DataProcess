using DataProcess.Models;
using System.Collections.Generic;
using System;

namespace DataProcess.Services
{
    public class HandleData : IHandleData
    {
        private readonly IDeviceDataHandler _deviceDataHandler;
        private readonly ITrackerDataHandler _trackerDataHandler;          
        public HandleData(IDeviceDataHandler deviceDataHandler, ITrackerDataHandler trackerDataHandler)
        {
            this._deviceDataHandler = deviceDataHandler;
            this._trackerDataHandler = trackerDataHandler;

        }


        //convert data from the first jason file
        private List<SensorStat> GetTrackerStat(string trackerFile)
        {
            List<SensorStat> sensorStats = new List<SensorStat>();

            var trackerRecord = _trackerDataHandler.GetTrackerRecord(trackerFile);
            int companyId = trackerRecord.PartnerId;
            string companyName = trackerRecord.PartnerName;
         
            trackerRecord.Trackers?.ForEach(trkr =>
            {
                var trackerId = trkr.Id;
                var trackerName = trkr.Model;
                var startDate = trkr.ShipmentStartDtm;
                SensorStat sensorStat = new SensorStat();
                sensorStat.CompanyId = companyId;
                sensorStat.CompanyName = companyName;
                sensorStat.TrackerName = trackerName;
                sensorStat.TrackerId = trackerId;
                sensorStat.StartDate = startDate;
         
                int tempCount = 0;
                double temp = 0;
                int humidityCount = 0;
                double humidity = 0;
                DateTime? firstCrumbDtm = null;
                DateTime? lastCrumbDtm = null;
                trkr.Sensors?.ForEach(sensor =>
                {      

                    if (sensor.Name == "Temperature")
                    {
                        sensor.Crumbs.ForEach(crumb =>
                        {
                          
                            if (!firstCrumbDtm.HasValue || crumb.CreatedDtm < firstCrumbDtm)
                            {
                                firstCrumbDtm = crumb.CreatedDtm;
                            }

                         
                            if (!lastCrumbDtm.HasValue || crumb.CreatedDtm > lastCrumbDtm)
                            {
                                lastCrumbDtm = crumb.CreatedDtm;
                            }

                            tempCount++;
                            temp += crumb.Value;
                        });

                    }
                    else if (sensor.Name == "Humidty")
                    {
                        sensor.Crumbs?.ForEach(crumb =>
                        {
                            if (crumb.CreatedDtm < firstCrumbDtm)
                            {
                                firstCrumbDtm = crumb.CreatedDtm;
                            }

                            if (crumb.CreatedDtm > lastCrumbDtm)
                            {
                                lastCrumbDtm = crumb.CreatedDtm;
                            }

                            humidityCount++;
                            humidity += crumb.Value;
                        });
                    }

                });

                sensorStat.FirstCrumbDtm = firstCrumbDtm;
                sensorStat.LastCrumbDtm = lastCrumbDtm;

                if (tempCount != 0)
                {
                    sensorStat.TempCount = tempCount;
                    sensorStat.AvgTemp = Round(temp / tempCount);
                }

                if (humidityCount != 0)
                {
                    sensorStat.HumidityCount = humidityCount;
                    sensorStat.AvgHumidity = Round(humidity / humidityCount);
                }

                sensorStats.Add(sensorStat);

            });

           
            return sensorStats;
        }


        //convert data from second json file
        private List<SensorStat> GetDevicesStat(string deviceFile)
        {
            List<SensorStat> sensorStats = new List<SensorStat>();
            var deviceRecord = _deviceDataHandler.GetDeviceRecord(deviceFile);
            var companyId = deviceRecord.CompanyId;
            var companyName = deviceRecord.Company;

            deviceRecord.Devices?.ForEach(device =>
            {
                var trackerId = device.DeviceID;
                var trackerName = device.Name;
                var startDate = device.StartDateTime;

                SensorStat sensorStat = new SensorStat();
                sensorStat.CompanyId = companyId;
                sensorStat.CompanyName = companyName;
                sensorStat.TrackerId = trackerId;
                sensorStat.StartDate = startDate;
                sensorStat.TrackerName = trackerName;

                int tempCount = 0;
                double temp = 0;
                int humidityCount = 0;
                double humidity = 0;
                DateTime? firstCrumbDtm = null;
                DateTime? lastCrumbDtm = null;

                device.SensorData?.ForEach(sensor =>
                {
                    if(sensor.SensorType == "TEMP")
                    {
                        tempCount++;
                        temp += sensor.Value;

                    } else if(sensor.SensorType == "HUM")
                    {
                        humidityCount++;
                        humidity += sensor.Value;
                    }

                    if (!firstCrumbDtm.HasValue || sensor.DateTime < firstCrumbDtm)
                    {
                        firstCrumbDtm = sensor.DateTime;
                    }

                    if (!lastCrumbDtm.HasValue || sensor.DateTime > lastCrumbDtm)
                    {
                        lastCrumbDtm = sensor.DateTime;
                    }
                });

                if (tempCount != 0)
                {
                    sensorStat.TempCount = tempCount;
                    sensorStat.AvgTemp = Round(temp / tempCount);
                }

                if (humidityCount != 0)
                {
                    sensorStat.HumidityCount = humidityCount;
                    sensorStat.AvgHumidity = Round(humidity / humidityCount);
                }

                sensorStat.FirstCrumbDtm = firstCrumbDtm;
                sensorStat.LastCrumbDtm = lastCrumbDtm;


                sensorStats.Add(sensorStat);
            });

            return sensorStats;

        }

        private double Round(double value)
        {
            return Math.Round(value, 2);
        }



        public List<SensorStat> MergeData(string trackerFile, string deviceFile)
        {

            List<SensorStat> trackerStat = GetTrackerStat(trackerFile);
            List<SensorStat> deviceStat = GetDevicesStat(deviceFile);

            List<SensorStat> result = new List<SensorStat>();

            result.AddRange(trackerStat);
            result.AddRange(deviceStat);

            return result;

        }
    }
}
