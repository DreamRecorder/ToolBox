using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using DreamRecorder . ToolBox . AspNet . General ;

using Microsoft . AspNetCore . Builder ;
using Microsoft . AspNetCore . Hosting ;
using Microsoft . Extensions . Configuration ;
using Microsoft . Extensions . DependencyInjection ;
using Microsoft . Extensions . Hosting ;

namespace DreamRecorder . ToolBox . AspNet . Example
{

	public class Startup
	{

		public IConfiguration Configuration { get ; }

		public Startup ( IConfiguration configuration ) => Configuration = configuration ;

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure ( IApplicationBuilder app , IWebHostEnvironment env )
		{
			if ( env . IsDevelopment ( ) )
			{
				app . UseDeveloperExceptionPage ( ) ;
			}
			else
			{
				app . UseExceptionHandler ( "/Home/Error" ) ;

				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app . UseHsts ( ) ;
			}

			app . UseHttpsRedirection ( ) ;
			app . UseStaticFiles ( ) ;

			app . UseSession ( ) ;

			app . UseRouting ( ) ;

			app . UseAuthorization ( ) ;

			app . UseEndpoints (
								endpoints =>
								{
									endpoints . MapRazorPages ( ) ;
									endpoints . MapControllerRoute (
																	"default" ,
																	"{controller=Home}/{action=Index}/{id?}" ) ;
								} ) ;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices ( IServiceCollection services )
		{
			services . AddSession ( ) ;

			services . AddControllersWithViews ( ) ;
			services . AddRazorPages ( ) ;

			services . AddHttpClient ( ) ;

			services . AddSingleton <IWebAssetProvider , CdnjsWebAssetProvider> ( ) ;
		}

	}

}
