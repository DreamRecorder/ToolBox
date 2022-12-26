using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using Microsoft . AspNetCore . Mvc ;
using Microsoft . AspNetCore . Mvc . ModelBinding ;
using Microsoft . AspNetCore . Mvc . ModelBinding . Binders ;
using Microsoft . AspNetCore . Mvc . ModelBinding . Metadata ;

namespace DreamRecorder . ToolBox . AspNet . General ;

public class HeaderComplexModelBinderProvider : IModelBinderProvider
{

	public IModelBinder GetBinder ( ModelBinderProviderContext context )
	{
		if ( context == null )
		{
			throw new ArgumentNullException ( nameof ( context ) ) ;
		}

		if ( context . Metadata . IsComplexType )
		{
			if ( context . Metadata is DefaultModelMetadata metadata )
			{
				object headerAttribute =
					metadata . Attributes . Attributes . FirstOrDefault (
																		 a
																			 => a . GetType ( )
																				 == typeof ( FromHeaderAttribute ) ) ;

				if ( headerAttribute != null )
				{
					return new BinderTypeModelBinder ( typeof ( HeaderComplexModelBinder ) ) ;
				}
			}
		}

		return null ;
	}

}
