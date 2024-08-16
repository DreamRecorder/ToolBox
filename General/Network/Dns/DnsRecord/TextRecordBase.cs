using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     Base record class for storing text labels (TxtRecord and SpfRecord)
/// </summary>
public abstract class TextRecordBase : DnsRecordBase , ITextRecord
{

	protected internal override int MaximumRecordDataLength
	{
		get { return TextParts.Sum ( p => p.Length + ( p.Length / 255 ) + ( p.Length % 255 == 0 ? 0 : 1 ) ); }
	}

	/// <summary>
	///     The single parts of the text data
	/// </summary>
	public IEnumerable <string> TextParts { get; protected set; }

	protected TextRecordBase ( ) { }

	protected TextRecordBase ( DomainName name , RecordType recordType , int timeToLive , string textData ) : this (
	 name ,
	 recordType ,
	 timeToLive ,
	 new List <string> { textData ?? string.Empty , } )
	{
	}

	protected TextRecordBase (
		DomainName           name ,
		RecordType           recordType ,
		int                  timeToLive ,
		IEnumerable <string> textParts ) : base ( name , recordType , RecordClass.INet , timeToLive )
		=> TextParts = new List <string> ( textParts );

	/// <summary>
	///     Text data
	/// </summary>
	public string TextData => string.Join ( string.Empty , TextParts );

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		foreach ( string part in TextParts )
		{
			DnsMessageBase.EncodeTextBlock ( messageData , ref currentPosition , part );
		}
	}

	internal override void ParseRecordData ( byte [ ] resultData , int startPosition , int length )
	{
		int endPosition = startPosition + length;

		List <string> textParts = new List <string> ( );
		while ( startPosition < endPosition )
		{
			textParts.Add ( DnsMessageBase.ParseText ( resultData , ref startPosition ) );
		}

		TextParts = textParts;
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length == 0 )
		{
			throw new FormatException ( );
		}

		TextParts = stringRepresentation;
	}

	internal override string RecordDataToString ( )
	{
		return string.Join ( " " , TextParts.Select ( x => "\"" + x.ToMasterfileLabelRepresentation ( ) + "\"" ) );
	}

}
