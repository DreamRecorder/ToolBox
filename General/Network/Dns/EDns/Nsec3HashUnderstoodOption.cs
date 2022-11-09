using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsSec ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     <para>NSEC3 Hash Unterstood option</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc6975">RFC 6975</see>
	///     </para>
	/// </summary>
	public class Nsec3HashUnderstoodOption : EDnsOptionBase
	{

		/// <summary>
		///     List of Algorithms
		/// </summary>
		public List <DnsSecAlgorithm> Algorithms { get ; private set ; }

		internal override ushort DataLength => ( ushort )( Algorithms ? . Count ?? 0 ) ;

		internal Nsec3HashUnderstoodOption ( ) : base ( EDnsOptionType . Nsec3HashUnderstood ) { }

		/// <summary>
		///     Creates a new instance of the Nsec3HashUnderstoodOption class
		/// </summary>
		/// <param name="algorithms">The list of algorithms</param>
		public Nsec3HashUnderstoodOption ( List <DnsSecAlgorithm> algorithms ) : this ( ) => Algorithms = algorithms ;

		internal override void EncodeData ( byte [ ] messageData , ref int currentPosition )
		{
			foreach ( DnsSecAlgorithm algorithm in Algorithms )
			{
				messageData [ currentPosition++ ] = ( byte )algorithm ;
			}
		}

		internal override void ParseData ( byte [ ] resultData , int startPosition , int length )
		{
			Algorithms = new List <DnsSecAlgorithm> ( length ) ;
			for ( int i = 0 ; i < length ; i++ )
			{
				Algorithms . Add ( ( DnsSecAlgorithm )resultData [ startPosition++ ] ) ;
			}
		}

	}

}
