using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . TelegramBot ;

namespace DreamRecorder . ToolBox . CommandLine . Example . Telegram
{

	public class User : IUser
	{

		public bool Equals ( IUser other ) => throw new NotImplementedException ( ) ;

		public Guid Guid { get ; }

		public T GetProperty <T> ( string name ) => throw new NotImplementedException ( ) ;

		public void SetProperty <T> ( string name , T value ) { throw new NotImplementedException ( ) ; }

	}

}
