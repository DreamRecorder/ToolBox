using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

using DreamRecorder.ToolBox.Network.Dns;

namespace DreamRecorder.ToolBox.UnitTest.Dns;

[TestClass]
public class DomainNameTests
{

	[TestMethod]
	public void CompareToTest ( ) { }

	[TestMethod]
	public void DomainNameTest ( )
	{
		DomainName domainName    = new DomainName ( new [ ] { "dreamry" , "org" , } );
		DomainName subDomainName = new DomainName ( "toolbox.dev" , domainName );
	}

	[TestMethod]
	public void EqualsTest ( )
	{
		DomainName domainName1   = DomainName.Parse ( "dreamry.org" );
		DomainName domainName2   = DomainName.Parse ( "Dreamry.org" );
		DomainName subDomainName = DomainName.Parse ( "toolbox.dev.dreamry.org" );

		Assert.IsTrue ( domainName1.Equals ( domainName1 ) );
		Assert.IsTrue ( domainName1.Equals ( domainName2 ) );
		Assert.IsTrue ( domainName1.Equals ( domainName2 ) );
		Assert.IsFalse ( domainName1.Equals ( subDomainName ) );
		Assert.IsFalse ( domainName2.Equals ( subDomainName ) );
	}

	[TestMethod]
	public void EqualsTest1 ( ) { }

	[TestMethod]
	public void EqualsTest2 ( ) { }

	[TestMethod]
	public void GetHashCodeTest ( ) { }

	[TestMethod]
	public void GetParentNameTest ( ) { }

	[TestMethod]
	public void IsEqualOrSubDomainOfTest ( )
	{
		DomainName domainName    = DomainName.Parse ( "dreamry.org" );
		DomainName subDomainName = DomainName.Parse ( "toolbox.dev.dreamry.org" );

		Assert.IsTrue ( subDomainName.IsEqualOrSubDomainOf ( domainName ) );
		Assert.IsTrue ( subDomainName.IsEqualOrSubDomainOf ( subDomainName ) );
		Assert.IsFalse ( domainName.IsEqualOrSubDomainOf ( subDomainName ) );
	}

	[TestMethod]
	public void IsSubDomainOfTest ( ) { }

	[TestMethod]
	public void JsonTest ( )
	{
		DomainName domainName = DomainName.Parse ( "dreamry.org" );

		string     jsonString = JsonSerializer.Serialize ( domainName );
		DomainName result     = JsonSerializer.Deserialize <DomainName> ( jsonString );
		Assert.AreEqual ( domainName , result );
	}

	[TestMethod]
	public void ToStringTest ( )
	{
		DomainName domainName = DomainName.Parse ( "dreamry.org" );
		Assert.AreEqual ( "dreamry.org." , domainName.ToString ( ) );
	}

}
