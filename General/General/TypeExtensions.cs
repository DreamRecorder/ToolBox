using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Reflection ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class TypeExtensions
	{

		public static int GetInheritanceDepth ( this Type type )
		{
			return GetInheritanceDepth ( type , typeof ( object ) ) ;
		}

		public static Task PrepareAssembly <T> ( ) { return typeof ( T ) . Assembly . Prepare ( ) ; }

		public static int GetInheritanceDepth ( this Type type , Type baseType )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof(type) ) ;
			}

			if ( baseType == null )
			{
				throw new ArgumentNullException ( nameof(baseType) ) ;
			}

			if ( ! baseType . GetTypeInfo ( ) . IsAssignableFrom ( type . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof(baseType)} is not assignable from {nameof(type)}" ) ;
			}

			TypeInfo currentType = type . GetTypeInfo ( ) ;
			int count = 0 ;
			while ( baseType . GetTypeInfo ( ) . IsAssignableFrom ( currentType ) )
			{
				TypeInfo currentBaseType = currentType . GetTypeInfo ( ) . BaseType ? . GetTypeInfo ( ) ;
				if ( currentBaseType != null )
				{
					currentType = currentBaseType ;
					count++ ;
				}
				else
				{
					break ;
				}
			}

			return count ;
		}

	}

}
