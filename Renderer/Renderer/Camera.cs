using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Numerics ;

using DreamRecorder . ToolBox . General ;

namespace DreamRecorder . ToolBox . Renderer
{

	/// <summary>
	///     Camera have position
	/// </summary>
	public abstract class Camera : ICamera
	{

		//Z
		public Vector3 Forward => Vector3 . Normalize ( LookAt - Position ) ;

		//X
		public Vector3 Right => Vector3 . Normalize ( Vector3 . Cross ( Forward , - Vector3 . UnitY ) ) ;

		//Y
		public Vector3 Up => Vector3 . Normalize ( Vector3 . Cross ( Forward , Right ) ) ;

		public Angle FOV { get ; set ; }

		public virtual Matrix4x4 WorldConversionMatrix => Matrix4x4 . CreateLookAt ( Position , LookAt , Up ) ;

		public virtual Matrix4x4 CameraConversionMatrix
		{
			get
			{
				if ( Matrix4x4 . Invert ( WorldConversionMatrix , out Matrix4x4 result ) )
				{
					return result ;
				}

				throw new Exception ( ) ;
			}
		}

		protected double HalfFovTan => Math . Tan ( FOV / 2 ) ;

		public Camera ( ) { }

		public Camera ( Vector3 position , Vector3 lookAt )
		{
			Position = position ;
			LookAt   = lookAt ;
		}

		public Vector3 Position { get ; set ; }

		public Vector3 LookAt { get ; set ; }

		public float ScreenWidth { get ; set ; }

		public Ray Project ( Vector2 point )
		{
			Vector3 result = CalculateProject ( point ) ;

			return new Ray ( Position , result ) . Transform ( CameraConversionMatrix ) ;
		}

		public Vector2 Project ( Vector3 point )
		{
			Vector2 result = CalculateProject ( point ) ;
			double  resize = ScreenWidth / HalfFovTan ;

			return new Vector2 ( ( float ) ( result . X * resize ) , ( float ) ( result . Y * resize ) ) ;
		}

		protected abstract Vector2 CalculateProject ( Vector3 relativePoint ) ;

		protected abstract Vector3 CalculateProject ( Vector2 point ) ;

		public virtual Vector3 WorldConversion ( Vector3 worldPosition )
			=> Vector3 . Transform ( worldPosition , WorldConversionMatrix ) ;

		public virtual Vector3 CameraConversion ( Vector3 cameraPosition )
			=> Vector3 . Transform ( cameraPosition , CameraConversionMatrix ) ;

	}

}
