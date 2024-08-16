using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace DreamRecorder.ToolBox.Network.Dns;

/// <summary>
///     Base class for a dns name identity
/// </summary>
public abstract class DnsMessageEntryBase : IEquatable <DnsMessageEntryBase>
{

	private int ? _hashCode;

	internal abstract int MaximumLength { get; }

	/// <summary>
	///     Domain name
	/// </summary>
	public DomainName Name { get; internal set; }

	/// <summary>
	///     Class of the record
	/// </summary>
	public RecordClass RecordClass { get; internal set; }

	/// <summary>
	///     Type of the record
	/// </summary>
	public RecordType RecordType { get; internal set; }

	public bool Equals ( DnsMessageEntryBase other )
	{
		if ( other == null )
		{
			return false;
		}

		return Name.Equals ( other.Name )
			   && RecordType.Equals ( other.RecordType )
			   && RecordClass.Equals ( other.RecordClass );
	}

	public override bool Equals ( object obj ) => Equals ( obj as DnsMessageEntryBase );

	[SuppressMessage ( "ReSharper" , "NonReadonlyMemberInGetHashCode" )]
	public override int GetHashCode ( )
	{
		if ( ! _hashCode.HasValue )
		{
			_hashCode = ToString ( ).GetHashCode ( );
		}

		return _hashCode.Value;
	}

	/// <summary>
	///     Returns the textual representation
	/// </summary>
	/// <returns> Textual representation </returns>
	public override string ToString ( ) => Name + " " + RecordType + " " + RecordClass;

}
