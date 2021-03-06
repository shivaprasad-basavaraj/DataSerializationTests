/**
 * Autogenerated by Thrift Compiler (0.15.0)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Collections;

using Thrift.Protocol;
using Thrift.Protocol.Entities;
using Thrift.Protocol.Utilities;
using Thrift.Transport;
using Thrift.Transport.Client;
using Thrift.Transport.Server;
using Thrift.Processor;


#pragma warning disable IDE0079  // remove unnecessary pragmas
#pragma warning disable IDE1006  // parts of the code use IDL spelling
#pragma warning disable IDE0083  // pattern matching "that is not SomeType" requires net5.0 but we still support earlier versions


public partial class ReserveResponse : TBase
{
  private bool _is_reserved;

  public bool Is_reserved
  {
    get
    {
      return _is_reserved;
    }
    set
    {
      __isset.is_reserved = true;
      this._is_reserved = value;
    }
  }


  public Isset __isset;
  public struct Isset
  {
    public bool is_reserved;
  }

  public ReserveResponse()
  {
  }

  public ReserveResponse DeepCopy()
  {
    var tmp28 = new ReserveResponse();
    if(__isset.is_reserved)
    {
      tmp28.Is_reserved = this.Is_reserved;
    }
    tmp28.__isset.is_reserved = this.__isset.is_reserved;
    return tmp28;
  }

  public async global::System.Threading.Tasks.Task ReadAsync(TProtocol iprot, CancellationToken cancellationToken)
  {
    iprot.IncrementRecursionDepth();
    try
    {
      TField field;
      await iprot.ReadStructBeginAsync(cancellationToken);
      while (true)
      {
        field = await iprot.ReadFieldBeginAsync(cancellationToken);
        if (field.Type == TType.Stop)
        {
          break;
        }

        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.Bool)
            {
              Is_reserved = await iprot.ReadBoolAsync(cancellationToken);
            }
            else
            {
              await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            }
            break;
          default: 
            await TProtocolUtil.SkipAsync(iprot, field.Type, cancellationToken);
            break;
        }

        await iprot.ReadFieldEndAsync(cancellationToken);
      }

      await iprot.ReadStructEndAsync(cancellationToken);
    }
    finally
    {
      iprot.DecrementRecursionDepth();
    }
  }

  public async global::System.Threading.Tasks.Task WriteAsync(TProtocol oprot, CancellationToken cancellationToken)
  {
    oprot.IncrementRecursionDepth();
    try
    {
      var tmp29 = new TStruct("ReserveResponse");
      await oprot.WriteStructBeginAsync(tmp29, cancellationToken);
      var tmp30 = new TField();
      if(__isset.is_reserved)
      {
        tmp30.Name = "is_reserved";
        tmp30.Type = TType.Bool;
        tmp30.ID = 1;
        await oprot.WriteFieldBeginAsync(tmp30, cancellationToken);
        await oprot.WriteBoolAsync(Is_reserved, cancellationToken);
        await oprot.WriteFieldEndAsync(cancellationToken);
      }
      await oprot.WriteFieldStopAsync(cancellationToken);
      await oprot.WriteStructEndAsync(cancellationToken);
    }
    finally
    {
      oprot.DecrementRecursionDepth();
    }
  }

  public override bool Equals(object that)
  {
    if (!(that is ReserveResponse other)) return false;
    if (ReferenceEquals(this, other)) return true;
    return ((__isset.is_reserved == other.__isset.is_reserved) && ((!__isset.is_reserved) || (System.Object.Equals(Is_reserved, other.Is_reserved))));
  }

  public override int GetHashCode() {
    int hashcode = 157;
    unchecked {
      if(__isset.is_reserved)
      {
        hashcode = (hashcode * 397) + Is_reserved.GetHashCode();
      }
    }
    return hashcode;
  }

  public override string ToString()
  {
    var tmp31 = new StringBuilder("ReserveResponse(");
    int tmp32 = 0;
    if(__isset.is_reserved)
    {
      if(0 < tmp32++) { tmp31.Append(", "); }
      tmp31.Append("Is_reserved: ");
      Is_reserved.ToString(tmp31);
    }
    tmp31.Append(')');
    return tmp31.ToString();
  }
}

