using System.Collections.Generic;
using System.Xml;
using Windows.Storage;
using System;
using System.Threading.Tasks;

namespace LHVFinanceReport
{
	class XMLParser
	{
		public async Task<List<T>> ParseFile<T>(StorageFile file) where T : LHVReportModel, new()
		{
			var xmlDoc = new XmlDocument();
			var xmlContent = await FileIO.ReadTextAsync(file);
			xmlDoc.LoadXml(xmlContent);
			var resultList = new List<T>();
			var nodes = xmlDoc.DocumentElement.GetElementsByTagName("Ntry");

			for (var i = 0; i < nodes.Count; i++)
			{
				var node = nodes[i];

				//for (var j = 0; j < node.ChildNodes.Count; j++)
				//{
					var newModel = new T
					{
						Amount = decimal.Parse(node.ChildNodes[0].InnerText)
					};
					resultList.Add(newModel);
				//}
			}

			return resultList;
		}
	}
}
