﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . TSig ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Transaction key</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
	///     </para>
	/// </summary>

	// ReSharper disable once InconsistentNaming
	public class TKeyRecord : DnsRecordBase
	{

		/// <summary>
		///     Mode of transaction
		/// </summary>

		// ReSharper disable once InconsistentNaming
		public enum TKeyMode : ushort
		{

			/// <summary>
			///     <para>Server assignment</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
			///     </para>
			/// </summary>
			ServerAssignment = 1 , // RFC2930

			/// <summary>
			///     <para>Diffie-Hellman exchange</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
			///     </para>
			/// </summary>
			DiffieHellmanExchange = 2 , // RFC2930

			/// <summary>
			///     <para>GSS-API negotiation</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
			///     </para>
			/// </summary>
			GssNegotiation = 3 , // RFC2930

			/// <summary>
			///     <para>Resolver assignment</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
			///     </para>
			/// </summary>
			ResolverAssignment = 4 , // RFC2930

			/// <summary>
			///     <para>Key deletion</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc2930">RFC 2930</see>
			///     </para>
			/// </summary>
			KeyDeletion = 5 , // RFC2930

		}

		/// <summary>
		///     Algorithm of the key
		/// </summary>
		public TSigAlgorithm Algorithm { get ; private set ; }

		/// <summary>
		///     Error field
		/// </summary>
		public ReturnCode Error { get ; private set ; }

		/// <summary>
		///     Date to which the key is valid
		/// </summary>
		public DateTime Expiration { get ; private set ; }

		/// <summary>
		///     Date from which the key is valid
		/// </summary>
		public DateTime Inception { get ; private set ; }

		/// <summary>
		///     Binary data of the key
		/// </summary>
		public byte [ ] Key { get ; private set ; }

		protected internal override int MaximumRecordDataLength
			=> 18
			   + TSigAlgorithmHelper . GetDomainName ( Algorithm ) . MaximumRecordDataLength
			   + Key . Length
			   + OtherData . Length ;

		/// <summary>
		///     Mode of transaction
		/// </summary>
		public TKeyMode Mode { get ; private set ; }

		/// <summary>
		///     Binary other data
		/// </summary>
		public byte [ ] OtherData { get ; private set ; }

		internal TKeyRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the TKeyRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="algorithm"> Algorithm of the key </param>
		/// <param name="inception"> Date from which the key is valid </param>
		/// <param name="expiration"> Date to which the key is valid </param>
		/// <param name="mode"> Mode of transaction </param>
		/// <param name="error"> Error field </param>
		/// <param name="key"> Binary data of the key </param>
		/// <param name="otherData"> Binary other data </param>
		public TKeyRecord (
			DomainName    name ,
			TSigAlgorithm algorithm ,
			DateTime      inception ,
			DateTime      expiration ,
			TKeyMode      mode ,
			ReturnCode    error ,
			byte [ ]      key ,
			byte [ ]      otherData ) : base ( name , RecordType . TKey , RecordClass . Any , 0 )
		{
			Algorithm  = algorithm ;
			Inception  = inception ;
			Expiration = expiration ;
			Mode       = mode ;
			Error      = error ;
			Key        = key       ?? new byte [ ] { } ;
			OtherData  = otherData ?? new byte [ ] { } ;
		}

		internal static void EncodeDateTime ( byte [ ] buffer , ref int currentPosition , DateTime value )
		{
			int timeStamp =
				( int )( value . ToUniversalTime ( )
						 - new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , DateTimeKind . Utc ) ) . TotalSeconds ;
			DnsMessageBase . EncodeInt ( buffer , ref currentPosition , timeStamp ) ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   TSigAlgorithmHelper . GetDomainName ( Algorithm ) ,
											   null ,
											   false ) ;
			EncodeDateTime ( messageData , ref currentPosition , Inception ) ;
			EncodeDateTime ( messageData , ref currentPosition , Expiration ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )Mode ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )Error ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )Key . Length ) ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Key ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )OtherData . Length ) ;
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , OtherData ) ;
		}

		private static DateTime ParseDateTime ( byte [ ] buffer , ref int currentPosition )
		{
			int timeStamp = DnsMessageBase . ParseInt ( buffer , ref currentPosition ) ;
			return new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , DateTimeKind . Utc ) . AddSeconds ( timeStamp ) .
				ToLocalTime ( ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Algorithm = TSigAlgorithmHelper . GetAlgorithmByName (
																  DnsMessageBase . ParseDomainName (
																   resultData ,
																   ref startPosition ) ) ;
			Inception  = ParseDateTime ( resultData , ref startPosition ) ;
			Expiration = ParseDateTime ( resultData , ref startPosition ) ;
			Mode       = ( TKeyMode )DnsMessageBase . ParseUShort ( resultData ,   ref startPosition ) ;
			Error      = ( ReturnCode )DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			int keyLength = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			Key = DnsMessageBase . ParseByteData ( resultData , ref startPosition , keyLength ) ;
			int otherDataLength = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			OtherData = DnsMessageBase . ParseByteData ( resultData , ref startPosition , otherDataLength ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			throw new NotSupportedException ( ) ;
		}

		internal override string RecordDataToString ( )
			=> TSigAlgorithmHelper . GetDomainName ( Algorithm )
			   + " "
			   + ( int )( Inception - new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , DateTimeKind . Utc ) ) . TotalSeconds
			   + " "
			   + ( int )( Expiration - new DateTime ( 1970 , 1 , 1 , 0 , 0 , 0 , DateTimeKind . Utc ) ) . TotalSeconds
			   + " "
			   + ( ushort )Mode
			   + " "
			   + ( ushort )Error
			   + " "
			   + Key . ToBase64String ( )
			   + " "
			   + OtherData . ToBase64String ( ) ;

	}

}
