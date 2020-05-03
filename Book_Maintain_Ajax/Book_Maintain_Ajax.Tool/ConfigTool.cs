using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Maintain_Ajax.Tool
{
	public static class ConfigTool
	{
		//connect string
		public static string GetDBConnectionString()
		{
			return System.Configuration.ConfigurationManager.ConnectionStrings["DBConn"].ConnectionString.ToString();
		}
		public static string GetAppsetting(string Key)
		{
			string AppSetting = string.Empty;
			AppSetting = System.Configuration.ConfigurationManager.AppSettings[Key];
			return AppSetting;
		}
	}
}
