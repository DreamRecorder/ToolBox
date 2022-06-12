using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	internal interface IDnsSecValidatorContext
	{

		bool HasDomainAlreadyBeenResolvedInValidation ( DomainName name , RecordType recordType ) ;

		void AddResolvedDomainInValidation ( DomainName name , RecordType recordType ) ;

	}

}
