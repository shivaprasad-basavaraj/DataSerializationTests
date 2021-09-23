// ------------------------------------------------------------------------------
// <auto-generated>
//    Generated by avrogen, version 1.10.0.0
//    Changes to this file may cause incorrect behavior and will be lost if code
//    is regenerated
// </auto-generated>
// ------------------------------------------------------------------------------
namespace Test.Avro
{
	using System;
	using System.Collections.Generic;
	using System.Text;
    using global::Avro;
    using global::Avro.Specific;

    public partial class DeviceProperties : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse("{\"type\":\"record\",\"name\":\"DeviceProperties\",\"namespace\":\"test.avro\",\"fields\":[{\"na" +
				"me\":\"name\",\"type\":\"string\"},{\"name\":\"model\",\"type\":\"string\"},{\"name\":\"vendor\",\"t" +
				"ype\":\"string\"},{\"name\":\"serial_number\",\"type\":\"string\"}]}");
		private string _name;
		private string _model;
		private string _vendor;
		private string _serial_number;
		public virtual Schema Schema
		{
			get
			{
				return DeviceProperties._SCHEMA;
			}
		}
		public string name
		{
			get
			{
				return this._name;
			}
			set
			{
				this._name = value;
			}
		}
		public string model
		{
			get
			{
				return this._model;
			}
			set
			{
				this._model = value;
			}
		}
		public string vendor
		{
			get
			{
				return this._vendor;
			}
			set
			{
				this._vendor = value;
			}
		}
		public string serial_number
		{
			get
			{
				return this._serial_number;
			}
			set
			{
				this._serial_number = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.name;
			case 1: return this.model;
			case 2: return this.vendor;
			case 3: return this.serial_number;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.name = (System.String)fieldValue; break;
			case 1: this.model = (System.String)fieldValue; break;
			case 2: this.vendor = (System.String)fieldValue; break;
			case 3: this.serial_number = (System.String)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
