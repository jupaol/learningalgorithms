namespace Api.Settings
{
	public static class GlobalSettings
	{
#pragma warning disable S2339 // Public constant members should not be used
		/// <summary>
		/// Service name used as part of the URL
		/// </summary>
		/// <example>
		/// http://localhost:61043/swagger/WebServiceProject1/index.html
		/// </example>
		public const string ServiceName = "WebServiceProject1";

		/// <summary>
		/// The friendly service name used in the service description
		/// </summary>
		public const string FriendlyServiceName = "Web Service Project1";
#pragma warning restore S2339 // Public constant members should not be used
	}
}
