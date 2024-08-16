using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace DreamRecorder.ToolBox.General;

public class LoadingTypeConverter <TSource , TTarget> : TypeConverter where TTarget : ILoadFrom <TSource> , new ( )
{

	public override bool CanConvertFrom ( ITypeDescriptorContext context , [NotNullWhen ( true )] Type sourceType )
		=> sourceType == typeof ( TSource ) || base.CanConvertFrom ( context , sourceType );

	public override bool CanConvertTo ( ITypeDescriptorContext context , [NotNullWhen ( true )] Type destinationType )
		=> destinationType == typeof ( TSource ) || base.CanConvertTo ( context , destinationType );

	public override object ConvertFrom ( ITypeDescriptorContext context , CultureInfo culture , object value )
	{
		if ( value is TSource source )
		{
			TTarget target = ( new TTarget ( ) );
			target.LoadFrom ( source );
			return target;
		}

		return base.ConvertFrom ( context , culture , value );
	}

	public override object ConvertTo (
		ITypeDescriptorContext context ,
		CultureInfo            culture ,
		object                 value ,
		Type                   destinationType )
	{
		if ( value is TTarget t
			 && destinationType == typeof ( TSource ) )
		{
			return t.ToT ( );
		}

		return base.ConvertTo ( context , culture , value , destinationType );
	}

}
