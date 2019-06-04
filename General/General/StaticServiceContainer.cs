using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System . Threading ;

using Microsoft.Extensions.DependencyInjection;

namespace DreamRecorder.ToolBox.General
{

    public static class StaticServiceProvider
    {

        public static IServiceProvider Provider { get; private set; }

        public static IServiceCollection ServiceCollection { get; set; } = new ServiceCollection();

        public static void Update()
        {
            try
            {
                lock (ServiceCollection)
                {
                    Provider = ServiceCollection.BuildServiceProvider(true);
                }

            }
            catch (Exception e)
			{
                Thread.Yield();
				Thread . Sleep ( 1 ) ;
				Update ( ) ;
			}
        }

    }

}
