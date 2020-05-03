using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Book_Maintain_Ajax.Model;

namespace Book_Maintain_Ajax.Dao
{
	public class BookTestDao : IBookDao
	{
		public bool IsIdExist(string id)
		{
			throw new NotImplementedException();
		}
		public BookUpdate BookDetailModel(DataTable dt)
		{
			throw new NotImplementedException();
		}
		public string DecideDelete(string BookID)
		{
			throw new NotImplementedException();
		}
		public void DeleteBook(int BookId)
		{
			throw new NotImplementedException();
		}

		public BookUpdate GetBookDetail(int id)
		{
			throw new NotImplementedException();
		}

		public List<string> GetBookName()
		{
			throw new NotImplementedException();
		}

		public List<SelectListItem> GetDropdownList(string option)
		{
			throw new NotImplementedException();
		}

		public List<BookRecord> GetLendRecord(int BookId)
		{
			throw new NotImplementedException();
		}

		public BookUpdate GetUpdateBook(int id)
		{
			throw new NotImplementedException();
		}

		public int InsertBook(BookInsert insertdata)
		{
			throw new NotImplementedException();
		}

		public void InsertLendRecord(LendRecordInsert insertdata)
		{
			throw new NotImplementedException();
		}

		public List<BookRecord> LendToModelList(DataTable dt)
		{
			throw new NotImplementedException();
		}

		public List<BookSearch> SearchBook(BookSearch searchdata)
		{
			throw new NotImplementedException();
		}

		public BookUpdate ToModel(DataTable dt)
		{
			throw new NotImplementedException();
		}

		//public List<BookSearch> ToModelList(DataTable dt)
		//{
		//	throw new NotImplementedException();
		//}

		public void UpdateBook(int id, BookUpdate updatedata)
		{
			throw new NotImplementedException();
		}
	}
}
