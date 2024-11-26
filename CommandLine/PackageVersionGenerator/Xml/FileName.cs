using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DreamRecorder.ToolBox.CommandLine.PackageVersionGenerator.Xml
{
	// NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
	/// <remarks/>
	[SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	[System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
	public class Project
	{

		private ProjectPropertyGroup propertyGroupField;

		private ProjectPackageVersion[] itemGroupField;

		/// <remarks/>
		public ProjectPropertyGroup PropertyGroup
		{
			get => propertyGroupField;
			set => propertyGroupField = value;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlArrayItemAttribute("PackageVersion", IsNullable = false)]
		public ProjectPackageVersion[] ItemGroup
		{
			get => itemGroupField;
			set => itemGroupField = value;
		}
	}

	/// <remarks/>
	[SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class ProjectPropertyGroup
	{

		private bool managePackageVersionsCentrallyField;

		private bool centralPackageTransitivePinningEnabledField;

		/// <remarks/>
		public bool ManagePackageVersionsCentrally
		{
			get => managePackageVersionsCentrallyField;
			set => managePackageVersionsCentrallyField = value;
		}

		/// <remarks/>
		public bool CentralPackageTransitivePinningEnabled
		{
			get => centralPackageTransitivePinningEnabledField;
			set => centralPackageTransitivePinningEnabledField = value;
		}
	}

	/// <remarks/>
	[SerializableAttribute()]
	[System.ComponentModel.DesignerCategoryAttribute("code")]
	[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
	public class ProjectPackageVersion
	{

		private string includeField;

		private string versionField;

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Include
		{
			get => includeField;
			set => includeField = value;
		}

		/// <remarks/>
		[System.Xml.Serialization.XmlAttributeAttribute()]
		public string Version
		{
			get => versionField;
			set => versionField = value;
		}
	}

}
