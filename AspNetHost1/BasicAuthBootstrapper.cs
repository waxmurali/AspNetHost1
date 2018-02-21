using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetHost1.Processing;
using AspNetHost1.Processing.Implementation;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using Nancy;
using Nancy.Authentication.Basic;
using Nancy.Bootstrapper;
using Nancy.Bootstrappers.Windsor;
using Nancy.TinyIoc;
using TestNancy.Authentication.Basic;
using TestNancy.Processing;
using TestNancy.Processing.Implementation;

namespace TestNancy
{
	public class BasicAuthBootstrapper : WindsorNancyBootstrapper
	{
		protected override void ApplicationStartup(IWindsorContainer container, IPipelines pipelines)
		{
			// No registrations should be performed in here, however you may
			// resolve things that are needed during application startup.

			base.ApplicationStartup(container, pipelines);

			container.Register(Component
				.For<IUserValidator>()
				.ImplementedBy<UserValidator>());

			pipelines.EnableBasicAuthentication(new BasicAuthenticationConfiguration(
				container.Resolve<IUserValidator>(),
				"MyRealm"));
		}
		protected override void ConfigureApplicationContainer(IWindsorContainer existingContainer)
		{
			base.ConfigureApplicationContainer(existingContainer);

			// Perform registrations here

			existingContainer.Register(
				Component
				.For<IMessageGenerator>()
				.ImplementedBy<RandomMessageGenerator>());

		    existingContainer.Register(Component
		        .For<ILogWriter>()
		        .ImplementedBy<EmailWriter>());
		}

		protected override void RequestStartup(IWindsorContainer container, IPipelines pipelines, NancyContext context)
		{
			base.RequestStartup(container, pipelines, context);

			// No registrations should be performed in here, however you may
			// resolve things that are needed during request startup.
		}
	}
}
