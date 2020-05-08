using System.Collections.Generic;
using System.Data;
using System.Web.Mvc;
using Book_Maintain_Ajax.Model;

namespace Book_Maintain_Ajax.Service
{
	public interface IBookService
	{
		bool IsIdExist(string id);
		List<SelectListItem> GetDropdownList(string option);
		List<string> GetBookName();

		string DecideDelete(string BookID);
		BookUpdate GetBookDetail(int id);
		List<BookRecord> GetLendRecord(int BookId);
		BookUpdate GetUpdateBook(int id);
		int InsertBook(BookInsert insertdata);
		void InsertLendRecord(LendRecordInsert insertdata);
		List<BookSearch> SearchBook(BookSearch searchdata);
		void UpdateBook(BookUpdate updatedata);
	}
}