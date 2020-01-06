using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;

using JetBrains.Annotations;

namespace DreamRecorder.ToolBox.General
{

	[PublicAPI]
	public static class SelfSerializableExtensions
	{

		public static string ToXmlString([NotNull] this ISelfSerializable item)
		{
			if (item == null)
			{
				throw new ArgumentNullException(nameof(item));
			}

			return item.ToXElement().ToString();
		}

		public static T ReadNecessaryValue<T>(this XElement element, string name)
		{
			if (element == null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			string value = element.Attribute(name)?.Value;

			if (value == null)
			{
				throw new ArgumentException(ExceptionMessages.NecessaryValueNotFound(element, name));
			}

			return value.ParseTo<T>();
		}

		public static T ReadUnnecessaryValue<T>(this XElement element, string name, T defaultValue)
		{
			if (element == null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			string value = element.Attribute(name)?.Value;

			if (value == null)
			{
				return defaultValue;
			}

			return value.ParseTo<T>();
		}

		public static XElement Serialize<T>([NotNull] this T obj)
		{
			if (obj == null)
			{
				throw new ArgumentNullException(nameof(obj));
			}

			if (typeof(ISelfSerializable).IsAssignableFrom(typeof(T)))
			{
				return ((ISelfSerializable)obj).ToXElement();
			}
			else
			{
				using MemoryStream memoryStream = new MemoryStream();
				using StreamWriter streamWriter = new StreamWriter(memoryStream);

				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				xmlSerializer.Serialize(streamWriter, obj);

				return XElement.Parse(Encoding.UTF8.GetString(memoryStream.ToArray()));
			}
		}

		public static T Deserialize<T>([NotNull] this XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException(nameof(element));
			}

			if (typeof(ISelfSerializable).IsAssignableFrom(typeof(T)))
			{
				return (T)Activator.CreateInstance(typeof(T), element);
			}
			else
			{
				XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
				return (T)xmlSerializer.Deserialize(element.CreateReader());
			}
		}

	}

}
