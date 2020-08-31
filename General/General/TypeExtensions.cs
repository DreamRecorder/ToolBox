using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class TypeExtensions
	{

		public static object GetDefault ( this Type type )
		{
			if ( type . IsValueType )
			{
				return Activator . CreateInstance ( type ) ;
			}

			return null ;
		}

		#region GetInheritanceDepth

		public static int GetInheritanceDepth <T> ( ) => GetInheritanceDepth ( typeof ( T ) ) ;

		public static int GetInheritanceDepth <T , TBase> ( )
			=> GetInheritanceDepth ( typeof ( T ) , typeof ( TBase ) ) ;


		public static int GetInheritanceDepth ( this Type type ) => GetInheritanceDepth ( type , typeof ( object ) ) ;

		public static int GetInheritanceDepth ( this Type type , Type baseType )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}

			if ( baseType == null )
			{
				throw new ArgumentNullException ( nameof ( baseType ) ) ;
			}

			if ( ! baseType . IsAssignableFrom ( type ) )
			{
				throw new ArgumentException ( $"{nameof ( baseType )} is not assignable from {nameof ( type )}." ) ;
			}

			Type currentType = type ;
			int  count       = 0 ;

			while ( baseType . IsAssignableFrom ( currentType ) )
			{
				Type currentBaseType = currentType . BaseType ;

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

		#endregion

		#region PrepareAssembly

		public static Task PrepareAssembly <T> ( ) => PrepareAssembly ( typeof ( T ) ) ;

		public static Task PrepareAssembly (
			[NotNull]
			this Type type )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}

			return type . Assembly . Prepare ( ) ;
		}

		#endregion

		#region GetResourceFile

		public static string GetResourceFile <T> ( string fileName ) => GetResourceFile ( typeof ( T ) , fileName ) ;

		public static string GetResourceFile (
			[NotNull]
			this Type type ,
			[NotNull]
			string fileName )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}

			if ( fileName == null )
			{
				throw new ArgumentNullException ( nameof ( fileName ) ) ;
			}

			Stream stream = type . Assembly . GetManifestResourceStream ( type , fileName ) ;
			if ( stream != null )
			{
				string license ;

				using ( StreamReader reader = new StreamReader ( stream ) )
				{
					license = reader . ReadToEnd ( ) ;
				}

				return license ;
			}

			return null ;
		}

		#endregion

		#region GetSortedProperties

		public static List <PropertyInfo> GetSortedProperties <T> ( ) => typeof ( T ) . GetSortedProperties ( ) ;

		public static List <PropertyInfo> GetSortedProperties (
			[NotNull]
			this Type type )
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}

			List <PropertyInfo> result = type . GetProperties ( ) .
												Where (
														prop
															=> prop . GetCustomAttribute <IgnoreAttribute> ( )
																== null ) .
												ToList ( ) ;

			Comparison <PropertyInfo> comp = ( x , y )
												=> ( x . GetCustomAttribute <SortIndexAttribute> ( ) ? . Value
													?? int . MaxValue ) . CompareTo (
												y . GetCustomAttribute <SortIndexAttribute> ( ) ? . Value
												?? int . MaxValue ) ;

			result . Sort ( comp . Union ( ( x , y ) => string . CompareOrdinal ( x . Name , y . Name ) ) ) ;

			return result ;
		}

		#endregion

		#region GetSortedPropertiesWithAttribute

		public static List <(PropertyInfo PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithAttribute
			<T , TAttribute> ( ) where TAttribute : Attribute
			=> typeof ( T ) . GetSortedPropertiesWithAttribute <TAttribute> ( ) ;

		public static List <(PropertyInfo PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithAttribute
			<TAttribute> (
				[NotNull]
				this Type type ) where TAttribute : Attribute
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}

			return type . GetSortedPropertiesWithNullableAttribute <TAttribute> ( ) .
						Where ( prop => prop . Attribute != null ) .
						ToList ( ) ;
		}

		#endregion

		#region GetSortedPropertiesWithNullableAttribute

		public static List <(PropertyInfo PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithNullableAttribute
			<T , TAttribute> ( ) where TAttribute : Attribute
			=> typeof ( T ) . GetSortedPropertiesWithNullableAttribute <TAttribute> ( ) ;

		public static List <(PropertyInfo , TAttribute Attribute)> GetSortedPropertiesWithNullableAttribute
			<TAttribute> (
				[NotNull]
				this Type type ) where TAttribute : Attribute
		{
			if ( type == null )
			{
				throw new ArgumentNullException ( nameof ( type ) ) ;
			}

			return type . GetSortedProperties ( ) .
						Select (
								prop
									=> ( (PropertyInfo PropertyInfo , TAttribute Attribute) )
									( prop , prop . GetCustomAttribute <TAttribute> ( true ) ) ) .
						ToList ( ) ;
		}

		#endregion

	}

}
