using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;

namespace DataSerialization.JSON
{
    public class EnumeratedDevices
    {
        public List<Device> Devices { get; set; }
    }

    public class Device
    {
        public string Name { get; set; }
        public string Model { get; set; }
        public string Vendor { get; set; }
        public string Serial_Number { get; set; }

        public Device(string name, string model, string vendor, string serialNumber)
        {
            Name = name;
            Model = model;
            Vendor = vendor;
            Serial_Number = serialNumber;
        }
    }
    public class JSONHelper
    {
        private EnumeratedDevices enumeratedDevices { get; set; }

        public JSONHelper(string[] deviceNames, string[] deviceModels, string[] serialNumbers, int noOfEntriesToGenerate)
        {
            List<Device> devices = new List<Device>();
            int noOfDeviceNames = deviceNames.Length;
            for (int i = 0; i < noOfEntriesToGenerate; i++)
            {
                devices.Add(new Device(deviceNames[i % noOfDeviceNames], deviceModels[i % noOfDeviceNames], "NationalInstruments", serialNumbers[i % noOfDeviceNames]));
            }
            enumeratedDevices = new EnumeratedDevices();
            enumeratedDevices.Devices = devices;
        }

        public TimeSpan Serialize(string basePath)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string serializedJson = JsonConvert.SerializeObject(enumeratedDevices);
            sw.Stop();
            File.WriteAllText(Path.Combine(basePath, "SerializedJSON.json"), serializedJson);
            return sw.Elapsed;
        }

        public TimeSpan DeSerialize(string basePath)
        {
            string contentsToDeSerialize = File.ReadAllText(Path.Combine(basePath, "SerializedJSON.json"));
            Stopwatch sw = new Stopwatch();
            sw.Start();
            JsonConvert.DeserializeObject(contentsToDeSerialize);
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
