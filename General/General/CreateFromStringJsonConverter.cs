using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Text . Json ;
using System . Text . Json . Serialization ;

namespace DreamRecorder . ToolBox . General ;

public class CreateFromStringJsonConverter <T> : JsonConverter <T> where T : ICreateFrom <T , string>
{

	public override T Read ( ref Utf8JsonReader reader , Type typeToConvert , JsonSerializerOptions options )
		=> T . CreateFrom ( reader . GetString ( ) ) ;

	public override void Write ( Utf8JsonWriter writer , T value , JsonSerializerOptions options )
	{
		writer . WriteStringValue ( value . ToString ( ) ) ;
	}

}
