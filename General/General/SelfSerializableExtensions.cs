using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . ComponentModel ;
using System . Linq ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	[PublicAPI]
	public static class SelfSerializableExtensions
	{

		public static string ToXmlString ( [NotNull] this ISelfSerializable item )
		{
			if ( item == null )
			{
				throw new ArgumentNullException ( nameof (item) ) ;
			}

			return item . ToXElement ( ) . ToString ( ) ;
		}

		public static T ReadNecessaryValue <T> ( this XElement element , string name )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof (element) ) ;
			}

			if ( name == null )
			{
				throw new ArgumentNullException ( nameof (name) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				throw new ArgumentException ( ExceptionMessages . NecessaryValueNotFound ( element , name ) ) ;
			}

			TypeConverter typeConverter = TypeDescriptor . GetConverter ( typeof ( T ) ) ;

			return ( T ) typeConverter . ConvertFromString ( value ) ;
		}

		public static T ReadUnnecessaryValue <T> ( this XElement element , string name , T defaultValue )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof (element) ) ;
			}

			if ( name == null )
			{
				throw new ArgumentNullException ( nameof (name) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				return defaultValue ;
			}

			TypeConverter typeConverter = TypeDescriptor . GetConverter ( typeof ( T ) ) ;

			return ( T ) typeConverter . ConvertFromString ( value ) ;
		}

	}

}
