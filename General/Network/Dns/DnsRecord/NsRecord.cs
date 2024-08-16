using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     <para>Authoritatitve name server record</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
///     </para>
/// </summary>
public class NsRecord : DnsRecordBase
{

	protected internal override int MaximumRecordDataLength => NameServer.MaximumRecordDataLength + 2;

	/// <summary>
	///     Name of the authoritatitve nameserver for the zone
	/// </summary>
	public DomainName NameServer { get; private set; }

	internal NsRecord ( ) { }

	/// <summary>
	///     Creates a new instance of the NsRecord class
	/// </summary>
	/// <param name="name"> Domain name of the zone </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="nameServer"> Name of the authoritative name server </param>
	public NsRecord ( DomainName name , int timeToLive , DomainName nameServer ) : base (
	 name ,
	 RecordType.Ns ,
	 RecordClass.INet ,
	 timeToLive )
		=> NameServer = nameServer ?? DomainName.Root;

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		DnsMessageBase.EncodeDomainName (
										 messageData ,
										 offset ,
										 ref currentPosition ,
										 NameServer ,
										 domainNames ,
										 useCanonical );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
	{
		NameServer = DnsMessageBase.ParseDomainName ( resultData , ref startPosition );
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length != 1 )
		{
			throw new FormatException ( );
		}

		NameServer = ParseDomainName ( origin , stringRepresentation [ 0 ] );
	}

	internal override string RecordDataToString ( ) => NameServer.ToString ( );

}
