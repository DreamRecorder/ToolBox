using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Threading ;
using System . Threading . Tasks ;

using DreamRecorder . ToolBox . Network . Dns . DnsRecord ;
using DreamRecorder . ToolBox . Network . Dns . Resolver ;

namespace DreamRecorder . ToolBox . Network . Dns . DnsSec
{

	internal interface IInternalDnsSecResolver <in TState> where TState : IDnsSecValidatorContext
	{

		Task <DnsMessage> ResolveMessageAsync (
			DomainName        name ,
			RecordType        recordType ,
			RecordClass       recordClass ,
			TState            state ,
			CancellationToken token ) ;

		Task <DnsSecResult <TRecord>> ResolveSecureAsync <TRecord> (
			DomainName        name ,
			RecordType        recordType ,
			RecordClass       recordClass ,
			TState            state ,
			CancellationToken token ) where TRecord : DnsRecordBase ;

	}

}
