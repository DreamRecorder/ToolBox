﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;
using System . Text . RegularExpressions ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Address prefixes record</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc3123">RFC 3123</see>
	///     </para>
	/// </summary>
	public class AplRecord : DnsRecordBase
	{

		protected internal override int MaximumRecordDataLength => Prefixes . Count * 20 ;

		/// <summary>
		///     List of address prefixes covered by this record
		/// </summary>
		public List <AddressPrefix> Prefixes { get ; private set ; }

		internal AplRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the AplRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="prefixes"> List of address prefixes covered by this record </param>
		public AplRecord ( DomainName name , int timeToLive , List <AddressPrefix> prefixes ) : base (
		 name ,
		 RecordType . Apl ,
		 RecordClass . INet ,
		 timeToLive )
			=> Prefixes = prefixes ?? new List <AddressPrefix> ( ) ;

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			foreach ( AddressPrefix addressPrefix in Prefixes )
			{
				DnsMessageBase . EncodeUShort (
											   messageData ,
											   ref currentPosition ,
											   ( ushort )addressPrefix . AddressFamily ) ;
				messageData [ currentPosition++ ] = addressPrefix . Prefix ;

				// no increment of position pointer, just set 1 bit
				if ( addressPrefix . IsNegated )
				{
					messageData [ currentPosition ] = 128 ;
				}

				byte [ ] addressData = addressPrefix . Address . GetNetworkAddress ( addressPrefix . Prefix ) .
													   GetAddressBytes ( ) ;
				int length = addressData . Length ;
				for ( ; length > 0 ; length-- )
				{
					if ( addressData [ length - 1 ] != 0 )
					{
						break ;
					}
				}

				messageData [ currentPosition++ ] |= ( byte )length ;
				DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , addressData , length ) ;
			}
		}

		internal override void ParseRecordData ( byte [ ] resultData , int currentPosition , int length )
		{
			int endPosition = currentPosition + length ;

			Prefixes = new List <AddressPrefix> ( ) ;
			while ( currentPosition < endPosition )
			{
				Family family = ( Family )DnsMessageBase . ParseUShort ( resultData , ref currentPosition ) ;
				byte   prefix = resultData [ currentPosition++ ] ;

				byte addressLength = resultData [ currentPosition++ ] ;
				bool isNegated     = false ;
				if ( addressLength > 127 )
				{
					isNegated     =  true ;
					addressLength -= 128 ;
				}

				byte [ ] addressData = new byte[ ( family == Family . IpV4 ) ? 4 : 16 ] ;
				Buffer . BlockCopy ( resultData , currentPosition , addressData , 0 , addressLength ) ;
				currentPosition += addressLength ;

				Prefixes . Add ( new AddressPrefix ( isNegated , new IPAddress ( addressData ) , prefix ) ) ;
			}
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length == 0 )
			{
				throw new FormatException ( ) ;
			}

			Prefixes = stringRepresentation . Select ( AddressPrefix . Parse ) . ToList ( ) ;
		}

		internal override string RecordDataToString ( )
		{
			return string . Join ( " " , Prefixes . Select ( p => p . ToString ( ) ) ) ;
		}

		/// <summary>
		///     Represents an address prefix
		/// </summary>
		public class AddressPrefix
		{

			/// <summary>
			///     Network address
			/// </summary>
			public IPAddress Address { get ; }

			/// <summary>
			///     Address familiy
			/// </summary>
			internal Family AddressFamily { get ; }

			/// <summary>
			///     Is negated prefix
			/// </summary>
			public bool IsNegated { get ; }

			/// <summary>
			///     Prefix of the network
			/// </summary>
			public byte Prefix { get ; }

			/// <summary>
			///     Creates a new instance of the AddressPrefix class
			/// </summary>
			/// <param name="isNegated"> Is negated prefix </param>
			/// <param name="address"> Network address </param>
			/// <param name="prefix"> Prefix of the network </param>
			public AddressPrefix ( bool isNegated , IPAddress address , byte prefix )
			{
				IsNegated = isNegated ;
				AddressFamily = ( address . AddressFamily == System . Net . Sockets . AddressFamily . InterNetwork )
									? Family . IpV4
									: Family . IpV6 ;
				Address = address ;
				Prefix  = prefix ;
			}

			private static readonly Regex _parserRegex = new Regex (
																	@"^(?<isneg>!?)(?<fam>(1|2)):(?<addr>[^/]+)/(?<pref>\d+)$" ,
																	RegexOptions . ExplicitCapture
																	| RegexOptions . Compiled ) ;

			internal static AddressPrefix Parse ( string s )
			{
				GroupCollection groups = _parserRegex . Match ( s ) . Groups ;

				IPAddress address = IPAddress . Parse ( groups [ "addr" ] . Value ) ;

				if ( ( address . AddressFamily     == System . Net . Sockets . AddressFamily . InterNetwork )
					 && ( groups [ "fam" ] . Value != "1" ) )
				{
					throw new FormatException ( ) ;
				}

				return new AddressPrefix (
										  groups [ "isneg" ] . Success ,
										  address ,
										  byte . Parse ( groups [ "pref" ] . Value ) ) ;
			}

			/// <summary>
			///     Returns the textual representation of an address prefix
			/// </summary>
			/// <returns> The textual representation </returns>
			public override string ToString ( )
				=> ( IsNegated ? "!" : "" ) + ( ushort )AddressFamily + ":" + Address + "/" + Prefix ;

		}

		internal enum Family : ushort
		{

			/// <summary>
			///     <para>IPv4</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc3123">RFC 3123</see>
			///     </para>
			/// </summary>
			IpV4 = 1 ,

			/// <summary>
			///     <para>IPv6</para>
			///     <para>
			///         Defined in
			///         <see cref="!:http://tools.ietf.org/html/rfc3123">RFC 3123</see>
			///     </para>
			/// </summary>
			IpV6 = 2 ,

		}

	}

}
