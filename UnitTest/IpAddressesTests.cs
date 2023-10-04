using System ;
using System . Collections ;
using System . Collections . Generic ;
using System . Linq ;
using System . Net ;

using DreamRecorder . ToolBox . General ;
using DreamRecorder . ToolBox . Network . Ip ;

using Microsoft . VisualStudio . TestTools . UnitTesting ;

namespace DreamRecorder . ToolBox . UnitTest ;

[TestClass]
public class IpAddressesTests
{

	public static (string Perferred , string NoOmitHextets , string Compressed) [ ] Ipv6ToStringTestData =
	{
		( "0000:0000:0000:0000:0000:0000:0000:0000" , "0:0:0:0:0:0:0:0" , "::" ) ,
		( "0000:0000:0000:0000:0000:0000:0000:0001" , "0:0:0:0:0:0:0:1" , "::1" ) ,
		( "ff02:0000:0000:0000:0000:0000:0000:0001" , "ff02:0:0:0:0:0:0:1" , "ff02::1" ) ,
		( "fe80:0000:0000:0000:a299:9bff:fe18:50d1" , "fe80:0:0:0:a299:9bff:fe18:50d1" ,
			"fe80::a299:9bff:fe18:50d1" ) ,
		( "2001:0db8:1111:000a:00b0:0000:9000:0200" , "2001:db8:1111:a:b0:0:9000:200" ,
			"2001:db8:1111:a:b0::9000:200" ) ,
		( "2001:0db8:1111:000a:00b0:0000:0000:0200" , "2001:db8:1111:a:b0:0:0:200" , "2001:db8:1111:a:b0::200" ) ,
		( "2001:0db8:0000:0000:abcd:0000:0000:1234" , "2001:db8:0:0:abcd:0:0:1234" , "2001:db8::abcd:0:0:1234" ) ,
		( "2001:0db8:aaaa:0001:0000:0000:0000:0100" , "2001:db8:aaaa:1:0:0:0:100" , "2001:db8:aaaa:1::100" ) ,
		( "2001:0db8:aaaa:0001:0000:0000:0000:0200" , "2001:db8:aaaa:1:0:0:0:200" , "2001:db8:aaaa:1::200" ) ,
	} ;

	[TestMethod]
	public void ApplyPrefixTest ( )
	{
		Ipv4Prefix  masqueradedSourcePrefix = new Ipv4Prefix ( "117.181.74.0/23" ) ;
		Ipv4Address targetAddress           = new Ipv4Address ( "103.152.35.157" ) ;

		bool [ ] buffer = new bool[ 32 ] ;

		bool [ ] prefixArray  = masqueradedSourcePrefix . AddressBytes . Span . ToBooleanArray ( ) ;
		bool [ ] addressArray = targetAddress . AddressBytes . Span . ToBooleanArray ( ) ;


		Array . Copy ( prefixArray , buffer , masqueradedSourcePrefix . Length ) ;

		Array . Copy (
					  addressArray ,
					  masqueradedSourcePrefix . Length ,
					  buffer ,
					  masqueradedSourcePrefix . Length ,
					  32 - masqueradedSourcePrefix . Length ) ;

		Ipv4Address resultAddress = new Ipv4Address ( ) ;

		buffer . ToByteArray ( ) . CopyTo ( resultAddress . AddressBytes ) ;

		string a = resultAddress . ToString ( ) ;

		Assert . AreEqual ( a , "117.181.75.157" ) ;
	}

	[TestMethod]
	public void Ipv6ToCompressedStringTest ( )
	{
		foreach ( (string Perferred , string NoOmitHextets , string Compressed) data in Ipv6ToStringTestData )
		{
			Assert . AreEqual ( data . Compressed , new Ipv6Address ( data . Perferred ) . ToString ( ) , true ) ;
		}
	}

	[TestMethod]
	public void Ipv6ToNoOmitHextetsStringTest ( )
	{
		foreach ( (string Perferred , string NoOmitHextets , string Compressed) data in Ipv6ToStringTestData )
		{
			Assert . AreEqual (
							   data . NoOmitHextets ,
							   new Ipv6Address ( data . Perferred ) . ToString (
																				Ipv6Address . AddressStyle .
																					NoOmitHextets ) ,
							   true ) ;
		}
	}

	[TestMethod]
	public void SystemIpAddressToIpv4Address ( )
	{
		string    source  = "127.0.0.1" ;
		IpAddress address = ( IpAddress )IPAddress . Parse ( source ) ;
		string    result  = address . ToString ( ) ;
		Assert . AreEqual ( result , source ) ;
	}

	[TestMethod]
	public void SystemIpAddressToIpv6Address ( )
	{
		foreach ( (string Perferred , string NoOmitHextets , string Compressed) data in Ipv6ToStringTestData )
		{
			IpAddress address = ( IpAddress )IPAddress . Parse ( data . Compressed ) ;
			string    result  = address . ToString ( ) ;
			Assert . AreEqual ( result , data . Compressed , true ) ;
		}
	}

}
