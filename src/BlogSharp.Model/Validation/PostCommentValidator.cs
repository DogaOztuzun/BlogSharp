namespace BlogSharp.Model.Validation
{
	using FluentValidation;
	using Rules;

	/// <summary>
	/// A validator for the <see cref="PostComment"/> Class.
	/// </summary>
	public class PostCommentValidator : ValidatorBase<PostComment>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="PostCommentValidator" /> class. 
		/// </summary>
		public PostCommentValidator()
		{
			RuleFor(x => x.Comment).NotEmpty();

			RuleFor(x => x.Commenter).NotNull().When(
				x => string.IsNullOrEmpty(x.Email) && string.IsNullOrEmpty(x.Name) && string.IsNullOrEmpty(x.Web));

			RuleFor(x => x.Name).NotEmpty().When(x => x.Commenter == null);
			RuleFor(x => x.Email).NotEmpty().And.EmailAddress().When(x => x.Commenter == null);
			RuleFor(x => x.Web).Url().When(x => !string.IsNullOrEmpty(x.Web) && x.Commenter == null);
		}
	}
}