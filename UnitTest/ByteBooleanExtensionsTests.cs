using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Runtime . InteropServices ;

using DreamRecorder . ToolBox . General ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest
{

	public enum PermissionStatus : byte
	{

		Allow ,

		Deny ,

	}

	public enum PermissionType : byte
	{

		Read ,

		Write ,

	}

	[StructLayout ( LayoutKind . Sequential , Pack = 1 )]
	public readonly struct Permission : IEquatable <Permission>
	{

		public bool Equals ( Permission other )
			=> Status == other . Status && Type == other . Type && Target . Equals ( other . Target ) ;

		public override bool Equals ( object obj ) => obj is Permission other && Equals ( other ) ;

		public override int GetHashCode ( ) => HashCode . Combine ( ( int )Status , ( int )Type , Target ) ;

		public static bool operator == ( Permission left , Permission right ) => left . Equals ( right ) ;

		public static bool operator != ( Permission left , Permission right ) => ! left . Equals ( right ) ;

		public PermissionStatus Status { get ; }

		public PermissionType Type { get ; }

		public Guid Target { get ; }

		public Permission ( PermissionStatus status , PermissionType type , Guid target )
		{
			Status = status ;
			Type   = type ;
			Target = target ;
		}

	}

	[TestClass]
	public class ByteBooleanExtensionsTests
	{

		[TestMethod]
		public void CastToBytesTest ( )
		{
			Permission source = new Permission (
												PermissionStatus . Allow ,
												PermissionType . Write ,
												Guid . Parse ( "162e0359-7a24-41d0-bc92-d627f51b9ae9" ) ) ;
			byte [ ]   buffer = source . CastToBytes ( ) ;
			Permission result = buffer . CastToStruct <Permission> ( ) ;

			Assert . AreEqual ( result , source ) ;
		}

		[TestMethod]
		public void CastToBytesTest2 ( )
		{
			List <Permission> source = new List <Permission>
									   {
										   new Permission (
														   PermissionStatus . Allow ,
														   PermissionType . Write ,
														   Guid . Parse ( "162e0359-7a24-41d0-bc92-d627f51b9ae9" ) ) ,
										   new Permission (
														   PermissionStatus . Allow ,
														   PermissionType . Read ,
														   Guid . Parse ( "D7A1809A-2E3B-4BCD-8927-3E2D96751F1F" ) ) ,
									   } ;

			byte [ ] buffer = source . CastToBytes ( ) ;

			List <Permission> result = buffer . CastToStructs <Permission> ( ) ;

			for ( int i = 0 ; i < source . Count ; i++ )
			{
				Assert . AreEqual ( result [ i ] , source [ i ] ) ;
			}
		}

		[TestMethod]
		public void ToBooleanArrayTest ( )
		{
			Assert . AreEqual (
							   0b0000_0001 ,
							   new [ ] { true , false , false , false , false , false , false , false , } .
								   ToByte ( ) ) ;
			Assert . AreEqual (
							   0b0000_1000 ,
							   new [ ] { false , false , false , true , false , false , false , false , } .
								   ToByte ( ) ) ;
			Assert . AreEqual (
							   0b0001_0000 ,
							   new [ ] { false , false , false , false , true , false , false , false , } .
								   ToByte ( ) ) ;
			Assert . AreEqual (
							   0b1000_0000 ,
							   new [ ] { false , false , false , false , false , false , false , true , } .
								   ToByte ( ) ) ;

			Assert . AreEqual (
							   new [ ] { true , true , true , true , true , true , true , true , } . ToByte ( ) ,
							   0b1111_1111 ) ;
			Assert . AreEqual (
							   new [ ] { false , false , false , false , false , false , false , false , } .
								   ToByte ( ) ,
							   0b0000_0000 ) ;

			Assert . ThrowsException <ArgumentException> ( ( ) => { new bool [ ] { } . ToByte ( ) ; } ) ;
			Assert . ThrowsException <ArgumentException> ( ( ) => { new [ ] { false , true , } . ToByte ( ) ; } ) ;
		}

		[TestMethod]
		public void ToByteArrayTest ( ) { }

	}

}
