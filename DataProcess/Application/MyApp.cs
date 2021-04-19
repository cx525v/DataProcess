using DataProcess.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataProcess.Application
{
    class MyApp
    {
        private readonly IHandleData _merge;
        public MyApp(IHandleData merge)
        {
            _merge = merge;
        }

     
        public void Run()
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;

           var data = _merge.MergeData(basePath + "Data\\TrackerDataFoo1.json", basePath + "Data\\TrackerDataFoo2.json");

            Console.WriteLine(JsonConvert.SerializeObject(data));

            Console.Read();
        }
    }
}
