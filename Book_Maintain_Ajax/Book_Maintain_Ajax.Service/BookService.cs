using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

///<summary>
///	Factory exxcute DI
///</summary>
///<code>
///BookFactory bookFactory = new BookFactory();
///Book_Maintain_Ajax.Dao.IBookDao bookDao = bookFactory.GetBookDao();
/// </code>
namespace Book_Maintain_Ajax.Service
{
	public class BookService : IBookService
	{
		private Book_Maintain_Ajax.Dao.IBookDao bookDao { get; set; }

		public bool IsIdExist(string id)
		{
			return bookDao.IsIdExist(id);
		}
		public List<SelectListItem> GetDropdownList(string option)
		{
			return bookDao.GetDropdownList(option);
		}
		public List<string> GetBookName()
		{
			return bookDao.GetBookName();
		}
		public List<Book_Maintain_Ajax.Model.BookSearch> SearchBook(Book_Maintain_Ajax.Model.BookSearch searchdata)
		{
			return bookDao.SearchBook(searchdata);
		}
		public int InsertBook(Book_Maintain_Ajax.Model.BookInsert insertdata)
		{
			return bookDao.InsertBook(insertdata);
		}
		public Book_Maintain_Ajax.Model.BookUpdate GetBookDetail(int id)
		{
			return bookDao.GetBookDetail(id);
		}
		public List<Book_Maintain_Ajax.Model.BookRecord> GetLendRecord(int BookId)
		{
			return bookDao.GetLendRecord(BookId);
		}
		public Book_Maintain_Ajax.Model.BookUpdate GetUpdateBook(int id)
		{
			return bookDao.GetUpdateBook(id);
		}
		public void UpdateBook(int id, Book_Maintain_Ajax.Model.BookUpdate updatedata)
		{
			bookDao.UpdateBook(id, updatedata);
		}
		public string DecideDelete(string BookID)
		{
			return bookDao.DecideDelete(BookID);
		}
		public void InsertLendRecord(Book_Maintain_Ajax.Model.LendRecordInsert insertdata)
		{
			bookDao.InsertLendRecord(insertdata);
		}

	}
}
