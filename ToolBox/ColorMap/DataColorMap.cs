using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . ColorMap
{

	public abstract class DataColorMap : ColorMap
	{

		protected abstract HdrColor[] Data { get; }

		protected override HdrColor MapOverride(double value)
		{
			value *= 255;
			int flooredValue = Convert.ToInt32(Math.Floor(value));
			double lastValue = value - flooredValue;
			HdrColor data = Data[flooredValue] + lastValue * (Data[flooredValue + 1] - Data[flooredValue]);
			return data;
		}

	}

}