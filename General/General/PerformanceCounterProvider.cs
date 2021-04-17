using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Diagnostics ;
using System . Linq ;

namespace DreamRecorder . ToolBox . General
{

	public interface IPerformanceCounterProvider
	{

		PerformanceCounter GetPerformanceCounter (
			string categoryName = null ,
			string counterName  = null ,
			string instanceName = null ) ;

	}


	public class PerformanceCounterProvider : IPerformanceCounterProvider
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
				string categoryName = null ,
				string counterName  = null ,
				string instanceName = null )

			//categoryName ??= ProgramExtensions . GetProgramName ( ) ;
			//counterName ??=
			//	$"{CallerHelper . GetCaller ( ) . DeclaringType ? . Name}.{CallerHelper . GetCaller ( ) ? . Name}" ;
			//PerformanceCounterCategory customCategory = new PerformanceCounterCategory(categoryName);
			//CounterCreationData
			//MethodBase caller = CallerHelper . GetCaller ( ) ;
			//Assembly           assembly             =caller?.DeclaringType?.Assembly;
			//PerformanceCounter performanceCounter = new PerformanceCounter(ProgramExtensions.GetProgramName(), counterName);
			=> throw new NotImplementedException ( ) ;

	}

}
