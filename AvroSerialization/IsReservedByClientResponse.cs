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

    public partial class IsReservedByClientResponse : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse("{\"type\":\"record\",\"name\":\"IsReservedByClientResponse\",\"namespace\":\"test.avro\",\"fie" +
				"lds\":[{\"name\":\"is_reserved\",\"type\":\"boolean\"}]}");
		private bool _is_reserved;
		public virtual Schema Schema
		{
			get
			{
				return IsReservedByClientResponse._SCHEMA;
			}
		}
		public bool is_reserved
		{
			get
			{
				return this._is_reserved;
			}
			set
			{
				this._is_reserved = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.is_reserved;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.is_reserved = (System.Boolean)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}