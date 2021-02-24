using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;
using System.Reflection;
using System . Threading ;
using System . Xml . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox . General
{

	public interface IPerformanceCounterProvider
	{

		PerformanceCounter GetPerformanceCounter ( string name ) ;

		

	}

	public static class CallerHelper
    {
		public static MethodBase GetCaller ( )
		{
			StackTrace stackTrace = new StackTrace();

			return stackTrace.GetFrame(2)?.GetMethod();
		}
    }

	public class PerformanceCounterProvider:IPerformanceCounterProvider
	{

		//public void sth ( )
		//{
		//	StackTrace stackTrace = new StackTrace();
		//	string categoryName = "Football";
		//	string counterName = "Goals scored";
		//	PerformanceCounter footballScoreCounter = new PerformanceCounter(categoryName, counterName);
		//	footballScoreCounter.ReadOnly = false;
			
		//	if (!PerformanceCounterCategory.Exists(categoryName))
		//	{
		//		string firstCounterName = "Goals scored";
		//		string firstCounterHelp = "Goals scored live update";
		//		string categoryHelp     = "Football related real time statistics";

		//		PerformanceCounterCategory customCategory = new PerformanceCounterCategory(categoryName);
		//		PerformanceCounterCategory.Create(categoryName, categoryHelp, PerformanceCounterCategoryType.SingleInstance, firstCounterName, firstCounterHelp);
		//	}

		//	while (true)
		//	{
		//		footballScoreCounter.Increment();
		//		Thread.Sleep(1000);
		//		Random random = new Random();
		//		int    goals  = random.Next(-5, 6);
		//		footballScoreCounter.IncrementBy(goals);
		//		Thread.Sleep(1000);
		//	}
		//}

		public PerformanceCounter GetPerformanceCounter (
			[NotNull]
			string name )
		{
			if ( name == null )
			{
				throw new ArgumentNullException ( nameof ( name ) ) ;
			}

			var caller = CallerHelper . GetCaller ( ) ;

			var assembly =caller?.DeclaringType?.Assembly;

			throw new NotImplementedException ( ) ;
		}

	}


	public interface ISelfSerializable
	{

		/// <summary>
		/// </summary>
		/// <returns></returns>
		[NotNull]
		XElement ToXElement ( ) ;

	}

}
