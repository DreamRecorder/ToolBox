using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public class MarkedValueGroup <TValue , TMark> : ICollection <MarkedValue <TValue , TMark>>
		where TValue : IEquatable <TValue>
	{

		public Dictionary <TValue , MarkedValue <TValue , TMark>> Values { get ; } =
			new Dictionary <TValue , MarkedValue <TValue , TMark>> ( ) ;

		public MarkedValue <TValue , TMark> this [ TValue value ]
		{
			get
			{
				if ( value == null )
				{
					return null ;
				}

				if ( Values . ContainsKey ( value ) )
				{
					return Values [ value ] ;
				}

				MarkedValue <TValue , TMark> markedValue = value ;
				Values . Add ( value , markedValue ) ;

				return markedValue ;
			}
		}

		IEnumerator <MarkedValue <TValue , TMark>> IEnumerable <MarkedValue <TValue , TMark>> .
			GetEnumerator ( )
			=> Values . Values . GetEnumerator ( ) ;

		public void Add ( MarkedValue <TValue , TMark> item )
		{
			Values . Add ( item . Value , item ) ;
		}

		public void Clear ( ) { Values . Clear ( ) ; }

		public bool Contains ( MarkedValue <TValue , TMark> item )
			=> Values . Values . Contains ( item ) ;

		public void CopyTo ( MarkedValue <TValue , TMark> [ ] array , int arrayIndex )
		{
			Values . Values . CopyTo ( array , arrayIndex ) ;
		}

		public bool Remove ( MarkedValue <TValue , TMark> item )
		{
			if ( item == null )
			{
				return false ;
			}

			return Values . Remove ( item ) ;
		}

		public int Count => Values . Count ;

		bool ICollection <MarkedValue <TValue , TMark>> . IsReadOnly => false ;

		public IEnumerator GetEnumerator ( ) => Values . GetEnumerator ( ) ;

	}

}
