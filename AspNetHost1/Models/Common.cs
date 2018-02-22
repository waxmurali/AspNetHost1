using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using TestNancy.Models;

namespace AspNetHost1.Models
{
    public class Common
    {
    }

    public class Result
    {
        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty(PropertyName = "contexts")]
        public Context[] Contexts { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public Metadata Metadata { get; set; }

        [JsonProperty(PropertyName = "fulfillment")]
        public Fulfillment Fulfillment { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Parameters Parameters { get; set; }

        [JsonProperty(PropertyName = "resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty(PropertyName = "score")]
        public string Score { get; set; }

        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }
    }

    public class Context
    {
        public int Lifespan { get; set; }
        public string Name { get; set; }
        public Parameters Parameters { get; set; }
    }
   

    public class Fulfillment
    {
        [JsonProperty(PropertyName = "messages")]
        public Message[] Messages { get; set; }

        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }
    }

    public class Message
    {
        public Message(string speech, int type)
        {
            Speech = speech;
            Type = type;
        }


        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }

        [JsonProperty(PropertyName = "type")]
        public int Type { get; set; }
    }

    public class Metadata
    {
        [JsonProperty(PropertyName = "intentId")]
        public string IntentId { get; set; }
        [JsonProperty(PropertyName = "intentName")]
        public string IntentName { get; set; }
        [JsonProperty(PropertyName = "webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }
        [JsonProperty(PropertyName = "webhookResponseTime")]
        public int WebhookResponseTime { get; set; }
        [JsonProperty(PropertyName = "webhookUsed")]
        public string WebhookUsed { get; set; }
    }

    public class Parameters
    {
        [JsonProperty(PropertyName = "welcomtext1")]
        public string Welcomtext1 { get; set; }
    }

    public class Status
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "errorType")]
        public string ErrorType { get; set; }

        [JsonProperty(PropertyName = "errorId")]
        public string ErrorId { get; set; }

        [JsonProperty(PropertyName = "errorDetails")]
        public string ErrorDetails { get; set; }

        [JsonProperty(PropertyName = "webhookTimedOut")]
        public bool WebhookTimedOut { get; set; }
    }
}