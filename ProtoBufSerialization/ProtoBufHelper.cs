using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Google.Protobuf;

namespace DataSerialization.ProtoBuf
{
    public class ProtoBufHelper
    {
        private EnumerateDevicesResponse _devicesResponse;
        public ProtoBufHelper(string[] deviceNames, string[] deviceModels, string[] serialNumbers, int noOfEntriesToGenerate)
        {
            _devicesResponse = new EnumerateDevicesResponse();
            int noOfDeviceNames = deviceNames.Length;
            for (int i = 0; i < noOfEntriesToGenerate; i++)
            {
                DeviceProperties deviceProperties = new DeviceProperties() {
                    Name = deviceNames[i % noOfDeviceNames],
                    Model = deviceModels[i % noOfDeviceNames],
                    Vendor = "National Instruments",
                    SerialNumber = serialNumbers[i % noOfDeviceNames] };
                _devicesResponse.Devices.Add(deviceProperties);
            }
        }

        public TimeSpan Serialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            using (var stream = new FileStream(Path.Combine(basePath, "SerializedProtoBufData.dat"), FileMode.Create))
            {
                sw.Start();
                _devicesResponse.WriteTo(stream);
                sw.Stop();
            }
            return sw.Elapsed;
        }

        public TimeSpan DeSerialize(string basePath)
        {
            byte[] contentsToDeSerialize = File.ReadAllBytes(Path.Combine(basePath, "SerializedProtoBufData.dat"));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            EnumerateDevicesResponse.Parser.ParseFrom(contentsToDeSerialize);
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
