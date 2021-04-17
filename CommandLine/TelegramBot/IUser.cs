using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public interface IUser : IEquatable <IUser>
	{

		public Guid Guid { get ; }

		public T GetProperty <T> ( string name ) ;

		public void SetProperty <T> ( string name , T value ) ;

	}

}
