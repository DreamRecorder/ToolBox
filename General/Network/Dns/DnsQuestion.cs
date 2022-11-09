using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics . CodeAnalysis ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns
{

	/// <summary>
	///     A single entry of the Question section of a dns query
	/// </summary>
	public class DnsQuestion : DnsMessageEntryBase , IEquatable <DnsQuestion>
	{

		private int ? _hashCode ;

		internal override int MaximumLength => Name . MaximumRecordDataLength + 6 ;

		/// <summary>
		///     Creates a new instance of the DnsQuestion class
		/// </summary>
		/// <param name="name"> Domain name </param>
		/// <param name="recordType"> Record type </param>
		/// <param name="recordClass"> Record class </param>
		public DnsQuestion ( DomainName name , RecordType recordType , RecordClass recordClass )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			Name        = name ;
			RecordType  = recordType ;
			RecordClass = recordClass ;
		}

		internal DnsQuestion ( ) { }

		public bool Equals ( DnsQuestion other )
		{
			if ( other == null )
			{
				return false ;
			}

			return base . Equals ( other ) ;
		}

		internal void Encode (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames )
		{
			DnsMessageBase . EncodeDomainName (
											   messageData ,
											   offset ,
											   ref currentPosition ,
											   Name ,
											   domainNames ,
											   false ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )RecordType ) ;
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , ( ushort )RecordClass ) ;
		}

		public override bool Equals ( object obj ) => Equals ( obj as DnsQuestion ) ;

		[SuppressMessage ( "ReSharper" , "NonReadonlyMemberInGetHashCode" )]
		public override int GetHashCode ( )
		{
			if ( ! _hashCode . HasValue )
			{
				_hashCode = ToString ( ) . GetHashCode ( ) ;
			}

			return _hashCode . Value ;
		}

	}

}
