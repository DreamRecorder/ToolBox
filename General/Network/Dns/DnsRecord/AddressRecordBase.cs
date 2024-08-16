using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     Base record class for storing host to ip allocation (ARecord and AaaaRecord)
/// </summary>
public abstract class AddressRecordBase : DnsRecordBase , IAddressRecord
{

	protected AddressRecordBase ( ) { }

	protected AddressRecordBase ( DomainName name , RecordType recordType , int timeToLive , IPAddress address ) :
		base ( name , recordType , RecordClass.INet , timeToLive )
		=> Address = address;

	/// <summary>
	///     IP address of the host
	/// </summary>
	public IPAddress Address { get; private set; }

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		DnsMessageBase.EncodeByteArray ( messageData , ref currentPosition , Address.GetAddressBytes ( ) );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
	{
		Address = new IPAddress (
								 DnsMessageBase.ParseByteData (
															   resultData ,
															   ref startPosition ,
															   MaximumRecordDataLength ) );
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length != 1 )
		{
			throw new FormatException ( );
		}

		Address = IPAddress.Parse ( stringRepresentation [ 0 ] );
	}

	internal override string RecordDataToString ( ) => Address.ToString ( );

}
