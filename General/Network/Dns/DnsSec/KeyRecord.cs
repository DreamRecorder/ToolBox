using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	/// <summary>
	///     <para>Security Key record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc4034">RFC 4034</see>
	///         ,
	///         <see cref="!:http://tools.ietf.org/html/rfc3755">RFC 3755</see>
	///         ,
	///         <see cref="!:http://tools.ietf.org/html/rfc2535">RFC 2535</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
	///     </para>
	/// </summary>
	public class KeyRecord : KeyRecordBase
	{

		/// <summary>
		///     Binary data of the public key
		/// </summary>
		public byte [ ] PublicKey { get ; private set ; }

		protected override int MaximumPublicKeyLength => PublicKey . Length ;

		internal KeyRecord ( ) { }

		/// <summary>
		///     Creates of new instance of the KeyRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="recordClass"> Class of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="flags"> Flags of the key </param>
		/// <param name="protocol"> Protocol for which the key is used </param>
		/// <param name="algorithm"> Algorithm of the key </param>
		/// <param name="publicKey"> Binary data of the public key </param>
		public KeyRecord (
			DomainName      name ,
			RecordClass     recordClass ,
			int             timeToLive ,
			ushort          flags ,
			ProtocolType    protocol ,
			DnsSecAlgorithm algorithm ,
			byte [ ]        publicKey ) : base ( name , recordClass , timeToLive , flags , protocol , algorithm )
		{
			PublicKey = publicKey ?? new byte [ ] { } ;
		}

		protected override void ParsePublicKey ( byte [ ] resultData , int startPosition , int length )
		{
			PublicKey = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 1 )
			{
				throw new FormatException ( ) ;
			}

			PublicKey = string . Join ( string . Empty , stringRepresentation ) . FromBase64String ( ) ;
		}

		protected override string PublicKeyToString ( ) => PublicKey . ToBase64String ( ) ;

		protected override void EncodePublicKey (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames )
		{
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , PublicKey ) ;
		}

	}

}
