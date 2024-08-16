using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using DreamRecorder.ToolBox.AspNet.General;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace DreamRecorder.ToolBox.AspNet.CommonComponent;

[HtmlTargetElement ( "commonfooter" )]
public class CommonFooterTagHelper : TagHelper
{

	private static string CommonFooter { get; set; } = null;

	private HttpClient HttpClient { get; }

	private static DateTimeOffset ? LastUpdate { get; set; } = null;

	public CommonFooterTagHelper ( HttpClient httpClient ) => HttpClient = httpClient;

	public override async Task ProcessAsync ( TagHelperContext context , TagHelperOutput output )
	{
		output.TagName = @"div";
		output.TagMode = TagMode.StartTagAndEndTag;

		if ( LastUpdate is DateTimeOffset lastUpdate
			 && lastUpdate > DateTimeOffset.Now - TimeSpan.FromHours ( 1 ) )
		{
			output.Content.SetHtmlContent ( CommonFooter );
		}
		else
		{
			try
			{
				output.Content.SetHtmlContent (
											   CommonFooter =
												   await HttpClient.GetStringAsync (
													$"{ConstantUrls.WebResource}CommonFooter.html" ) );
			}
			catch ( Exception )
			{
			}
			finally
			{
				LastUpdate = DateTimeOffset.Now;
			}
		}
	}

}
