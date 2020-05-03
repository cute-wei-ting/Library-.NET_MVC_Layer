using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Maintain_Ajax.Tool
{
	public class Logger
	{

		public enum LogCategory
		{
			Information,
			Error,
			Warning
		}

		static log4net.ILog log4netInstance;
		public Logger()
		{


		}
		public static void Write(LogCategory logCatogroy, string context)
		{
			log4netInstance = log4net.LogManager.GetLogger("Looger");
			log4net.Config.XmlConfigurator.Configure(new FileInfo(Tool.ConfigTool.GetAppsetting("log4netConfPath")));
			switch (logCatogroy)
			{
				case LogCategory.Information:
					log4netInstance.Info(context);
					break;
				case LogCategory.Error:
					log4netInstance.Error(context);
					break;
				case LogCategory.Warning:
					log4netInstance.Warn(context);
					break;
				default:
					break;
			}

		}
	}
}
