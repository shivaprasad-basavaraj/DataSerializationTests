using Avro.IO;
using Avro.Specific;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Avro;

namespace DataSerialization.Avro
{
    public class AvroHelpers
    {
        private EnumerateDevicesResponse _devicesResponse;
        public AvroHelpers(string[] deviceNames, string[] deviceModels, string[] serialNumbers, int noOfEntriesToGenerate)
        {
            _devicesResponse = new EnumerateDevicesResponse();
            _devicesResponse.devices = new List<DeviceProperties>();
            int noOfDeviceNames = deviceNames.Length;
            for (int i = 0; i < noOfEntriesToGenerate; i++)
            {
                DeviceProperties deviceProperties = new DeviceProperties()
                {
                    name = deviceNames[i % noOfDeviceNames],
                    model = deviceModels[i % noOfDeviceNames],
                    vendor = "National Instruments",
                    serial_number = serialNumbers[i % noOfDeviceNames]
                };
                _devicesResponse.devices.Add(deviceProperties);
            }
        }

        public TimeSpan Serialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            using (var fileStream = new FileStream(Path.Combine(basePath, "SerializedAvroData.dat"), FileMode.Create))
            {
                using (var memStream = new MemoryStream())
                {
                    var encoder = new BinaryEncoder(memStream);
                    var writer = new SpecificDefaultWriter(_devicesResponse.Schema);
                    sw.Start();
                    writer.Write(_devicesResponse, encoder);
                    sw.Stop();
                    memStream.WriteTo(fileStream);
                }
            }
            return sw.Elapsed;
        }

        public TimeSpan DeSerialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            using (var fileStream = new FileStream(Path.Combine(basePath, "SerializedAvroData.dat"), FileMode.Open))
            {
                using (var memStream = new MemoryStream())
                {
                    fileStream.CopyTo(memStream);
                    memStream.Position = 0;
                    var decoder = new BinaryDecoder(memStream);
                    var enumeratedDevices = new EnumerateDevicesResponse();
                    var reader = new SpecificDefaultReader(_devicesResponse.Schema, _devicesResponse.Schema);
                    sw.Start();
                    reader.Read(enumeratedDevices, decoder);
                    sw.Stop();
                }
            }
            return sw.Elapsed;
        }
    }
}
