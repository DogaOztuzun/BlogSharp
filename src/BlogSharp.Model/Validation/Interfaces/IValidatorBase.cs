namespace BlogSharp.Model.Validation.Interfaces
{
	using FluentValidation;

	/// <summary>
	/// Base validator.
	/// </summary>
	public interface IValidatorBase : IValidator
	{
		/// <summary>
		/// Validates and trows an exception.
		/// </summary>
		/// <param name="instance">The instance to Validate.</param>
		void ValidateAndThrowException(object instance);
	}

	/// <summary>
	/// A Generic Base Validator.
	/// </summary>
	/// <typeparam name="T">The Type of the instance to validate.</typeparam>
	public interface IValidatorBase<T> : IValidator<T>
	{
		/// <summary>
		/// Validates and trows an exception.
		/// </summary>
		/// <param name="instance">The instance to Validate.</param>
		void ValidateAndThrowException(T instance);
	}
}