using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . DnsSec ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Child DNS Key record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc7344">RFC 7344</see>
	///     </para>
	/// </summary>
	public class CDnsKeyRecord : DnsRecordBase
	{

		/// <summary>
		///     Algorithm of the key
		/// </summary>
		public DnsSecAlgorithm Algorithm { get ; private set ; }

		/// <summary>
		///     Flags of the key
		/// </summary>
		public DnsKeyFlags Flags { get ; private set ; }

		/// <summary>
		///     <para>Key is intended for use as a secure entry point</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc5011">RFC 5011</see>
		///     </para>
		/// </summary>
		public bool IsRevoked
		{
			get => ( Flags & DnsKeyFlags . Revoke ) == DnsKeyFlags . Revoke ;
			set
			{
				if ( value )
				{
					Flags |= DnsKeyFlags . Revoke ;
				}
				else
				{
					Flags &= ~DnsKeyFlags . Revoke ;
				}
			}
		}

		/// <summary>
		///     <para>Key is intended for use as a secure entry point</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc3757">RFC 3757</see>
		///     </para>
		/// </summary>
		public bool IsSecureEntryPoint
		{
			get => ( Flags & DnsKeyFlags . SecureEntryPoint ) == DnsKeyFlags . SecureEntryPoint ;
			set
			{
				if ( value )
				{
					Flags |= DnsKeyFlags . SecureEntryPoint ;
				}
				else
				{
					Flags &= ~DnsKeyFlags . SecureEntryPoint ;
				}
			}
		}

		/// <summary>
		///     <para>Record holds a DNS zone key</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///         and
		///         <see cref="!:http://tools.ietf.org/html/rfc3757">RFC 3757</see>
		///     </para>
		/// </summary>
		public bool IsZoneKey
		{
			get => ( Flags & DnsKeyFlags . Zone ) == DnsKeyFlags . Zone ;
			set
			{
				if ( value )
				{
					Flags |= DnsKeyFlags . Zone ;
				}
				else
				{
					Flags &= ~DnsKeyFlags . Zone ;
				}
			}
		}

		protected internal override int MaximumRecordDataLength => 4 + PublicKey . Length ;

		/// <summary>
		///     Binary data of the private key
		/// </summary>
		public byte [ ] PrivateKey { get ; private set ; }

		/// <summary>
		///     Protocol field
		/// </summary>
		public byte Protocol { get ; private set ; }

		/// <summary>
		///     Binary data of the public key
		/// </summary>
		public byte [ ] PublicKey { get ; private set ; }

		internal CDnsKeyRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the DnsKeyRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="flags"> Flags of the key </param>
		/// <param name="protocol"> Protocol field </param>
		/// <param name="algorithm"> Algorithm of the key </param>
		/// <param name="publicKey"> Binary data of the public key </param>
		public CDnsKeyRecord (
			DomainName      name ,
			RecordClass     recordClass ,
			int             timeToLive ,
			DnsKeyFlags     flags ,
			byte            protocol ,
			DnsSecAlgorithm algorithm ,
			byte [ ]        publicKey ) : this (
												name ,
												recordClass ,
												timeToLive ,
												flags ,
												protocol ,
												algorithm ,
												publicKey ,
												null )
		{
		}

		/// <summary>
		///     Creates a new instance of the DnsKeyRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="flags"> Flags of the key </param>
		/// <param name="protocol"> Protocol field </param>
		/// <param name="algorithm"> Algorithm of the key </param>
		/// <param name="publicKey"> Binary data of the public key </param>
		/// <param name="privateKey"> Binary data of the private key </param>
		public CDnsKeyRecord (
			DomainName      name ,
			RecordClass     recordClass ,
			int             timeToLive ,
			DnsKeyFlags     flags ,
			byte            protocol ,
			DnsSecAlgorithm algorithm ,
			byte [ ]        publicKey ,
			byte [ ]        privateKey ) : base ( name , RecordType . CDnsKey , recordClass , timeToLive )
		{
			Flags      = flags ;
			Protocol   = protocol ;
			Algorithm  = algorithm ;
			PublicKey  = publicKey ;
			PrivateKey = privateKey ;
		}

		/// <summary>
		///     <para>Calculates the key tag</para>
		///     <para>
		///         Defined in
		///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
		///     </para>
		/// </summary>
		/// <returns></returns>
		public ushort CalculateKeyTag ( )
		{
			if ( Algorithm == DnsSecAlgorithm . RsaMd5 )
			{
				return ( ushort )( PublicKey [ ^4 ] & ( PublicKey [ ^3 ] << 8 ) ) ;
			}

			byte [ ] buffer          = new byte[ MaximumRecordDataLength ] ;
			int      currentPosition = 0 ;
			EncodeRecordData ( buffer , 0 , ref currentPosition , null , false ) ;

			ulong ac = 0 ;

			for ( int i = 0 ; i < currentPosition ; ++i )
			{
				ac += ( ( i & 1 ) == 1 ) ? buffer [ i ] : ( ulong )buffer [ i ] << 8 ;
			}

			ac += ( ac >> 16 ) & 0xFFFF ;

			ushort res = ( ushort )( ac & 0xffff ) ;

			return res ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )Flags ) ;
			messageData [ currentPosition++ ] = Protocol ;
			messageData [ currentPosition++ ] = ( byte )Algorithm ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , PublicKey ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Flags     = ( DnsKeyFlags )DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Protocol  = resultData [ startPosition++ ] ;
			Algorithm = ( DnsSecAlgorithm )resultData [ startPosition++ ] ;
			PublicKey = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length - 4 ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 4 )
			{
				throw new FormatException ( ) ;
			}

			Flags     = ( DnsKeyFlags )ushort . Parse ( stringRepresentation [ 0 ] ) ;
			Protocol  = byte . Parse ( stringRepresentation [ 1 ] ) ;
			Algorithm = ( DnsSecAlgorithm )byte . Parse ( stringRepresentation [ 2 ] ) ;
			PublicKey = string . Join ( string . Empty , stringRepresentation . Skip ( 3 ) ) . FromBase64String ( ) ;
		}

		internal override string RecordDataToString ( )
			=> ( ushort )Flags + " " + Protocol + " " + ( byte )Algorithm + " " + PublicKey . ToBase64String ( ) ;

	}

}
