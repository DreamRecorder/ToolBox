using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using DreamRecorder.ToolBox.General;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     <para>OpenPGP Key</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/draft-ietf-dane-openpgpkey">draft-ietf-dane-openpgpkey</see>
///     </para>
/// </summary>

// ReSharper disable once InconsistentNaming
public class OpenPGPKeyRecord : DnsRecordBase
{

	protected internal override int MaximumRecordDataLength => PublicKey.Length;

	/// <summary>
	///     The Public Key
	/// </summary>
	public byte [ ] PublicKey { get; private set; }

	internal OpenPGPKeyRecord ( ) { }

	/// <summary>
	///     Creates a new instance of the OpenPGPKeyRecord class
	/// </summary>
	/// <param name="name"> Domain name of the host </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="publicKey"> The Public Key</param>
	public OpenPGPKeyRecord ( DomainName name , int timeToLive , byte [ ] publicKey ) : base (
	 name ,
	 RecordType.OpenPGPKey ,
	 RecordClass.INet ,
	 timeToLive )
	{
		PublicKey = publicKey ?? new byte [ ] { };
	}

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		DnsMessageBase.EncodeByteArray ( messageData , ref currentPosition , PublicKey );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
	{
		PublicKey = DnsMessageBase.ParseByteData ( resultData , ref startPosition , length );
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length == 0 )
		{
			throw new NotSupportedException ( );
		}

		PublicKey = string.Join ( string.Empty , stringRepresentation ).FromBase64String ( );
	}

	internal override string RecordDataToString ( ) => PublicKey.ToBase64String ( );

}
