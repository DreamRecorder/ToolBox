using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;

namespace DreamRecorder . ToolBox . Network . Dns . DynamicUpdate
{

	/// <summary>
	///     Base class for perquisites of dynamic dns updates
	/// </summary>
	public abstract class PrerequisiteBase : DnsRecordBase
	{

		internal PrerequisiteBase ( ) { }

		protected PrerequisiteBase (
			DomainName  name ,
			RecordType  recordType ,
			RecordClass recordClass ,
			int         timeToLive ) : base ( name , recordType , recordClass , timeToLive )
		{
		}

		internal override string RecordDataToString ( ) => null ;

		internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
		{
			throw new NotSupportedException ( ) ;
		}

	}

}
