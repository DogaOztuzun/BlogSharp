namespace BlogSharp.MvcExtensions.Filters
{
	using System.IO.Compression;
	using System.Web;
	using System.Web.Mvc;

	//Taken from http://weblogs.asp.net/rashid/archive/2008/03/28/asp-net-mvc-action-filter-caching-and-compression.aspx
	public class CompressFilter : ActionFilterAttribute
	{
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			HttpRequestBase request = filterContext.HttpContext.Request;
			string acceptEncoding = request.Headers["Accept-Encoding"];
			if (string.IsNullOrEmpty(acceptEncoding))
				return;
			acceptEncoding = acceptEncoding.ToUpperInvariant();

			HttpResponseBase response = filterContext.HttpContext.Response;
			if (acceptEncoding.Contains("GZIP"))
			{
				response.AppendHeader("Content-encoding", "gzip");
				response.Filter = new GZipStream(response.Filter, CompressionMode.Compress);
			}
			else if (acceptEncoding.Contains("DEFLATE"))
			{
				response.AppendHeader("Content-encoding", "deflate");
				response.Filter = new DeflateStream(response.Filter, CompressionMode.Compress);
			}
		}
	}
}