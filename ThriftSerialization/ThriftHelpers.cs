using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Thrift;
using Thrift.Protocol;
using Thrift.Transport.Client;

namespace DataSerialization.Thrift
{
    public class ThriftHelpers
    {
        private EnumerateDevicesResponse _devicesResponse;
        public ThriftHelpers(string[] deviceNames, string[] deviceModels, string[] serialNumbers, int noOfEntriesToGenerate)
        {
            _devicesResponse = new EnumerateDevicesResponse();
            _devicesResponse.Devices = new List<DeviceProperties>();
            int noOfDeviceNames = deviceNames.Length;
            for (int i = 0; i < noOfEntriesToGenerate; i++)
            {
                DeviceProperties deviceProperties = new DeviceProperties()
                {
                    Name = deviceNames[i % noOfDeviceNames],
                    Model = deviceModels[i % noOfDeviceNames],
                    Vendor = "National Instruments",
                    Serial_number = serialNumbers[i % noOfDeviceNames]
                };
                _devicesResponse.Devices.Add(deviceProperties);
            }
        }

        public TimeSpan Serialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            using (var fileStream = new FileStream(Path.Combine(basePath, "SerializedThriftData.dat"), FileMode.Create))
            {
                using (var memStream = new MemoryStream())
                {
                    var thriftTransport = new TStreamTransport(memStream, memStream, new TConfiguration());
                    var thriftProtocol = new TCompactProtocol(thriftTransport);
                    sw.Start();
                    var response = _devicesResponse.WriteAsync(thriftProtocol, new System.Threading.CancellationToken());
                    response.Wait();
                    sw.Stop();
                    memStream.WriteTo(fileStream);
                }
            }
            return sw.Elapsed;
        }

        public TimeSpan DeSerialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            using (var fileStream = new FileStream(Path.Combine(basePath, "SerializedThriftData.dat"), FileMode.Open))
            {
                using (var memStream = new MemoryStream())
                {
                    fileStream.CopyTo(memStream);
                    memStream.Position = 0;
                    var thriftTransport = new TStreamTransport(memStream, memStream, new TConfiguration());
                    var thriftProtocol = new TCompactProtocol(thriftTransport);
                    var enumeratedDevices = new EnumerateDevicesResponse();
                    sw.Start();
                    var result = enumeratedDevices.ReadAsync(thriftProtocol, new System.Threading.CancellationToken());
                    result.Wait();
                    sw.Stop();
                }
            }
            return sw.Elapsed;
        }
    }
}

