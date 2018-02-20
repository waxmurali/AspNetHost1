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

            //_logWriter.LogMessage("Initialised Dialogflow");
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

			var dialogflowRequest = this.Bind<Models.DialogflowRequestV1>();
            //_logWriter.LogMessage("Handle Request");
            return new DialogflowResponseV1
			{
                Speech = "Hi Hello World Webhook Service",
                DisplayText = "Hi Hello World Webhook Service",
                Source = "Webhook Service",
                Data = new Data(),
                //Messages = new[]
                //{
                //	new Message("Test Message 1", 0),
                //	new Message("Test Message 2", 0),
                //	_messageGenerator.Generate(null) // random message serving no point apart from testing our Dependency Injection registrations in the Bootstrapper
                //}
            };
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
