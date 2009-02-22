namespace BlogSharp.Core.Event.MembershipEvents
{
	using Model;
	using Services.Membership;

	public class PasswordResettedEventArgs : AbstractEventArgs<IMembershipService>
	{
		public PasswordResettedEventArgs(IMembershipService service, User user, string newPassword)
			: base(service)
		{
			this.User = user;
			this.NewPassword = newPassword;
		}

		public User User { get; private set; }
		public string NewPassword { get; private set; }
	}
}