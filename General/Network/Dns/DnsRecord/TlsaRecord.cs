using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Org . BouncyCastle . Crypto . Digests ;
using Org . BouncyCastle . Security ;
using Org . BouncyCastle . X509 ;

using X509Certificate = System . Security . Cryptography . X509Certificates . X509Certificate ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>TLSA</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
	///     </para>
	/// </summary>
	public class TlsaRecord : DnsRecordBase
	{

		/// <summary>
		///     Certificate Usage
		/// </summary>
		public enum TlsaCertificateUsage : byte
		{

			/// <summary>
			///     <para>CA constraint</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>

			// ReSharper disable once InconsistentNaming
			PkixTA = 0 ,

			/// <summary>
			///     <para>Service certificate constraint</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>

			// ReSharper disable once InconsistentNaming
			PkixEE = 1 ,

			/// <summary>
			///     <para> Trust anchor assertion</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>

			// ReSharper disable once InconsistentNaming
			DaneTA = 2 ,

			/// <summary>
			///     <para>
			///         Domain-issued certificate
			///     </para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>

			// ReSharper disable once InconsistentNaming
			DaneEE = 3 ,

			/// <summary>
			///     <para>
			///         Reserved for Private Use
			///     </para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			PrivCert = 255 ,

		}

		/// <summary>
		///     Matching Type
		/// </summary>
		public enum TlsaMatchingType : byte
		{

			/// <summary>
			///     <para>No hash used</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			Full = 0 ,

			/// <summary>
			///     <para>SHA-256 hash</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			Sha256Hash = 1 ,

			/// <summary>
			///     <para>SHA-512 hash</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			Sha512Hash = 2 ,

			/// <summary>
			///     <para>Reserved for Private Use</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			PrivMatch = 255 ,

		}

		/// <summary>
		///     Selector
		/// </summary>
		public enum TlsaSelector : byte
		{

			/// <summary>
			///     <para>Full certificate</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			FullCertificate = 0 ,

			/// <summary>
			///     <para>DER-encoded binary structure</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc6698">RFC 6698</see>
			///     </para>
			/// </summary>
			SubjectPublicKeyInfo = 1 ,

		}

		/// <summary>
		///     The certificate association data
		/// </summary>
		public byte [ ] CertificateAssociationData { get ; private set ; }

		/// <summary>
		///     The certificate usage
		/// </summary>
		public TlsaCertificateUsage CertificateUsage { get ; private set ; }

		/// <summary>
		///     The matching type
		/// </summary>
		public TlsaMatchingType MatchingType { get ; private set ; }

		protected internal override int MaximumRecordDataLength => 3 + CertificateAssociationData . Length ;

		/// <summary>
		///     The selector
		/// </summary>
		public TlsaSelector Selector { get ; private set ; }

		internal TlsaRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the TlsaRecord class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="certificateUsage">The certificate usage</param>
		/// <param name="selector">The selector</param>
		/// <param name="matchingType">The matching type</param>
		/// <param name="certificateAssociationData">The certificate association data</param>
		public TlsaRecord (
			DomainName name ,
			int timeToLive ,
			TlsaCertificateUsage certificateUsage ,
			TlsaSelector selector ,
			TlsaMatchingType matchingType ,
			byte [ ] certificateAssociationData ) : base ( name , RecordType . Tlsa , RecordClass . INet , timeToLive )
		{
			CertificateUsage           = certificateUsage ;
			Selector                   = selector ;
			MatchingType               = matchingType ;
			CertificateAssociationData = certificateAssociationData ?? new byte [ ] { } ;
		}

		/// <summary>
		///     Creates a new instance of the TlsaRecord class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="certificateUsage">The certificate usage</param>
		/// <param name="selector">The selector</param>
		/// <param name="matchingType">The matching type</param>
		/// <param name="certificate">The certificate to get the association data from</param>
		public TlsaRecord (
			DomainName           name ,
			int                  timeToLive ,
			TlsaCertificateUsage certificateUsage ,
			TlsaSelector         selector ,
			TlsaMatchingType     matchingType ,
			X509Certificate      certificate ) : base ( name , RecordType . Tlsa , RecordClass . INet , timeToLive )
		{
			CertificateUsage           = certificateUsage ;
			Selector                   = selector ;
			MatchingType               = matchingType ;
			CertificateAssociationData = GetCertificateAssocicationData ( selector , matchingType , certificate ) ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			messageData [ currentPosition++ ] = ( byte )CertificateUsage ;
			messageData [ currentPosition++ ] = ( byte )Selector ;
			messageData [ currentPosition++ ] = ( byte )MatchingType ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , CertificateAssociationData ) ;
		}

		internal static byte [ ] GetCertificateAssocicationData (
			TlsaSelector     selector ,
			TlsaMatchingType matchingType ,
			X509Certificate  certificate )
		{
			byte [ ] selectedBytes ;
			switch ( selector )
			{
				case TlsaSelector . FullCertificate :
					selectedBytes = certificate . GetRawCertData ( ) ;
					break ;

				case TlsaSelector . SubjectPublicKeyInfo :
					selectedBytes = SubjectPublicKeyInfoFactory .
									CreateSubjectPublicKeyInfo (
																DotNetUtilities . FromX509Certificate ( certificate ) .
																	GetPublicKey ( ) ) .
									GetDerEncoded ( ) ;
					break ;

				default :
					throw new NotSupportedException ( ) ;
			}

			byte [ ] matchingBytes ;
			switch ( matchingType )
			{
				case TlsaMatchingType . Full :
					matchingBytes = selectedBytes ;
					break ;

				case TlsaMatchingType . Sha256Hash :
					Sha256Digest sha256Digest = new Sha256Digest ( ) ;
					sha256Digest . BlockUpdate ( selectedBytes , 0 , selectedBytes . Length ) ;
					matchingBytes = new byte[ sha256Digest . GetDigestSize ( ) ] ;
					sha256Digest . DoFinal ( matchingBytes , 0 ) ;
					break ;

				case TlsaMatchingType . Sha512Hash :
					Sha512Digest sha512Digest = new Sha512Digest ( ) ;
					sha512Digest . BlockUpdate ( selectedBytes , 0 , selectedBytes . Length ) ;
					matchingBytes = new byte[ sha512Digest . GetDigestSize ( ) ] ;
					sha512Digest . DoFinal ( matchingBytes , 0 ) ;
					break ;

				default :
					throw new NotSupportedException ( ) ;
			}

			return matchingBytes ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			CertificateUsage = ( TlsaCertificateUsage )resultData [ startPosition++ ] ;
			Selector         = ( TlsaSelector )resultData [ startPosition++ ] ;
			MatchingType     = ( TlsaMatchingType )resultData [ startPosition++ ] ;
			CertificateAssociationData =
				DnsMessageBase . ParseByteData ( resultData , ref startPosition , length - 3 ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 4 )
			{
				throw new FormatException ( ) ;
			}

			CertificateUsage = ( TlsaCertificateUsage )byte . Parse ( stringRepresentation [ 0 ] ) ;
			Selector         = ( TlsaSelector )byte . Parse ( stringRepresentation [ 1 ] ) ;
			MatchingType     = ( TlsaMatchingType )byte . Parse ( stringRepresentation [ 2 ] ) ;
			CertificateAssociationData = string . Join ( string . Empty , stringRepresentation . Skip ( 3 ) ) .
												  FromBase16String ( ) ;
		}

		internal override string RecordDataToString ( )
			=> ( byte )CertificateUsage
			   + " "
			   + ( byte )Selector
			   + " "
			   + ( byte )MatchingType
			   + " "
			   + string . Join ( string . Empty , CertificateAssociationData . ToBase16String ( ) ) ;

	}

}
