namespace BlogSharp.Core.Impl.Tests.EventHandlers.Membership
{
	using System.Net.Mail;
	using Core.Services.Mail;
	using Core.Services.Membership;
	using Core.Services.Template;
	using Event.MembershipEvents;
	using Impl.EventHandlers.Membership;
	using Model;
	using NUnit.Framework;
	using Rhino.Mocks;

	[TestFixture]
	public class UserRegisteredEventListenerTests
	{
		#region Setup/Teardown

		[SetUp]
		public void SetUp()
		{
			this.mailServiceMock = MockRepository.GenerateMock<IMailService>();
			this.templateEngineMock = MockRepository.GenerateMock<ITemplateEngine>();
			this.templateSourceMock = MockRepository.GenerateMock<ITemplateSource>();
			this.listener = new SendWelcomeEmailUserRegisteredEventListener(this.mailServiceMock, this.templateEngineMock,
			                                                                this.templateSourceMock);
		}

		#endregion

		private SendWelcomeEmailUserRegisteredEventListener listener;
		private IMailService mailServiceMock;
		private ITemplateEngine templateEngineMock;
		private ITemplateSource templateSourceMock;

		[Test]
		public void Calls_templateEngine_and_templateSource_then_sends_email()
		{
			var author = new User {Email = "blah@blah.com"};
			var membershipServiceMock = MockRepository.GenerateMock<IMembershipService>();
			this.listener.Handle(new UserRegisteredEventArgs(membershipServiceMock, author));
			this.templateSourceMock.AssertWasCalled(x => x.GetTemplateWithKey("membership_welcome"));
			this.mailServiceMock.AssertWasCalled(x => x.Send(
			                                          	Arg<MailAddress>.Matches(y => y.Address == "blah@blah.com"),
			                                          	Arg<MailAddress>.Is.Anything,
			                                          	Arg<MailAddress>.Is.Anything,
			                                          	Arg<string>.Is.Anything,
			                                          	Arg<string>.Is.Anything
			                                          	));
		}
	}
}