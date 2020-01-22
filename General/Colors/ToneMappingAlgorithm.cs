using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

namespace DreamRecorder . ToolBox . Colors
{

	public delegate byte ToneMappingAlgorithm ( double value ) ;

	public delegate double HdrToneMappingAlgorithm ( double value , double upperLimit ) ;

}
