namespace NsTasks.Core.Data
{
	using System.Collections.Generic;

	using RestSharp;

	public class AsanaResponse<T> : RestResponse, IRestResponse
	{
		public T Data { get; set; }

		public List<AsanaError> Errors { get; set; }
	}

	public class AsanaError
	{
		public string message { get; set; }
	}
}