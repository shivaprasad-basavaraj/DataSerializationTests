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

    public partial class ResetServerResponse : ISpecificRecord
	{
		public static Schema _SCHEMA = Schema.Parse("{\"type\":\"record\",\"name\":\"ResetServerResponse\",\"namespace\":\"test.avro\",\"fields\":[{" +
				"\"name\":\"is_server_reset\",\"type\":\"boolean\"}]}");
		private bool _is_server_reset;
		public virtual Schema Schema
		{
			get
			{
				return ResetServerResponse._SCHEMA;
			}
		}
		public bool is_server_reset
		{
			get
			{
				return this._is_server_reset;
			}
			set
			{
				this._is_server_reset = value;
			}
		}
		public virtual object Get(int fieldPos)
		{
			switch (fieldPos)
			{
			case 0: return this.is_server_reset;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Get()");
			};
		}
		public virtual void Put(int fieldPos, object fieldValue)
		{
			switch (fieldPos)
			{
			case 0: this.is_server_reset = (System.Boolean)fieldValue; break;
			default: throw new AvroRuntimeException("Bad index " + fieldPos + " in Put()");
			};
		}
	}
}
