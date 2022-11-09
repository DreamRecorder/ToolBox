using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Security . Cryptography ;

namespace DreamRecorder . ToolBox . Network . Dns . TSig
{

	// ReSharper disable once InconsistentNaming
	internal class TSigAlgorithmHelper
	{

		public static TSigAlgorithm GetAlgorithmByName ( DomainName name )
		{
			switch ( name . ToString ( ) . ToLower ( ) )
			{
				case "hmac-md5.sig-alg.reg.int" :
					return TSigAlgorithm . Md5 ;
				case "hmac-sha1" :
					return TSigAlgorithm . Sha1 ;
				case "hmac-sha256" :
					return TSigAlgorithm . Sha256 ;
				case "hmac-sha384" :
					return TSigAlgorithm . Sha384 ;
				case "hmac-sha512" :
					return TSigAlgorithm . Sha512 ;

				default :
					return TSigAlgorithm . Unknown ;
			}
		}

		public static DomainName GetDomainName ( TSigAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case TSigAlgorithm . Md5 :
					return DomainName . Parse ( "hmac-md5.sig-alg.reg.int" ) ;
				case TSigAlgorithm . Sha1 :
					return DomainName . Parse ( "hmac-sha1" ) ;
				case TSigAlgorithm . Sha256 :
					return DomainName . Parse ( "hmac-sha256" ) ;
				case TSigAlgorithm . Sha384 :
					return DomainName . Parse ( "hmac-sha384" ) ;
				case TSigAlgorithm . Sha512 :
					return DomainName . Parse ( "hmac-sha512" ) ;

				default :
					return null ;
			}
		}

		public static KeyedHashAlgorithm GetHashAlgorithm ( TSigAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case TSigAlgorithm . Md5 :
					return new HMACMD5 ( ) ;
				case TSigAlgorithm . Sha1 :
					return new HMACSHA1 ( ) ;
				case TSigAlgorithm . Sha256 :
					return new HMACSHA256 ( ) ;
				case TSigAlgorithm . Sha384 :
					return new HMACSHA384 ( ) ;
				case TSigAlgorithm . Sha512 :
					return new HMACSHA512 ( ) ;

				default :
					return null ;
			}
		}

		internal static int GetHashSize ( TSigAlgorithm algorithm )
		{
			switch ( algorithm )
			{
				case TSigAlgorithm . Md5 :
					return 16 ;
				case TSigAlgorithm . Sha1 :
					return 20 ;
				case TSigAlgorithm . Sha256 :
					return 32 ;
				case TSigAlgorithm . Sha384 :
					return 48 ;
				case TSigAlgorithm . Sha512 :
					return 64 ;

				default :
					return 0 ;
			}
		}

	}

}
