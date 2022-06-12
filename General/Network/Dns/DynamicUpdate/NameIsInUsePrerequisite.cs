using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DynamicUpdate
{

	/// <summary>
	///     Prequisite, that a name exists
	/// </summary>
	public class NameIsInUsePrerequisite : PrerequisiteBase
	{

		protected internal override int MaximumRecordDataLength => 0 ;

		internal NameIsInUsePrerequisite ( ) { }

		/// <summary>
		///     Creates a new instance of the NameIsInUsePrerequisite class
		/// </summary>
		/// <param name="name"> Name that should be checked </param>
		public NameIsInUsePrerequisite ( DomainName name ) : base ( name , RecordType . Any , RecordClass . Any , 0 ) { }

		internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length ) { }

		protected internal override void EncodeRecordData (
			byte [ ]                         messageData ,
			int                              offset ,
			ref int                          currentPosition ,
			Dictionary <DomainName , ushort> domainNames ,
			bool                             useCanonical )
		{
		}

	}

}
