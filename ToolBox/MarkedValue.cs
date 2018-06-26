using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox
{

	[PublicAPI]
	public class MarkedValue<TValue, TMark>
	{

		public TValue Value { get; set; }

		public TMark Mark { get; set; }

		//public static implicit operator TMark(MarkedValue<TValue, TMark> value)
		//{
		//	return value.Mark;
		//}


		public MarkedValue(TValue value, TMark mark)
		{
			Value = value;
			Mark = mark;
		}

		public static implicit operator TValue(MarkedValue<TValue, TMark> value) { return value.Value; }

	}

}