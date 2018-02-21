using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AspNetHost1.Models;
using AspNetHost1.Processing;
using Nancy;
using Nancy.ModelBinding;
using Nancy.Responses;
using TestNancy.Models;
using TestNancy.Processing;

namespace TestNancy.Modules
{
	public class DialogflowModule : NancyModule
	{
		private readonly IMessageGenerator _messageGenerator;
	    private readonly ILogWriter _logWriter;

		// Change to match the required Dialogflow API version
		public const int Version = 1;

		public DialogflowModule(IMessageGenerator messageGenerator,ILogWriter logWriter)
		{
			_messageGenerator = messageGenerator;
		    _logWriter = logWriter;

            _logWriter.LogMessage("Initialised Dialogflow");
            // Authentication Check
            Before += ctx => {
				return (this.Context.CurrentUser == null) ? new HtmlResponse(HttpStatusCode.Unauthorized) : null;
			};

			// Routes
			Post["/dialogflow", true] = async (requestObject, cancellationToken) =>
			{
				switch (Version)
				{
					case 1:
						return HandleV1Request();

					case 2:
						return HandleV2Request();

					default:
						throw new Exception($"Unrecognised Version - {Version}");
				}
			};

		    Get["/GoogleHome"] = parameters => ("Hello to Google Home");
		}

		private dynamic HandleV1Request()
		{
            try
            {
                var dialogflowRequest = this.Bind<QueryRequestJsonModel>();
                //var dialogflowRequest = this.Bind<Models.DialogflowRequestV1>();
                _logWriter.LogMessage("Handle Request");


                var response = new DialogflowResponseV1
                {
                    Speech = "Hi Hello World Webhook Service",
                    DisplayText = "Hi Hello World Webhook Service",
                    Source = "Webhook Service",
                    Data = new Data(),
                    ContextOut = new Context[0]
                    //Messages = new[]
                    //{
                    //	new Message("Test Message 1", 0),
                    //	new Message("Test Message 2", 0),
                    //	_messageGenerator.Generate(null) // random message serving no point apart from testing our Dependency Injection registrations in the Bootstrapper
                    //}
                };

                //var response = new QueryResponseJsonModel()
                //{
                //    SessionId = dialogflowRequest.SessionId,
                //    Lang = dialogflowRequest.Lang,
                //    Result = new QueryResponseResultJsonModel()
                //    {
                //        Fulfillment = new FulfillmentJsonModel()
                //        {
                //            Speech = "Hi Hello World Webhook Service",
                //            Messages = new List<FulfillmentMessageJsonModel>()
                //            {
                //                new FulfillmentMessageJsonModel() {Speech = "Hi From Full",Text = "Hi From Text",Type = 0,Replies = new List<string>() {"testinggggggg123"},Title = "Google Home Test",Subtitle = "Chumma"}
                //            }
                //        },
                //        Speech = "Hi Hello World Webhook Service",
                //        Source = "Webhook Service",
                //    }
                //};


                return Response.AsJson(response,HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error in processing request -- {ex.Message}",ex.InnerException);
            }
        }

		private dynamic HandleV2Request()
		{
			var dialogflowRequest = this.Bind<Models.DialogflowRequestV2>();
			return new DialogflowResponseV2
			{
				Source = "source"
			};
		}
	}
}
