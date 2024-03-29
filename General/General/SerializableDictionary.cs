﻿using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Xml ;
using System . Xml . Schema ;
using System . Xml . Serialization ;

namespace DreamRecorder . ToolBox . General
{

	[XmlRoot ( "dictionary" )]
	public class SerializableDictionary <TKey , TValue> : Dictionary <TKey , TValue> , IXmlSerializable
	{

		#region IXmlSerializable Members

		public XmlSchema GetSchema ( ) => null ;

		public void ReadXml ( XmlReader reader )
		{
			XmlSerializer keySerializer   = new XmlSerializer ( typeof ( TKey ) ) ;
			XmlSerializer valueSerializer = new XmlSerializer ( typeof ( TValue ) ) ;

			bool wasEmpty = reader . IsEmptyElement ;
			reader . Read ( ) ;

			if ( wasEmpty )
			{
				return ;
			}

			while ( reader . NodeType != XmlNodeType . EndElement )
			{
				reader . ReadStartElement ( "item" ) ;

				reader . ReadStartElement ( "key" ) ;
				TKey key = ( TKey )keySerializer . Deserialize ( reader ) ;
				reader . ReadEndElement ( ) ;

				reader . ReadStartElement ( "value" ) ;
				TValue value = ( TValue )valueSerializer . Deserialize ( reader ) ;
				reader . ReadEndElement ( ) ;

				Add ( key , value ) ;

				reader . ReadEndElement ( ) ;
				reader . MoveToContent ( ) ;
			}

			reader . ReadEndElement ( ) ;
		}

		public void WriteXml ( XmlWriter writer )
		{
			XmlSerializer keySerializer   = new XmlSerializer ( typeof ( TKey ) ) ;
			XmlSerializer valueSerializer = new XmlSerializer ( typeof ( TValue ) ) ;

			foreach ( TKey key in Keys )
			{
				writer . WriteStartElement ( "item" ) ;

				writer . WriteStartElement ( "key" ) ;
				keySerializer . Serialize ( writer , key ) ;
				writer . WriteEndElement ( ) ;

				writer . WriteStartElement ( "value" ) ;
				TValue value = this [ key ] ;
				valueSerializer . Serialize ( writer , value ) ;
				writer . WriteEndElement ( ) ;

				writer . WriteEndElement ( ) ;
			}
		}

		#endregion

	}

}
