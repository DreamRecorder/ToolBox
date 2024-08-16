using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     <para>Host information</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
///     </para>
/// </summary>
public class HInfoRecord : DnsRecordBase
{

	/// <summary>
	///     Type of the CPU of the host
	/// </summary>
	public string Cpu { get; private set; }

	protected internal override int MaximumRecordDataLength => 2 + Cpu.Length + OperatingSystem.Length;

	/// <summary>
	///     Name of the operating system of the host
	/// </summary>
	public string OperatingSystem { get; private set; }

	internal HInfoRecord ( ) { }

	/// <summary>
	///     Creates a new instance of the HInfoRecord class
	/// </summary>
	/// <param name="name"> Name of the host </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="cpu"> Type of the CPU of the host </param>
	/// <param name="operatingSystem"> Name of the operating system of the host </param>
	public HInfoRecord ( DomainName name , int timeToLive , string cpu , string operatingSystem ) : base (
	 name ,
	 RecordType.HInfo ,
	 RecordClass.INet ,
	 timeToLive )
	{
		Cpu             = cpu             ?? string.Empty;
		OperatingSystem = operatingSystem ?? string.Empty;
	}

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		DnsMessageBase.EncodeTextBlock ( messageData , ref currentPosition , Cpu );
		DnsMessageBase.EncodeTextBlock ( messageData , ref currentPosition , OperatingSystem );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
	{
		Cpu             = DnsMessageBase.ParseText ( resultData , ref startPosition );
		OperatingSystem = DnsMessageBase.ParseText ( resultData , ref startPosition );
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length != 2 )
		{
			throw new FormatException ( );
		}

		Cpu             = stringRepresentation [ 0 ];
		OperatingSystem = stringRepresentation [ 1 ];
	}

	internal override string RecordDataToString ( )
		=> "\""
		   + Cpu.ToMasterfileLabelRepresentation ( )
		   + "\""
		   + " \""
		   + OperatingSystem.ToMasterfileLabelRepresentation ( )
		   + "\"";

}
