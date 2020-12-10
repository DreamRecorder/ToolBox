using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . DependencyInjection . Extensions ;

namespace DreamRecorder . ToolBox . General
{

	public class StaticServiceProviderFactory : IServiceProviderFactory <IServiceCollection>
	{

		public IServiceCollection CreateBuilder ( IServiceCollection services )
		{
			StaticServiceProvider . ServiceCollection . Add ( services ) ;
			StaticServiceProvider . Update ( ) ;
			return StaticServiceProvider . ServiceCollection ;
		}

		public IServiceProvider CreateServiceProvider ( IServiceCollection containerBuilder )
			=> StaticServiceProvider . Provider ;

	}

}
