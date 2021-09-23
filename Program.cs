using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataSerialization.Avro;
using DataSerialization.FlatBuffers;
using DataSerialization.JSON;
using DataSerialization.ProtoBuf;
using DataSerialization.Thrift;
using DataSerialization.XML;

namespace DataSerializationTests
{
    class Program
    {
        private static string[] DeviceNames = { "PXI System", "cRIO System", "DAQ System" };
        private static string[] DeviceModels = { "PXI - 8765", "cRIO - 9880", "DAQ - 7854" };
        private static string[] SerialNumbers = { "253698", "785236", "142536" };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Data Serialization Tests");
            Console.WriteLine("--------------------------------------------------\n");
            int numrecordsToSerialize = 1000;
            var basePathForSerializedData = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "DataSerializationTestResults");
            EnsureDirectoryExistsAndIsEmpty(basePathForSerializedData);

            Console.WriteLine("Serializing Data using XML");
            Console.WriteLine("--------------------------------------------------");
            XMLHelpers xmlHelper = new XMLHelpers(DeviceNames, DeviceModels, SerialNumbers, numrecordsToSerialize);
            var timeToSerialize = xmlHelper.Serialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to Serialize is : " + timeToSerialize.Ticks.ToString());
            var timeToDeserialize = xmlHelper.DeSerialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to DeSerialize is : " + timeToDeserialize.Ticks.ToString());
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("Serializing Data using JSON");
            Console.WriteLine("--------------------------------------------------");
            JSONHelper jsonHelper = new JSONHelper(DeviceNames, DeviceModels, SerialNumbers, numrecordsToSerialize);
            timeToSerialize = jsonHelper.Serialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to Serialize is : " + timeToSerialize.Ticks.ToString());
            timeToDeserialize = jsonHelper.DeSerialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to DeSerialize is : " + timeToDeserialize.Ticks.ToString());
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("Serializing Data using Protocol Buffers");
            Console.WriteLine("--------------------------------------------------");
            ProtoBufHelper protoBufHelper = new ProtoBufHelper(DeviceNames, DeviceModels, SerialNumbers, numrecordsToSerialize);
            timeToSerialize = protoBufHelper.Serialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to Serialize is : " + timeToSerialize.Ticks.ToString());
            timeToDeserialize = protoBufHelper.DeSerialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to DeSerialize is : " + timeToDeserialize.Ticks.ToString());
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("Serializing Data using Thrift");
            Console.WriteLine("--------------------------------------------------");
            ThriftHelpers thriftHelper = new ThriftHelpers(DeviceNames, DeviceModels, SerialNumbers, numrecordsToSerialize);
            timeToSerialize = thriftHelper.Serialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to Serialize is : " + timeToSerialize.Ticks.ToString());
            timeToDeserialize = thriftHelper.DeSerialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to DeSerialize is : " + timeToDeserialize.Ticks.ToString());
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("Serializing Data using Avro");
            Console.WriteLine("--------------------------------------------------");
            AvroHelpers avroHelper = new AvroHelpers(DeviceNames, DeviceModels, SerialNumbers, numrecordsToSerialize);
            timeToSerialize = avroHelper.Serialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to Serialize is : " + timeToSerialize.Ticks.ToString());
            timeToDeserialize = avroHelper.DeSerialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to DeSerialize is : " + timeToDeserialize.Ticks.ToString());
            Console.WriteLine("--------------------------------------------------\n");

            Console.WriteLine("Serializing Data using FlatBuffers");
            Console.WriteLine("--------------------------------------------------");
            FlatBufferHelpers flatBufferHelper = new FlatBufferHelpers(DeviceNames, DeviceModels, SerialNumbers, numrecordsToSerialize);
            timeToSerialize = flatBufferHelper.Serialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to Serialize is : " + timeToSerialize.Ticks.ToString());
            timeToDeserialize = flatBufferHelper.DeSerialize(basePathForSerializedData);
            Console.WriteLine("Time Taken to DeSerialize is : " + timeToDeserialize.Ticks.ToString());
            Console.WriteLine("--------------------------------------------------\n");

            var deviceName = flatBufferHelper.GetDeviceNameAtIndex(basePathForSerializedData, 25);
        }

        private static void EnsureDirectoryExistsAndIsEmpty(string basePathForSerializedData)
        {
            var resultDirInfo = Directory.CreateDirectory(basePathForSerializedData);
            var fileInDirectory = Directory.EnumerateFileSystemEntries(basePathForSerializedData);
            if (fileInDirectory.Any())
            {
                foreach (var file in fileInDirectory)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
