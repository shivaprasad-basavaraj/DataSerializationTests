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

    public partial class EnumerateDevicesRequest : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse("{\"type\":\"record\",\"name\":\"EnumerateDevicesRequest\",\"namespace\":\"test.avro\",\"fields" +
				"\":[]}");
		public virtual Schema Schema
		{
			get
			{
				return EnumerateDevicesRequest._SCHEMA;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}