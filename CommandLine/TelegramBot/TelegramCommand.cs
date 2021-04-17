using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . General ;

using Telegram . Bot . Types ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public abstract class TelegramCommand <TUser> : ICommand <TUser> where TUser : IUser
	{

		public virtual string Name => GetType ( ) . Name . TrimEndPattern ( Constants . Command ) ;

		public virtual string DisplayName => Name ;

		public virtual string Introduction => string . Empty ;

		public abstract TimeSpan Timeout { get ; }

		public virtual bool Process (
			Message         message ,
			string [ ]      args ,
			Session <TUser> session ,
			bool            isExactlyMatched ,
			object          tag = null )
			=> true ;

		public virtual void Process (
			CallbackQuery   callbackQuery ,
			string [ ]      args ,
			Session <TUser> session ,
			object          tag = null )
		{
		}

		public abstract string HelpInformation { get ; }

		public abstract bool CanBeRouteTarget ( Session <TUser> session ) ;

		public abstract CommandPermissionGroup PermissionGroup { get ; }

	}

}
