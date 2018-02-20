using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Models;
using Newtonsoft.Json;

namespace TestNancy.Models
{
	public class DialogflowRequestV1
	{
        /*
		 POST https://my-service.com/action

		Headers:
		//user defined headers
		Content-type: application/json

		POST body:

		{
			"contexts": [
							string
			],
			"lang": string,
			"query": string,
			"sessionId": string,
			"timezone": string
		}
		 */

        //[JsonProperty(PropertyName = "contexts")]
        //public string[] Contexts { get; set; }

        //[JsonProperty(PropertyName = "lang")]
        //public string Lang { get; set; }

        //[JsonProperty(PropertyName = "query")]
        //public string Query { get; set; }

        //[JsonProperty(PropertyName = "sessionId")]
        //public string SessionId { get; set; }

        //[JsonProperty(PropertyName = "timezone")]
        //public string Timezone { get; set; }

        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        [JsonProperty(PropertyName = "result")]
        public Result Result { get; set; }

        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "status")]
        public Status Status { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }
    }
}
