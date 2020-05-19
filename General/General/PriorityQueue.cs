using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public class PriorityQueue <T> : IEnumerable <T> , IReadOnlyCollection <T>
	{

		private LinkedList <T> Items { get ; }

		public Comparison <T> Comparison { get ; }

		public PriorityQueue ( Comparison <T> comparison = null )
		{
			Items      = new LinkedList <T> ( ) ;
			Comparison = comparison ?? Comparer <T> . Default . Compare ;
		}

		public IEnumerator <T> GetEnumerator ( )
		{
			lock ( Items )
			{
				return Items . GetEnumerator ( ) ;
			}
		}

		IEnumerator IEnumerable . GetEnumerator ( )
		{
			lock ( Items )
			{
				return GetEnumerator ( ) ;
			}
		}

		public int Count
		{
			get
			{
				lock ( Items )
				{
					return Items . Count ;
				}
			}
		}

		public void Enqueue ( T item )
		{
			lock ( Items )
			{
				Items . AddLast ( item ) ;
			}
		}

		public bool TryDequeue ( out T result )
		{
			lock ( Items )
			{
				TryPeak ( out result ) ;

				return Items . Remove ( result ) ;
			}
		}

		public bool TryPeak ( out T result )
		{
			lock ( Items )
			{
				if ( Items . Any ( ) )
				{
					result = Items . First ( ) ;
				}
				else
				{
					result = default ;
					return false ;
				}

				foreach ( T item in Items )
				{
					if ( Comparison ( result , item ) > 0 )
					{
						result = item ;
					}
				}

				return true ;
			}
		}

		public bool IsEmpty ( )
		{
			lock ( Items )
			{
				return ! Items . Any ( ) ;
			}
		}

	}

}
