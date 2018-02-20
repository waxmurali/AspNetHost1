using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestNancy.Models
{
	public class DialogflowRequestV2
	{

		/*
		 Headers:
		//user defined headers
		Content-type: application/json

		POST body:
		{
		  "session": string,
		  "responseId": string,
		  "queryResult": {
			object(QueryResult)
		  },
		  "originalDetectIntentRequest": {
			object(OriginalDetectIntentRequest)
		  },
		}
		 */

		[JsonProperty(PropertyName = "session")]
		public string Session { get; set; }

		[JsonProperty(PropertyName = "responseId")]
		public string ResponseId { get; set; }

		[JsonProperty(PropertyName = "queryResult")]
		public object QueryResult { get; set; }

		[JsonProperty(PropertyName = "originalDetectIntentRequest")]
		public object OriginalDetectIntentRequest { get; set; }
	}
}
