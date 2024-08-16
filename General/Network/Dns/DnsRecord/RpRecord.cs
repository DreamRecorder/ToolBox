using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     <para>Responsible person record</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/rfc1183">RFC 1183</see>
///     </para>
/// </summary>
public class RpRecord : DnsRecordBase
{

	/// <summary>
	///     Mail address of responsable person, the @ should be replaced by a dot
	/// </summary>
	public DomainName MailBox { get; protected set; }

	protected internal override int MaximumRecordDataLength
		=> 4 + MailBox.MaximumRecordDataLength + TxtDomainName.MaximumRecordDataLength;

	/// <summary>
	///     Domain name of a
	///     <see cref="TxtRecord" />
	///     with additional information
	/// </summary>
	public DomainName TxtDomainName { get; protected set; }

	internal RpRecord ( ) { }

	/// <summary>
	///     Creates a new instance of the RpRecord class
	/// </summary>
	/// <param name="name"> Name of the record </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="mailBox"> Mail address of responsable person, the @ should be replaced by a dot </param>
	/// <param name="txtDomainName">
	///     Domain name of a
	///     <see cref="TxtRecord" />
	///     with additional information
	/// </param>
	public RpRecord ( DomainName name , int timeToLive , DomainName mailBox , DomainName txtDomainName ) : base (
																												 name ,
																												 RecordType.Rp ,
																												 RecordClass.INet ,
																												 timeToLive )
	{
		MailBox       = mailBox       ?? DomainName.Root;
		TxtDomainName = txtDomainName ?? DomainName.Root;
	}

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		DnsMessageBase.EncodeDomainName ( messageData , offset , ref currentPosition , MailBox , null , useCanonical );
		DnsMessageBase.EncodeDomainName (
										 messageData ,
										 offset ,
										 ref currentPosition ,
										 TxtDomainName ,
										 null ,
										 useCanonical );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
	{
		MailBox       = DnsMessageBase.ParseDomainName ( resultData , ref startPosition );
		TxtDomainName = DnsMessageBase.ParseDomainName ( resultData , ref startPosition );
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length != 2 )
		{
			throw new FormatException ( );
		}

		MailBox       = ParseDomainName ( origin , stringRepresentation [ 0 ] );
		TxtDomainName = ParseDomainName ( origin , stringRepresentation [ 1 ] );
	}

	internal override string RecordDataToString ( ) => MailBox + " " + TxtDomainName;

}
