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
	    private readonly IProcessRequest _processRequest;

		// Change to match the required Dialogflow API version
		public const int Version = 1;

		public DialogflowModule(IMessageGenerator messageGenerator,ILogWriter logWriter,IProcessRequest processRequest)
		{
			_messageGenerator = messageGenerator;
		    _logWriter = logWriter;
		    _processRequest = processRequest;

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
                var request = this.Bind<QueryRequestJsonModel>();
                var response = _processRequest.ProcessRequestForQuery(request, _logWriter);
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
