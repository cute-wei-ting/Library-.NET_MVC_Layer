using Book_Maintain_Ajax.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Maintain_Ajax.Service
{
	public class BookFactory
	{
		public IBookDao GetBookDao()
		{
			IBookDao result;
			switch(Tool.ConfigTool.GetAppsetting("DaoInTest"))
			{
				case "Y":
					result = new Book_Maintain_Ajax.Dao.BookTestDao();
					break;
				case "N":
					result = new Book_Maintain_Ajax.Dao.BookDao();
					break;
				default:
					result = new Book_Maintain_Ajax.Dao.BookTestDao();
					break;
			}
			return result;
		}
	}
}
