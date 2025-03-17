using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.Network;

[PublicAPI]
public abstract class Address : ICloneable , IEquatable <Address> , IAddress
{

	public abstract AddressType Type { get; }

	[Key]
	public Memory <byte> AddressBytes { get; set; }

	public abstract object Clone ( );

	public virtual bool Equals ( Address other )
	{
		if ( other is null )
		{
			return false;
		}

		if ( ReferenceEquals ( this , other ) )
		{
			return true;
		}

		return AddressBytes.Span.SequenceEqual ( other.AddressBytes.Span ) && Type == other.Type;
	}

	public override bool Equals ( object obj )
	{
		if ( obj is null )
		{
			return false;
		}

		if ( ReferenceEquals ( this , obj ) )
		{
			return true;
		}

		if ( obj.GetType ( ) != GetType ( ) )
		{
			return false;
		}

		return Equals ( ( Address )obj );
	}

	public override int GetHashCode ( ) => AddressBytes.GetHashCode ( );

	public static bool operator == ( Address left , Address right ) => Equals ( left , right );

	public static explicit operator string ( Address address ) => address.ToString ( );

	public static implicit operator byte [ ] ( Address address ) => address.AddressBytes.ToArray ( );

	public static bool operator != ( Address left , Address right ) => ! Equals ( left , right );

}
