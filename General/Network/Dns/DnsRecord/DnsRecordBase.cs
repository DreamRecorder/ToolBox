﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics . CodeAnalysis ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Dns . DnsSec ;
using DreamRecorder . ToolBox . Network . Dns . EDns ;
using DreamRecorder . ToolBox . Network . Dns . TSig ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     Base class representing a dns record
	/// </summary>
	public abstract class DnsRecordBase : DnsMessageEntryBase , IComparable <DnsRecordBase> , IEquatable <DnsRecordBase>
	{

		private int ? _hashCode ;

		internal ushort RecordDataLength { get ; set ; }

		internal int StartPosition { get ; set ; }

		/// <summary>
		///     Seconds which a record should be cached at most
		/// </summary>
		public int TimeToLive { get ; internal set ; }

		protected DnsRecordBase ( ) { }

		protected DnsRecordBase ( DomainName name , RecordType recordType , RecordClass recordClass , int timeToLive )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			Name        = name ;
			RecordType  = recordType ;
			RecordClass = recordClass ;
			TimeToLive  = timeToLive ;
		}

		public int CompareTo ( DnsRecordBase other )
		{
			int compare = Name . CompareTo ( other . Name ) ;
			if ( compare != 0 )
			{
				return compare ;
			}

			compare = RecordType . CompareTo ( other . RecordType ) ;
			if ( compare != 0 )
			{
				return compare ;
			}

			compare = RecordClass . CompareTo ( other . RecordClass ) ;
			if ( compare != 0 )
			{
				return compare ;
			}

			compare = TimeToLive . CompareTo ( other . TimeToLive ) ;
			if ( compare != 0 )
			{
				return compare ;
			}

			byte [ ] thisBuffer = new byte[ MaximumRecordDataLength ] ;
			int      thisLength = 0 ;
			EncodeRecordData ( thisBuffer , 0 , ref thisLength , null , false ) ;

			byte [ ] otherBuffer = new byte[ other . MaximumRecordDataLength ] ;
			int      otherLength = 0 ;
			other . EncodeRecordData ( otherBuffer , 0 , ref otherLength , null , false ) ;

			for ( int i = 0 ; i < Math . Min ( thisLength , otherLength ) ; i++ )
			{
				compare = thisBuffer [ i ] . CompareTo ( otherBuffer [ i ] ) ;
				if ( compare != 0 )
				{
					return compare ;
				}
			}

			return thisLength . CompareTo ( otherLength ) ;
		}

		public bool Equals ( DnsRecordBase other )
		{
			if ( other == null )
			{
				return false ;
			}

			return base . Equals ( other ) && RecordDataToString ( ) . Equals ( other . RecordDataToString ( ) ) ;
		}

		internal T Clone <T> ( ) where T : DnsRecordBase => ( T )MemberwiseClone ( ) ;

		internal static DnsRecordBase Create ( RecordType type , byte [ ] resultData , int recordDataPosition )
		{
			if ( ( type                                     == RecordType . Key )
				 && ( resultData [ recordDataPosition + 3 ] == ( byte )DnsSecAlgorithm . DiffieHellman ) )
			{
				return new DiffieHellmanKeyRecord ( ) ;
			}
			else
			{
				return Create ( type ) ;
			}
		}

		internal static DnsRecordBase Create ( RecordType type )
		{
			switch ( type )
			{
				case RecordType . A :
					return new ARecord ( ) ;
				case RecordType . Ns :
					return new NsRecord ( ) ;
				case RecordType . CName :
					return new CNameRecord ( ) ;
				case RecordType . Soa :
					return new SoaRecord ( ) ;
				case RecordType . Wks :
					return new WksRecord ( ) ;
				case RecordType . Ptr :
					return new PtrRecord ( ) ;
				case RecordType . HInfo :
					return new HInfoRecord ( ) ;
				case RecordType . Mx :
					return new MxRecord ( ) ;
				case RecordType . Txt :
					return new TxtRecord ( ) ;
				case RecordType . Rp :
					return new RpRecord ( ) ;
				case RecordType . Afsdb :
					return new AfsdbRecord ( ) ;
				case RecordType . X25 :
					return new X25Record ( ) ;
				case RecordType . Isdn :
					return new IsdnRecord ( ) ;
				case RecordType . Rt :
					return new RtRecord ( ) ;
				case RecordType . Nsap :
					return new NsapRecord ( ) ;
				case RecordType . Sig :
					return new SigRecord ( ) ;
				case RecordType . Key :
					return new KeyRecord ( ) ;
				case RecordType . Px :
					return new PxRecord ( ) ;
				case RecordType . GPos :
					return new GPosRecord ( ) ;
				case RecordType . Aaaa :
					return new AaaaRecord ( ) ;
				case RecordType . Loc :
					return new LocRecord ( ) ;
				case RecordType . Srv :
					return new SrvRecord ( ) ;
				case RecordType . Naptr :
					return new NaptrRecord ( ) ;
				case RecordType . Kx :
					return new KxRecord ( ) ;
				case RecordType . Cert :
					return new CertRecord ( ) ;
				case RecordType . DName :
					return new DNameRecord ( ) ;
				case RecordType . Opt :
					return new OptRecord ( ) ;
				case RecordType . Apl :
					return new AplRecord ( ) ;
				case RecordType . Ds :
					return new DsRecord ( ) ;
				case RecordType . SshFp :
					return new SshFpRecord ( ) ;
				case RecordType . IpSecKey :
					return new IpSecKeyRecord ( ) ;
				case RecordType . RrSig :
					return new RrSigRecord ( ) ;
				case RecordType . NSec :
					return new NSecRecord ( ) ;
				case RecordType . DnsKey :
					return new DnsKeyRecord ( ) ;
				case RecordType . Dhcid :
					return new DhcidRecord ( ) ;
				case RecordType . NSec3 :
					return new NSec3Record ( ) ;
				case RecordType . NSec3Param :
					return new NSec3ParamRecord ( ) ;
				case RecordType . Tlsa :
					return new TlsaRecord ( ) ;
				case RecordType . Hip :
					return new HipRecord ( ) ;
				case RecordType . CDs :
					return new CDsRecord ( ) ;
				case RecordType . CDnsKey :
					return new CDnsKeyRecord ( ) ;
				case RecordType . OpenPGPKey :
					return new OpenPGPKeyRecord ( ) ;
				case RecordType . CSync :
					return new CSyncRecord ( ) ;
#pragma warning disable 0612
				case RecordType . Spf :
					return new SpfRecord ( ) ;
#pragma warning restore 0612
				case RecordType . NId :
					return new NIdRecord ( ) ;
				case RecordType . L32 :
					return new L32Record ( ) ;
				case RecordType . L64 :
					return new L64Record ( ) ;
				case RecordType . LP :
					return new LPRecord ( ) ;
				case RecordType . Eui48 :
					return new Eui48Record ( ) ;
				case RecordType . Eui64 :
					return new Eui64Record ( ) ;
				case RecordType . TKey :
					return new TKeyRecord ( ) ;
				case RecordType . TSig :
					return new TSigRecord ( ) ;
				case RecordType . Uri :
					return new UriRecord ( ) ;
				case RecordType . CAA :
					return new CAARecord ( ) ;
				case RecordType . Dlv :
					return new DlvRecord ( ) ;

				default :
					return new UnknownRecord ( ) ;
			}
		}

		public override bool Equals ( object obj ) => Equals ( obj as DnsRecordBase ) ;

		[SuppressMessage ( "ReSharper" , "NonReadonlyMemberInGetHashCode" )]
		public override int GetHashCode ( )
		{
			if ( ! _hashCode . HasValue )
			{
				_hashCode = ToString ( ) . GetHashCode ( ) ;
			}

			return _hashCode . Value ;
		}

		#region ToString

		internal abstract string RecordDataToString ( ) ;

		/// <summary>
		///     Returns the textual representation of a record
		/// </summary>
		/// <returns> Textual representation </returns>
		public override string ToString ( )
		{
			string recordData = RecordDataToString ( ) ;
			return Name
				   + " "
				   + TimeToLive
				   + " "
				   + RecordClass . ToShortString ( )
				   + " "
				   + RecordType . ToShortString ( )
				   + ( string . IsNullOrEmpty ( recordData ) ? "" : " " + recordData ) ;
		}

		#endregion

		#region Parsing

		internal abstract void ParseRecordData ( byte [ ] resultData , int startPosition , int length ) ;

		internal abstract void ParseRecordData ( DomainName origin , string [ ] stringRepresentation ) ;

		internal void ParseUnknownRecordData ( string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length < 2 )
			{
				throw new FormatException ( ) ;
			}

			if ( stringRepresentation [ 0 ] != @"\#" )
			{
				throw new FormatException ( ) ;
			}

			int length = int . Parse ( stringRepresentation [ 1 ] ) ;

			byte [ ] byteData = string . Join ( "" , stringRepresentation . Skip ( 2 ) ) . FromBase16String ( ) ;

			if ( length != byteData . Length )
			{
				throw new FormatException ( ) ;
			}

			ParseRecordData ( byteData , 0 , length ) ;
		}

		protected DomainName ParseDomainName ( DomainName origin , string name )
		{
			if ( string . IsNullOrEmpty ( name ) )
			{
				throw new ArgumentException ( "Name must be provided" , nameof ( name ) ) ;
			}

			if ( name . EndsWith ( "." ) )
			{
				return DomainName . ParseFromMasterFile ( name ) ;
			}

			return DomainName . ParseFromMasterFile ( name ) + origin ;
		}

		#endregion

		#region Encoding

		internal sealed override int MaximumLength => Name . MaximumRecordDataLength + 12 + MaximumRecordDataLength ;

		internal void Encode (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical = false )
		{
			EncodeRecordHeader ( messageData , offset , ref currentPosition , domainNames , useCanonical ) ;
			EncodeRecordBody ( messageData , offset , ref currentPosition , domainNames , useCanonical ) ;
		}

		internal void EncodeRecordHeader (
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
											   Name ,
											   domainNames ,
											   useCanonical ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )RecordType ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )RecordClass ) ;
			DnsMessageBase . EncodeInt ( messageData , ref currentPosition , TimeToLive ) ;
		}

		internal void EncodeRecordBody (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			int recordDataOffset = currentPosition + 2 ;
			EncodeRecordData ( messageData , offset , ref recordDataOffset , domainNames , useCanonical ) ;
			EncodeRecordLength ( messageData , offset , ref currentPosition , domainNames , recordDataOffset ) ;
		}

		internal void EncodeRecordLength (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          recordDataOffset ,
			Dictionary <DomainName , ushort> domainNames ,
			int                              recordPosition )
		{
			DnsMessageBase . EncodeUShort (
										   messageData ,
										   ref recordDataOffset ,
										   ( ushort )( recordPosition - recordDataOffset - 2 ) ) ;
			recordDataOffset = recordPosition ;
		}


		protected internal abstract int MaximumRecordDataLength { get ; }

		protected internal abstract void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical ) ;

		#endregion

	}

}
