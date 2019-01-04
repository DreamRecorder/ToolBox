using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	public class MarkedValueGroup<TValue,TMark>: ICollection<MarkedValue<TValue, TMark>> where TValue : IEquatable<TValue>
	{

		public Dictionary <TValue,MarkedValue <TValue , TMark>> Values { get; } = new Dictionary<TValue, MarkedValue<TValue, TMark>>() ;

		public MarkedValue <TValue , TMark> this [ TValue value]
		{
			get
			{
				if ( value == null )
				{
					return null;
				}
				if ( Values.ContainsKey(value) )
				{
					return Values [ value ] ;
				}
				else
				{
					MarkedValue <TValue , TMark> markedValue = value ;
					Values . Add ( value ,markedValue  ) ;
					return markedValue;
				}
			}
		}

		IEnumerator<MarkedValue <TValue , TMark>> IEnumerable<MarkedValue <TValue , TMark>> . GetEnumerator ( )
			=> Values.Values. GetEnumerator ( ) ;

		public void Add ( MarkedValue <TValue , TMark> item ) => Values . Add ( item.Value,item ) ;

		public void Clear ( ) => Values . Clear ( ) ;

		public bool Contains ( MarkedValue <TValue , TMark> item ) => Values.Values . Contains ( item ) ;

		public void CopyTo ( MarkedValue <TValue , TMark> [ ] array , int arrayIndex )
			=> Values.Values . CopyTo ( array , arrayIndex ) ;

		public bool Remove ( MarkedValue <TValue , TMark> item )
		{
			if ( item == null )
			{
				return false;
			}

			return Values . Remove ( item ) ;
		}

		public int Count => Values.Count;

		bool ICollection<MarkedValue<TValue, TMark>>.IsReadOnly => false ;

		public IEnumerator GetEnumerator ( ) => Values.GetEnumerator();

	}

	[PublicAPI]
	public class MarkedValue <TValue , TMark> : ICloneable , IEquatable <MarkedValue <TValue , TMark>>
		where TValue : IEquatable <TValue>
	{

		public TValue Value { get ; }

		public TMark Mark { get ; set ; }

		public MarkedValue ( TValue value , TMark mark )
		{
			Value = value ;
			Mark = mark ;
		}

		public object Clone ( ) { return new MarkedValue <TValue , TMark> ( Value , Mark ) ; }

		public bool Equals ( MarkedValue <TValue , TMark> other )
		{
			if ( other is null )
			{
				return false ;
			}

			return ReferenceEquals ( this , other )
					|| EqualityComparer <TValue> . Default . Equals ( Value , other . Value ) ;
		}

		public override bool Equals ( object obj )
		{
			if ( obj is null )
			{
				return false ;
			}

			if ( ReferenceEquals ( this , obj ) )
			{
				return true ;
			}

			return obj . GetType ( ) == GetType ( ) && Equals ( ( MarkedValue <TValue , TMark> ) obj ) ;
		}

		public override int GetHashCode ( ) { return EqualityComparer <TValue> . Default . GetHashCode ( Value ) ; }

		public static bool operator == ( MarkedValue <TValue , TMark> left , MarkedValue <TValue , TMark> right )
		{
			return Equals ( left , right ) ;
		}

		public static bool operator != ( MarkedValue <TValue , TMark> left , MarkedValue <TValue , TMark> right )
		{
			return ! Equals ( left , right ) ;
		}

		public static implicit operator TValue ( MarkedValue <TValue , TMark> value ) { return value . Value ; }

		public static implicit operator MarkedValue <TValue , TMark> ( TValue value )
		{
			return new MarkedValue <TValue , TMark> ( value , default ) ;
		}

	}

}
