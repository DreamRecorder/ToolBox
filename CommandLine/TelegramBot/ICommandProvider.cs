using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface ICommandProvider <TUser> where TUser : IUser
	{

		[CanBeNull]
		ICommand <TUser> GetCommand ( string name , Session <TUser> session ) ;

		[NotNull]
		ICommand <TUser> GetCommandFuzzy ( string name , Session <TUser> session ) ;

		[NotNull]
		[ItemNotNull]
		IEnumerable <ICommand <TUser>> GetCommands ( ) ;

	}

}
