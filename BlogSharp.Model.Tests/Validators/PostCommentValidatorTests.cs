﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogSharp.Model.Validation;
using FluentValidation.TestHelper;
using NUnit.Framework;

namespace BlogSharp.Model.Tests.Validators
{
	[TestFixture]
	public class PostCommentValidatorTests:ValidationTestBase<PostCommentValidator,PostComment>
	{
		[Test]
		public void Should_raise_error_when_comment_is_not_specified()
		{
			ShouldHaveErrors(x => x.Comment, null);
			ShouldHaveErrors(x => x.Comment, null);
		}

		[Test]
		public void Should_raise_error_when_email_is_empty()
		{
			ShouldHaveErrors(x => x.Email, null);
			ShouldHaveErrors(x => x.Email, "");
		}

		[Test]
		public void Should_raise_error_when_email_is_in_invalid_format()
		{
			ShouldHaveErrors(x => x.Email, "aaaa");
			ShouldHaveErrors(x => x.Email, "aaa@aaa");
			ShouldHaveErrors(x => x.Email, "aaa@aaa.");
			ShouldNotHaveErrors(x => x.Email, "aaa@aaa.com");
		}


		[Test]
		public void Should_raise_error_when_web_is_in_invalid_format()
		{
			ShouldHaveErrors(x => x.Web, "aaaa");
			ShouldHaveErrors(x => x.Web, "http://aaa");
			ShouldNotHaveErrors(x => x.Web, "http://tunatoksoz.com");
		}

		[Test]
		public void Should_raise_no_error_when_web_is_in_invalid_format()
		{
			ShouldNotHaveErrors(x => x.Web, "");
		}
	}
}