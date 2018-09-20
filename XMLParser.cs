using System.Collections.Generic;
using System.Xml;
using Windows.Storage;
using System;
using System.Threading.Tasks;

namespace LHVFinanceReport
{
	class XMLParser
	{
		public async Task<List<T>> ParseFile<T>(StorageFile file) where T : LHVReportModel, new() //add interface for generic
		{
			var xmlDoc = new XmlDocument();
			var xmlContent = await FileIO.ReadTextAsync(file);
			xmlDoc.LoadXml(xmlContent);
			var resultList = new List<T>();
			var nodes = xmlDoc.DocumentElement.GetElementsByTagName("Ntry");

			for (var i = 0; i < nodes.Count; i++)
			{
				var node = nodes[i];				
				var newModel = new T
				{
					Amount = decimal.Parse(node.ChildNodes[0].InnerText),
					Currency = node.ChildNodes[0].Attributes[0].InnerText,
					Side = node.ChildNodes[1].InnerText == "CRDT" ? PaymentSide.Credit : PaymentSide.Debit,
					BookDate = DateTime.Parse(node.ChildNodes[3].InnerText),					 
					CounterpartyInfo = node.ChildNodes[6].ChildNodes[0].ChildNodes[2].InnerText

				};
				resultList.Add(newModel);		
			}

			return resultList;
		}
	}
}
