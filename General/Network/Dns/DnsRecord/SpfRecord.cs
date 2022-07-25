using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsRecord
{

	/// <summary>
	///     <para>Sender Policy Framework</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc4408">RFC 4408</see>
	///         and
	///         <see cref="!:http://tools.ietf.org/html/rfc7208">RFC 7208</see>
	///     </para>
	/// </summary>
	[Obsolete]
	public class SpfRecord : TextRecordBase
	{

		internal SpfRecord ( ) { }

		/// <summary>
		///     Creates a new instance of the SpfRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="textData"> Text data of the record </param>
		public SpfRecord ( DomainName name , int timeToLive , string textData ) : base (
		name ,
		RecordType . Spf ,
		timeToLive ,
		textData )
		{
		}

		/// <summary>
		///     Creates a new instance of the SpfRecord class
		/// </summary>
		/// <param name="name"> Name of the record </param>
		/// <param name="timeToLive"> Seconds the record should be cached at most </param>
		/// <param name="textParts"> All parts of the text data </param>
		public SpfRecord ( DomainName name , int timeToLive , IEnumerable <string> textParts ) : base (
		name ,
		RecordType . Spf ,
		timeToLive ,
		textParts )
		{
		}

	}

}
