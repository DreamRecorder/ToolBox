using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	internal interface IDnsSecValidatorContext
	{

		void AddResolvedDomainInValidation ( DomainName name , RecordType recordType ) ;

		bool HasDomainAlreadyBeenResolvedInValidation ( DomainName name , RecordType recordType ) ;

	}

}
