using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;
using System.IO;

//保存和载入XML文件
public class  XMLReadAndLoad {

	public static void Save<T>(string filePath,T cls)
	{
		using(TextWriter writer = new StreamWriter(filePath))
		{
			XmlSerializer serializer =new XmlSerializer(typeof(T));
			serializer.Serialize(writer,cls);
		}
	}
	public static T Load<T>(string filePath)
	{
		using(var reader = new FileStream(filePath,FileMode.Open))
		{
			XmlSerializer XML = new XmlSerializer(typeof(T));
			return (T)XML.Deserialize(reader);
		}
	}
}