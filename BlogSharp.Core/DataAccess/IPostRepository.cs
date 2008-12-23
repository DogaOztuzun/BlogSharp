﻿using System;
using System.Linq;
using BlogSharp.Model;

namespace BlogSharp.Core.DataAccess
{
    public interface IPostRepository : IRepository<IPost>
    {
        /// <summary>
        /// Get the post via SEO friendly title in url-rewrite.
        /// </summary>
        /// <param name="friendlyTitle"></param>
        /// <returns></returns>
        IPost GetByTitle(string friendlyTitle);
        /// <summary>
        /// Get the Post list of the Blog
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        IQueryable<IPost> GetByBlog(int blogId);
        /// <summary>
        /// Get the Post List of the Blog, with paging support.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<IPost> GetByBlog(int blogId, int skip, int take);
        /// <summary>
        /// Get the Post list via selected date on the calander.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="date"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<IPost> GetByDate(int blogId, DateTime date, int skip, int take);
        /// <summary>
        /// Get the Post list of the Author.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="authorId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<IPost> GetByAuthor(int blogId, int authorId, int skip, int take);
        /// <summary>
        /// Get the Post list via Tag.
        /// </summary>
        /// <param name="blogId"></param>
        /// <param name="tagId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        IQueryable<IPost> GetByTag(int blogId, int tagId, int skip, int take);


		
    }
}
