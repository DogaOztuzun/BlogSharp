﻿using BlogSharp.CastleExtensions.DependencyResolvers;
using Castle.MicroKernel.Handlers;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using NUnit.Framework;


namespace BlogSharp.CastleExtensions.Tests.DependencyResolvers
{
	public class SampleService1
	{
		public SampleService1(string serviceId)
		{
			ServiceId = serviceId;
		}

		public string ServiceId { get; set; }
	}

	public class SampleService2
	{
		public SampleService2(string serviceId)
		{
			ServiceId = serviceId;
		}

		public string ServiceId { get; set; }
	}

	public class SampleService3
	{
		public SampleService3(int serviceId)
		{
			ServiceId = serviceId;
		}

		public int ServiceId { get; set; }
	}
	[TestFixture]
	public class ServiceIdResolverTests
	{
		private IWindsorContainer container;

		[SetUp]
		public void SetUp()
		{
			container = new WindsorContainer();
			container.Kernel.Resolver.AddSubResolver(new ServiceIdResolver());
			container.Register(Component.For<SampleService1>().Named("service1"))
				.Register(Component.For<SampleService2>().Named("service2"))
				.Register(Component.For<SampleService3>().Named("service3"));
		}

		[Test]
		public void CanResolveDependencyWithServiceId()
		{
			var s1 = container.Resolve<SampleService1>();
			var s2 = container.Resolve<SampleService2>();
			Assert.That("service1", Is.EqualTo(s1.ServiceId));
			Assert.That("service2", Is.EqualTo(s2.ServiceId));
			Assert.Throws<HandlerException>(() => container.Resolve<SampleService3>());
		}
	}
}