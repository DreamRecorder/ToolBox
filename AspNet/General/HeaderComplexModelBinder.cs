using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text . Json ;
using System . Threading . Tasks ;

using JetBrains . Annotations ;

using Microsoft . AspNetCore . Mvc ;
using Microsoft . AspNetCore . Mvc . ModelBinding ;

namespace DreamRecorder . ToolBox . AspNet . General
{

	public class HeaderComplexModelBinder : IModelBinder
	{

		public Task BindModelAsync ( ModelBindingContext bindingContext )
		{
			if ( bindingContext == null )
			{
				throw new ArgumentNullException ( nameof ( bindingContext ) ) ;
			}

			string headerKey = bindingContext . ModelMetadata . BinderModelName ?? bindingContext . FieldName ;

			if ( ! string . IsNullOrEmpty ( headerKey ) )
			{
				string headerValue =
					bindingContext . HttpContext . Request . Headers [ headerKey ] . FirstOrDefault ( ) ;

				if ( ! string . IsNullOrEmpty ( headerValue ) )
				{
					Type modelType = bindingContext . ModelMetadata . ModelType ;

					bindingContext . Model  = JsonSerializer . Deserialize ( headerValue , modelType ) ;
					bindingContext . Result = ModelBindingResult . Success ( bindingContext . Model ) ;

					return Task . CompletedTask ;
				}
			}

			bindingContext . Result = ModelBindingResult . Failed ( ) ;

			return Task . CompletedTask ;
		}

		public static Action <MvcOptions> EnableHeaderComplexModelBinder ( [CanBeNull] Action <MvcOptions> next = null )
		{
			void AddModelBinder ( MvcOptions options )
			{
				if ( options == null )
				{
					throw new ArgumentNullException ( nameof ( options ) ) ;
				}

				options . ModelBinderProviders . Insert ( 0 , new HeaderComplexModelBinderProvider ( ) ) ;

				next ? . Invoke ( options ) ;
			}

			return AddModelBinder ;
		}

	}

}
