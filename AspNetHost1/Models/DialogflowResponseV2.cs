using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TestNancy.Models
{
	public class DialogflowResponseV2
	{
		/*
		 {
		  "fulfillmentText": string,
		  "fulfillmentMessages": [
			{
			  object(Message)
			}
		  ],
		  "source": string,
		  "payload": {
			object
		  },
		  "outputContexts": [
			{
			  object(Context)
			}
		  ],
		  "followupEventInput": {
			object(EventInput)
		  },
		}
		 */

		[JsonProperty(PropertyName = "fulfillmentText")]
		public string FulfillmentText { get; set; }

		[JsonProperty(PropertyName = "fulfillmentMessages")]
		public object[] FulfillmentMessages { get; set; }

		[JsonProperty(PropertyName = "source")]
		public string Source { get; set; }

		[JsonProperty(PropertyName = "payload")]
		public object Payload { get; set; }

		[JsonProperty(PropertyName = "outputContexts")]
		public object[] OutputContexts { get; set; }

		[JsonProperty(PropertyName = "followupEventInput")]
		public object FollowupEventInput { get; set; }

	}
}
