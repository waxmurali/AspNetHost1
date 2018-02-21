using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Models;
using Newtonsoft.Json;

namespace TestNancy.Models
{
    /*
	 "messages": [
	  {
		"speech": "Text response1",
		"type": 0
	  },
	  {
		"speech": "Text response2",
		"type": 0
	  }
	]
	 */

    //public class DialogflowResponseV1
    //{
    //       [JsonProperty(PropertyName = "id")]
    //       public string Id { get; set; }

    //       [JsonProperty(PropertyName = "lang")]
    //       public string Lang { get; set; }

    //       [JsonProperty(PropertyName = "messages")]
    //	public Message[] Messages { get; set; }
    //}


    [Serializable]
    public class DialogflowResponseV1
    {
        //[JsonProperty(PropertyName = "id")]
        //public string Id { get; set; }

        //[JsonProperty(PropertyName = "lang")]
        //public string Lang { get; set; }

        //[JsonProperty(PropertyName = "result")]
        //public Result Result { get; set; }

        //[JsonProperty(PropertyName = "sessionId")]
        //public string SessionId { get; set; }

        //[JsonProperty(PropertyName = "status")]
        //public Status Status { get; set; }

        //[JsonProperty(PropertyName = "timestamp")]
        //public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }

        [JsonProperty(PropertyName = "displayText")]
        public string DisplayText { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Data Data { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "contextOut")]
        public Context[] ContextOut { get; set; }
    }

    public class Data
    {
    }
}
