using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns.DnsRecord;

/// <summary>
///     <para>Geographical position</para>
///     <para>
///         Defined in
///         <see cref="!:http://tools.ietf.org/html/rfc1712">RFC 1712</see>
///     </para>
/// </summary>
public class GPosRecord : DnsRecordBase
{

	/// <summary>
	///     Altitude of the geographical position
	/// </summary>
	public double Altitude { get; private set; }

	/// <summary>
	///     Latitude of the geographical position
	/// </summary>
	public double Latitude { get; private set; }

	/// <summary>
	///     Longitude of the geographical position
	/// </summary>
	public double Longitude { get; private set; }

	protected internal override int MaximumRecordDataLength
		=> 3
		   + Longitude.ToString ( CultureInfo.InvariantCulture ).Length
		   + Latitude.ToString ( CultureInfo.InvariantCulture ).Length
		   + Altitude.ToString ( CultureInfo.InvariantCulture ).Length;

	internal GPosRecord ( ) { }

	/// <summary>
	///     Creates a new instance of the GPosRecord class
	/// </summary>
	/// <param name="name"> Name of the record </param>
	/// <param name="timeToLive"> Seconds the record should be cached at most </param>
	/// <param name="longitude"> Longitude of the geographical position </param>
	/// <param name="latitude"> Latitude of the geographical position </param>
	/// <param name="altitude"> Altitude of the geographical position </param>
	public GPosRecord ( DomainName name , int timeToLive , double longitude , double latitude , double altitude ) :
		base ( name , RecordType.GPos , RecordClass.INet , timeToLive )
	{
		Longitude = longitude;
		Latitude  = latitude;
		Altitude  = altitude;
	}

	protected internal override void EncodeRecordData (
		byte [ ]                         messageData ,
		int                              offset ,
		ref int                          currentPosition ,
		Dictionary <DomainName , ushort> domainNames ,
		bool                             useCanonical )
	{
		DnsMessageBase.EncodeTextBlock (
										messageData ,
										ref currentPosition ,
										Longitude.ToString ( CultureInfo.InvariantCulture ) );
		DnsMessageBase.EncodeTextBlock (
										messageData ,
										ref currentPosition ,
										Latitude.ToString ( CultureInfo.InvariantCulture ) );
		DnsMessageBase.EncodeTextBlock (
										messageData ,
										ref currentPosition ,
										Altitude.ToString ( CultureInfo.InvariantCulture ) );
	}

	internal override void ParseRecordData ( byte [ ] resultData , int currentPosition , int length )
	{
		Longitude = double.Parse (
								  DnsMessageBase.ParseText ( resultData , ref currentPosition ) ,
								  CultureInfo.InvariantCulture );
		Latitude = double.Parse (
								 DnsMessageBase.ParseText ( resultData , ref currentPosition ) ,
								 CultureInfo.InvariantCulture );
		Altitude = double.Parse (
								 DnsMessageBase.ParseText ( resultData , ref currentPosition ) ,
								 CultureInfo.InvariantCulture );
	}

	internal override void ParseRecordData ( DomainName origin , string [ ] stringRepresentation )
	{
		if ( stringRepresentation.Length != 3 )
		{
			throw new FormatException ( );
		}

		Longitude = double.Parse ( stringRepresentation [ 0 ] , CultureInfo.InvariantCulture );
		Latitude  = double.Parse ( stringRepresentation [ 1 ] , CultureInfo.InvariantCulture );
		Altitude  = double.Parse ( stringRepresentation [ 2 ] , CultureInfo.InvariantCulture );
	}

	internal override string RecordDataToString ( )
		=> Longitude.ToString ( CultureInfo.InvariantCulture )
		   + " "
		   + Latitude.ToString ( CultureInfo.InvariantCulture )
		   + " "
		   + Altitude.ToString ( CultureInfo.InvariantCulture );

}
