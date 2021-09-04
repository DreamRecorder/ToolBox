using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . TelegramBot
{

	public class CommandPermissionGroup : IEquatable <CommandPermissionGroup>
	{

		public string DisplayName { get ; set ; }

		public Guid Guid { get ; }

		public CommandPermissionGroup ( string displayName , Guid guid )
		{
			DisplayName = displayName ;
			Guid        = guid ;
		}

		public bool Equals ( CommandPermissionGroup other )
		{
			if ( other is null )
			{
				return false ;
			}

			if ( ReferenceEquals ( this , other ) )
			{
				return true ;
			}

			return Guid . Equals ( other . Guid ) ;
		}

		public override bool Equals ( object obj )
		{
			if ( obj is null )
			{
				return false ;
			}

			if ( ReferenceEquals ( this , obj ) )
			{
				return true ;
			}

			if ( obj . GetType ( ) != GetType ( ) )
			{
				return false ;
			}

			return Equals ( ( CommandPermissionGroup )obj ) ;
		}

		public override int GetHashCode ( ) => Guid . GetHashCode ( ) ;

		public static bool operator == ( CommandPermissionGroup left , CommandPermissionGroup right )
			=> Equals ( left , right ) ;

		public static bool operator != ( CommandPermissionGroup left , CommandPermissionGroup right )
			=> ! Equals ( left , right ) ;

	}

}
