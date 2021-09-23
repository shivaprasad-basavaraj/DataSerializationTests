using FlatBuffers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataSerialization.FlatBuffers
{
    public class FlatBufferHelpers
    {
        private Offset<EnumerateDevicesResponse> _devicesResponse;
        private FlatBufferBuilder _flatBufferBuilder;

        public FlatBufferHelpers(string[] deviceNames, string[] deviceModels, string[] serialNumbers, int noOfEntriesToGenerate)
        {
            _flatBufferBuilder = new FlatBufferBuilder(1024);
            Offset<DeviceProperties>[] offsets = new Offset<DeviceProperties>[noOfEntriesToGenerate];
            int noOfDeviceNames = deviceNames.Length;
            for (int i = 0; i < noOfEntriesToGenerate; i++)
            {
                var nameOffset = _flatBufferBuilder.CreateString(deviceNames[i % noOfDeviceNames]);
                var modelOffset = _flatBufferBuilder.CreateString(deviceModels[i % noOfDeviceNames]);
                var vendorOffset = _flatBufferBuilder.CreateString("National Instruments");
                var serialNumberOffset = _flatBufferBuilder.CreateString(serialNumbers[i % noOfDeviceNames]);
                offsets[i] = DeviceProperties.CreateDeviceProperties(_flatBufferBuilder, nameOffset, modelOffset, vendorOffset, serialNumberOffset);
            }
            var devicePropertyVectorOffset = _flatBufferBuilder.CreateVectorOfTables(offsets);
            _devicesResponse = EnumerateDevicesResponse.CreateEnumerateDevicesResponse(_flatBufferBuilder, devicePropertyVectorOffset);
            _flatBufferBuilder.Finish(_devicesResponse.Value);
        }

        public TimeSpan Serialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            File.WriteAllBytes(Path.Combine(basePath, "SerializedFlatBufferData.dat"), _flatBufferBuilder.SizedByteArray());
            sw.Stop();
            return sw.Elapsed;
        }

        public TimeSpan DeSerialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            byte[] data = File.ReadAllBytes(Path.Combine(basePath, "SerializedFlatBufferData.dat"));
            ByteBuffer bb = new ByteBuffer(data);
            sw.Start();
            var enumeratedDevice = EnumerateDevicesResponse.GetRootAsEnumerateDevicesResponse(bb);
            sw.Stop();
            return sw.Elapsed;
        }

        public string GetDeviceNameAtIndex(string basePath, int index)
        {
            byte[] data = File.ReadAllBytes(Path.Combine(basePath, "SerializedFlatBufferData.dat"));
            ByteBuffer bb = new ByteBuffer(data);
            var enumeratedDevice = EnumerateDevicesResponse.GetRootAsEnumerateDevicesResponse(bb);
            var sizeOfEnumeratedDevices = Marshal.SizeOf(enumeratedDevice);
            var deviceAtIndex = enumeratedDevice.Devices(index);
            return deviceAtIndex.Value.Name;
        }
    }
}
