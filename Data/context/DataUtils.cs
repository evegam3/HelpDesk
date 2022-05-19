using Microsoft.Extensions.Configuration;

namespace Data.context
{
    public static class DataUtils
    {
		public const string CONNECTION_STRING_KEY = "HelpDeskContext";

		public const string CONTENT_ROOT_PLACE_HOLDER = "%CONTENTROOTPATH%";

		public static string ResolveDbConnectionString(IConfiguration Configuration, string contentRootPath, string connectionStringKey = CONNECTION_STRING_KEY)
		{

			var connectionString = Configuration.GetConnectionString(connectionStringKey);

			if (connectionString.Contains(CONTENT_ROOT_PLACE_HOLDER))
			{
				connectionString = connectionString.Replace(CONTENT_ROOT_PLACE_HOLDER, contentRootPath);
			}

			return connectionString;
		}
	}
}
