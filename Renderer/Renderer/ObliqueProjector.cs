using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace DreamRecorder.ToolBox.Renderer;

public class ObliqueProjector : Projector
{

	public override Vector3 Direction => new Vector3 ( - Height , - Height * 2 , - Height );

	protected override Vector2 CalculateProject ( Vector3 relativePoint )
		=> new Vector2 ( relativePoint.X - relativePoint.Y / 2 , - ( relativePoint.Z - relativePoint.Y / 2 ) );

	protected override Vector3 CalculateProject ( Vector2 point )
		=> new Vector3 ( point.X + point.Y , point.Y * 2 , 0 );

}
