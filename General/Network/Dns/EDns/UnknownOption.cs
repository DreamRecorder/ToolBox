using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . EDns
{

	/// <summary>
	///     Unknown EDNS option
	/// </summary>
	public class UnknownOption : EDnsOptionBase
	{

		/// <summary>
		///     Binary data of the option
		/// </summary>
		public byte [ ] Data { get ; private set ; }

		internal override ushort DataLength => ( ushort )( Data ? . Length ?? 0 ) ;

		internal UnknownOption ( EDnsOptionType type ) : base ( type ) { }

		/// <summary>
		///     Creates a new instance of the UnknownOption class
		/// </summary>
		/// <param name="type">Type of the option</param>
		/// <param name="data">The data of the option</param>
		public UnknownOption ( EDnsOptionType type , byte [ ] data ) : this ( type ) => Data = data ;

		internal override void EncodeData ( byte [ ] messageData , ref int currentPosition )
		{
			DnsMessageBase . EncodeByteArray ( messageData , ref currentPosition , Data ) ;
		}

		internal override void ParseData ( byte [ ] resultData , int startPosition , int length )
		{
			Data = DnsMessageBase . ParseByteData ( resultData , ref startPosition , length ) ;
		}

	}

}
