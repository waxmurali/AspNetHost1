using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace AspNetHost1.Models
{
    public class QueryRequestJsonModel
    {
        [JsonProperty(PropertyName = "query")]
        public string Query { get; set; }

        [JsonProperty(PropertyName = "event")]
        public EventJsonModel Event { get; set; }

        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }

        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        [JsonProperty(PropertyName = "contexts")]
        public ContextJsonModel Contexts { get; set; }

        [JsonProperty(PropertyName = "resetContexts")]
        public bool ResetContexts { get; set; }

        [JsonProperty(PropertyName = "entities")]
        public EntityJsonModel Entities { get; set; }

        [JsonProperty(PropertyName = "timezone")]
        public string Timezone { get; set; }

        [JsonProperty(PropertyName = "location")]
        public LocationJsonModel Location { get; set; }

        [JsonProperty(PropertyName = "originalRequest")]
        public OriginalRequestJsonModel OriginalRequest { get; set; }

        [JsonProperty(PropertyName = "result")]
        public QueryResponseResultJsonModel Result { get; set; }
    }

    public class ContextJsonModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        public Dictionary<string, string> Parameters { get; set; }

        [JsonProperty(PropertyName = "lifespan")]
        public long Lifespan { get; set; }
    }

    public class EventJsonModel
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "data")]
        public Dictionary<string, string> Data { get; set; }
    }

    public class EntityJsonModel
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }

        [JsonProperty(PropertyName = "preview")]
        public string Preview { get; set; }
    }

    public class LocationJsonModel
    {
        [JsonProperty(PropertyName = "latitude")]
        public double Latitude { get; set; }

        [JsonProperty(PropertyName = "longitude")]
        public double Longitude { get; set; }
    }

    public class OriginalRequestJsonModel
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "data")]
        public string Data { get; set; }
    }

    // --------------------- Response Model-----------------------

    public class QueryResponseJsonModel 
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "timestamp")]
        public string Timestamp { get; set; }

        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        [JsonProperty(PropertyName = "result")]
        public QueryResponseResultJsonModel Result { get; set; }

        [JsonProperty(PropertyName = "status")]
        public StatusJsonModel Status { get; set; }

        [JsonProperty(PropertyName = "sessionId")]
        public string SessionId { get; set; }
    }

    public class StatusJsonModel
    {
        [JsonProperty(PropertyName = "code")]
        public int Code { get; set; }

        [JsonProperty(PropertyName = "errorType")]
        public string ErrorType { get; set; }

        [JsonProperty(PropertyName = "errorId")]
        public string ErrorId { get; set; }

        [JsonProperty(PropertyName = "errorDetails")]
        public string ErrorDetails { get; set; }
    }

    public class QueryResponseResultJsonModel
    {
        [JsonProperty(PropertyName = "source")]
        public string Source { get; set; }

        [JsonProperty(PropertyName = "resolvedQuery")]
        public string ResolvedQuery { get; set; }

        [JsonProperty(PropertyName = "action")]
        public string Action { get; set; }

        [JsonProperty(PropertyName = "actionIncomplete")]
        public bool ActionIncomplete { get; set; }

        [JsonProperty(PropertyName = "parameters")]
        //public Dictionary<string, string> Parameters { get; set; }
        public Parameters Parameters { get; set; }

        [JsonProperty(PropertyName = "contexts")]
        public List<ContextJsonModel> Contexts { get; set; }

        [JsonProperty(PropertyName = "fulfillment")]
        public FulfillmentJsonModel Fulfillment { get; set; }

        [JsonProperty(PropertyName = "score")]
        public float Score { get; set; }

        [JsonProperty(PropertyName = "metadata")]
        public MetadataJsonModel Metadata { get; set; }

        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }
    }

    public class FulfillmentJsonModel
    {
        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }

        [JsonProperty(PropertyName = "messages")]
        public List<FulfillmentMessageJsonModel> Messages { get; set; }
    }

    public class FulfillmentMessageJsonModel
    {

        [JsonProperty(PropertyName = "type")]
        public byte Type { get; set; }

        [JsonProperty(PropertyName = "speech")]
        public string Speech { get; set; }

        [JsonProperty(PropertyName = "imageUrl")]
        public string ImageUrl { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "subtitle")]
        public string Subtitle { get; set; }

        [JsonProperty(PropertyName = "buttons")]
        public List<object> Buttons { get; set; }

        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }

        [JsonProperty(PropertyName = "postback")]
        public string Postback { get; set; }

        [JsonProperty(PropertyName = "replies")]
        public List<string> Replies { get; set; }

        [JsonProperty(PropertyName = "payload")]
        public string Payload { get; set; }
    }

    public class MetadataJsonModel
    {
        [JsonProperty(PropertyName = "intentId")]
        public string IntentId { get; set; }

        [JsonProperty(PropertyName = "webhookUsed")]
        public string WebhookUsed { get; set; }

        [JsonProperty(PropertyName = "webhookForSlotFillingUsed")]
        public string WebhookForSlotFillingUsed { get; set; }

        [JsonProperty(PropertyName = "webhookResponseTime")]
        public double WebhookResponseTime { get; set; }

        [JsonProperty(PropertyName = "intentName")]
        public string IntentName { get; set; }
    }
}