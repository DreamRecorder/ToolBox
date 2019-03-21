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

		public static int GetInheritanceDepth ( this Type type ) => GetInheritanceDepth ( type , typeof ( object ) ) ;

		public static Task PrepareAssembly <T> ( ) => typeof ( T ) . Assembly . Prepare ( ) ;

		public static int GetInheritanceDepth ( this Type type , Type baseType )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof (type) ) ;
			}

			if ( baseType == null )
			{
				throw new ArgumentNullException ( nameof (baseType) ) ;
			}

			if ( ! baseType . GetTypeInfo ( ) . IsAssignableFrom ( type . GetTypeInfo ( ) ) )
			{
				throw new ArgumentException ( $"{nameof (baseType)} is not assignable from {nameof (type)}" ) ;
			}

			TypeInfo currentType = type . GetTypeInfo ( ) ;
			int      count       = 0 ;

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

		public static List <PropertyInfo> GetSortedProperties ( this Type type )
		{
			List <PropertyInfo> result = type . GetProperties ( ) .
												Where ( prop => prop . GetCustomAttribute <IgnoreAttribute> ( )
																== null ) .
												ToList ( ) ;

			Comparison <PropertyInfo> comp = ( x , y )
												=> ( x . GetCustomAttribute <SortIndexAttribute> ( ) ? . Value
													?? int . MaxValue ) . CompareTo ( y . GetCustomAttribute <
																							SortIndexAttribute> ( ) ? .
																						Value
																					?? int . MaxValue ) ;

			result . Sort ( comp . Union ( ( x , y ) => string . CompareOrdinal ( x . Name , y . Name ) ) ) ;

			return result ;
		}

		public static List <PropertyInfo> GetSortedProperties <T> ( ) => typeof ( T ) . GetSortedProperties ( ) ;

		public static List <(PropertyInfo PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithAttribute
			<TAttribute> ( this Type type ) where TAttribute : Attribute
		{
			return type . GetSortedPropertiesWithNullableAttribute <TAttribute> ( ) .
						Where ( prop => prop . Attribute != null ) .
						ToList ( ) ;
		}

		public static List <(PropertyInfo PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithAttribute
			<T , TAttribute> ( ) where TAttribute : Attribute
			=> typeof ( T ) . GetSortedPropertiesWithAttribute <TAttribute> ( ) ;

		public static List <(PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithNullableAttribute
			<TAttribute> ( this Type type ) where TAttribute : Attribute
		{
			return type . GetSortedProperties ( ) .
						Select ( prop => ( (PropertyInfo PropertyInfo , TAttribute Attribute) )
									( prop , prop . GetCustomAttribute <TAttribute> ( true ) ) ) .
						ToList ( ) ;
		}

		public static List <(PropertyInfo PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithNullableAttribute
			<T , TAttribute> ( ) where TAttribute : Attribute
			=> typeof ( T ) . GetSortedPropertiesWithNullableAttribute <TAttribute> ( ) ;

	}

}
