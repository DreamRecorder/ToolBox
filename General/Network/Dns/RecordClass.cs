using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns;

/// <summary>
///     DNS record class
/// </summary>
public enum RecordClass : ushort
{

	/// <summary>
	///     Invalid record class
	/// </summary>
	Invalid = 0 ,

	/// <summary>
	///     <para>Record class Internet (IN)</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>

	// ReSharper disable once InconsistentNaming
	INet = 1 ,

	/// <summary>
	///     <para>Record class Chaois (CH)</para>
	///     <para>
	///         Defined: D. Moon, "Chaosnet", A.I. Memo 628, Massachusetts Institute of Technology Artificial Intelligence
	///         Laboratory, June 1981.
	///     </para>
	/// </summary>
	Chaos = 3 ,

	/// <summary>
	///     <para>Record class Hesiod (HS)</para>
	///     <para>Defined: Dyer, S., and F. Hsu, "Hesiod", Project Athena Technical Plan - Name Service, April 1987.</para>
	/// </summary>
	Hesiod = 4 ,

	/// <summary>
	///     <para>Record class NONE</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc2136">RFC 2136</see>
	///     </para>
	/// </summary>
	None = 254 ,

	/// <summary>
	///     <para>Record class * (ANY)</para>
	///     <para>
	///         Defined in
	///         <see cref="!:http://tools.ietf.org/html/rfc1035">RFC 1035</see>
	///     </para>
	/// </summary>
	Any = 255 ,

}

internal static class RecordClassHelper
{

	public static string ToShortString ( this RecordClass recordClass )
	{
		switch ( recordClass )
		{
			case RecordClass.INet :
				return "IN";
			case RecordClass.Chaos :
				return "CH";
			case RecordClass.Hesiod :
				return "HS";
			case RecordClass.None :
				return "NONE";
			case RecordClass.Any :
				return "*";
			default :
				return "CLASS" + ( int )recordClass;
		}
	}

	public static bool TryParseShortString ( string s , out RecordClass recordClass , bool allowAny = true )
	{
		if ( string.IsNullOrEmpty ( s ) )
		{
			recordClass = RecordClass.Invalid;
			return false;
		}

		switch ( s.ToUpperInvariant ( ) )
		{
			case "IN" :
				recordClass = RecordClass.INet;
				return true;

			case "CH" :
				recordClass = RecordClass.Chaos;
				return true;

			case "HS" :
				recordClass = RecordClass.Hesiod;
				return true;

			case "NONE" :
				recordClass = RecordClass.None;
				return true;

			case "*" :
				if ( allowAny )
				{
					recordClass = RecordClass.Any;
					return true;
				}
				else
				{
					recordClass = RecordClass.Invalid;
					return false;
				}

			default :
				if ( s.StartsWith ( "CLASS" , StringComparison.InvariantCultureIgnoreCase ) )
				{
					if ( ushort.TryParse ( s.Substring ( 5 ) , out ushort classValue ) )
					{
						recordClass = ( RecordClass )classValue;
						return true;
					}
				}

				recordClass = RecordClass.Invalid;
				return false;
		}
	}

}
