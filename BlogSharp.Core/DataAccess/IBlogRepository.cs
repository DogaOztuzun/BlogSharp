﻿using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IBlogRepository
    {
        /// <summary>
        /// Get the Blog of the Founder Author
        /// </summary>
        /// <param name="authorId"></param>
        /// <returns></returns>
        IBlog GeyByFounder(int authorId);

		/// <summary>
		/// Gets all blog
		/// </summary>
		/// <returns></returns>
    	IQueryable<IBlog> GetAllBlogs();

		/// <summary>
		/// Saves the blog
		/// </summary>
		/// <param name="blog"></param>
    	void SaveBlog(IBlog blog);

		/// <summary>
		/// Removes the blog
		/// </summary>
		/// <param name="blog"></param>
    	void DeleteBlog(IBlog blog);
    }
}
