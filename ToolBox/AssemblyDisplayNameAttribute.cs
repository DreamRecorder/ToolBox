using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;

using JetBrains . Annotations ;

namespace DreamRecorder . ToolBox
{

	[PublicAPI][AttributeUsage(AttributeTargets.Assembly)]
	public sealed class AssemblyDisplayNameAttribute : Attribute
	{

		public string Name { get; }

		public AssemblyDisplayNameAttribute(string name) { Name = name; }

	}

}