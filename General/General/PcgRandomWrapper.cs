using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Pcg ;

namespace DreamRecorder . ToolBox . General ;

public sealed class PcgRandomWrapper : IRandom
{

	private readonly PcgRandom _target ;

	public PcgRandomWrapper ( PcgRandom target ) => _target = target ;

	public int Next ( ) => _target . Next ( ) ;

	public int Next ( int maxValue ) => _target . Next ( maxValue ) ;

	public int Next ( int minValue , int maxValue ) => _target . Next ( minValue , maxValue ) ;

	public void NextBytes ( byte [ ] buffer ) { _target . NextBytes ( buffer ) ; }

	public double NextDouble ( ) => _target . NextDouble ( ) ;

	public static implicit operator PcgRandom ( PcgRandomWrapper wrapper ) => wrapper . _target ;

	public static implicit operator PcgRandomWrapper ( PcgRandom target ) => new PcgRandomWrapper ( target ) ;

}
