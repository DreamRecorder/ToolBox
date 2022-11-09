using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

using Telegram . Bot . Types ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface ICommand <TUser> where TUser : IUser
	{

		string DisplayName { get ; }

		string HelpInformation { get ; }

		string Introduction { get ; }

		[NotNull]
		string Name { get ; }

		[CanBeNull]
		CommandPermissionGroup PermissionGroup { get ; }

		TimeSpan Timeout { get ; }

		bool CanBeRouteTarget ( Session <TUser> session ) ;

		bool Process (
			[NotNull]               Message         message ,
			[NotNull] [ItemNotNull] string [ ]      args ,
			[NotNull]               Session <TUser> session ,
			bool                                    isExactlyMatched ,
			[CanBeNull] object                      tag ) ;

		void Process (
			[NotNull]               CallbackQuery   callbackQuery ,
			[NotNull] [ItemNotNull] string [ ]      args ,
			[NotNull]               Session <TUser> session ,
			[CanBeNull]             object          tag ) ;

	}

}
