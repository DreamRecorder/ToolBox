using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . IO ;
using System . Linq ;
using System . Reflection ;
using System . Runtime . Serialization ;
using System . Text ;
using System . Xml ;
using System . Xml . Linq ;
using System . Xml . Serialization ;

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
				throw new ArgumentNullException ( nameof ( item ) ) ;
			}

			return item . ToXElement ( ) . ToString ( ) ;
		}

		public static T ReadNecessaryValue <T> ( this XElement element , string name )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}

			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				throw new ArgumentException ( ExceptionMessages . NecessaryValueNotFound ( element , name ) ) ;
			}

			return value . ParseTo <T> ( ) ;
		}

		public static T ReadUnnecessaryValue <T> ( this XElement element , string name , T defaultValue )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}

			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			string value = element . Attribute ( name ) ? . Value ;

			if ( value == null )
			{
				return defaultValue ;
			}

			return value . ParseTo <T> ( ) ;
		}

		public static string Serialize <T> ( [NotNull] this T obj , Type [ ] types = null )
		{
			if ( obj == null )
			{
				throw new ArgumentNullException ( nameof ( obj ) ) ;
			}

			if ( typeof ( ISelfSerializable ) . IsAssignableFrom ( typeof ( T ) ) )
			{
				return ( ( ISelfSerializable ) obj ) . ToXElement ( ) . ToString ( ) ;
			}
			else
			{
				using MemoryStream memoryStream = new MemoryStream ( ) ;

				using XmlWriter xmlWriter = XmlWriter . Create (
																memoryStream ,
																new XmlWriterSettings
																{
																	Async              = false ,
																	Encoding           = Encoding . UTF8 ,
																	OmitXmlDeclaration = true
																} ) ;

				if ( typeof ( T ) . GetCustomAttribute <DataContractAttribute> ( )   != null
					|| typeof ( T ) . GetCustomAttribute <SerializableAttribute> ( ) != null )
				{
					DataContractSerializer dataContractSerializer =
						new DataContractSerializer ( typeof ( T ) , types ?? typeof ( T ) . Assembly . GetTypes ( ) ) ;

					dataContractSerializer . WriteObject ( xmlWriter , obj ) ;
				}
				else
				{
					XmlSerializer xmlSerializer = new XmlSerializer (
																	typeof ( T ) ,
																	types
																	?? typeof ( T ) . Assembly .
																					GetExportedTypes ( ) ) ;
					xmlSerializer . Serialize (
												xmlWriter ,
												obj ,
												new XmlSerializerNamespaces ( new [ ] { XmlQualifiedName . Empty } ) ) ;
				}

				xmlWriter . Flush ( ) ;

				return Encoding . UTF8 . GetString ( memoryStream . ToArray ( ) ) ;
			}
		}

		public static T Deserialize <T> ( [NotNull] this string element , Type [ ] types = null )
		{
			if ( element == null )
			{
				throw new ArgumentNullException ( nameof ( element ) ) ;
			}

			if ( typeof ( ISelfSerializable ) . IsAssignableFrom ( typeof ( T ) ) )
			{
				return ( T ) Activator . CreateInstance ( typeof ( T ) , XElement . Parse ( element ) ) ;
			}
			else
			{
				if ( typeof ( T ) . GetCustomAttribute <DataContractAttribute> ( )   != null
					|| typeof ( T ) . GetCustomAttribute <SerializableAttribute> ( ) != null )
				{
					DataContractSerializer dataContractSerializer =
						new DataContractSerializer ( typeof ( T ) , types ?? typeof ( T ) . Assembly . GetTypes ( ) ) ;
					return ( T ) dataContractSerializer . ReadObject (
																	new MemoryStream (
																					Encoding . UTF8 . GetBytes (
																												element ) ) ) ;
				}
				else
				{
					XmlSerializer xmlSerializer = new XmlSerializer (
																	typeof ( T ) ,
																	types
																	?? typeof ( T ) . Assembly .
																					GetExportedTypes ( ) ) ;
					return ( T ) xmlSerializer . Deserialize (
															new MemoryStream (
																			Encoding . UTF8 . GetBytes ( element ) ) ) ;
				}
			}
		}

	}

}
