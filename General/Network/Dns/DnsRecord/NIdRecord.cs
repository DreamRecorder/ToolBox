using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>NID</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6742">RFC 6742</see>
	///     </para>
	/// </summary>
	public class NIdRecord : DnsRecordBase
	{

		protected internal override int MaximumRecordDataLength => 10 ;

		/// <summary>
		///     The Node ID
		/// </summary>
		public ulong NodeID { get ; private set ; }

		/// <summary>
		///     The preference
		/// </summary>
		public ushort Preference { get ; private set ; }

		internal NIdRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the NIdRecord class
		/// </summary>
		/// <param name="name"> Domain name of the host </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="preference"> The preference </param>
		/// <param name="nodeID"> The Node ID </param>
		public NIdRecord ( DomainName name , int timeToLive , ushort preference , ulong nodeID ) : base (
		 name ,
		 RecordType . NId ,
		 RecordClass . INet ,
		 timeToLive )
		{
			Preference = preference ;
			NodeID     = nodeID ;
		}

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
			DnsMessageBase . EncodeUShort ( messageData , ref currentPosition , Preference ) ;
			DnsMessageBase . EncodeULong ( messageData , ref currentPosition , NodeID ) ;
		}

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
		{
			Preference = DnsMessageBase . ParseUShort ( resultData , ref startPosition ) ;
			NodeID     = DnsMessageBase . ParseULong ( resultData , ref startPosition ) ;
		}

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			if ( stringRepresentation . Length != 2 )
			{
				throw new FormatException ( ) ;
			}

			Preference = ushort . Parse ( stringRepresentation [ 0 ] ) ;

			string [ ] nodeIDParts = stringRepresentation [ 1 ] . Split ( ':' ) ;

			if ( nodeIDParts . Length != 4 )
			{
				throw new FormatException ( ) ;
			}

			for ( int i = 0 ; i < 4 ; i++ )
			{
				if ( nodeIDParts [ i ] . Length != 4 )
				{
					throw new FormatException ( ) ;
				}

				NodeID =  NodeID << 16 ;
				NodeID |= Convert . ToUInt16 ( nodeIDParts [ i ] , 16 ) ;
			}
		}

		internal override string RecordDataToString ( )
		{
			string nodeID = NodeID . ToString ( "x16" ) ;
			return Preference
				   + " "
				   + nodeID . Substring ( 0 , 4 )
				   + ":"
				   + nodeID . Substring ( 4 , 4 )
				   + ":"
				   + nodeID . Substring ( 8 , 4 )
				   + ":"
				   + nodeID . Substring ( 12 ) ;
		}

	}

}
