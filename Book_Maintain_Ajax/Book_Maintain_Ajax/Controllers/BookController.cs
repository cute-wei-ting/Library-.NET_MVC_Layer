using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Book_Maintain_Ajax.Controllers
{
    public class BookController : Controller
    {
		private Book_Maintain_Ajax.Service.IBookService bookService { get; set; }

		public static int nowID { get; set; }

		private void IfIdExist(string id)
		{
			if (bookService.IsIdExist(id))
			{
				int BookID = Convert.ToInt32(id);
				nowID = BookID;
			}
		}
	
	/*---------------------INDEX.SEARCH---------------------*/

	public ActionResult Index()
	{
		return View();
	}

	public JsonResult GetDropdownList_Json(string type) //也可model下去接
	{
		List<SelectListItem> BookSelectList = bookService.GetDropdownList(type); //顯示DropDownList
		return Json(BookSelectList, JsonRequestBehavior.AllowGet);
	}
	public JsonResult GetBookName() //也可model下去接
	{
		List<string> BookName = bookService.GetBookName();
		return Json(BookName, JsonRequestBehavior.AllowGet);

	}
	public JsonResult GetGrid(Book_Maintain_Ajax.Model.BookSearch booksearch)
	{
		List<Book_Maintain_Ajax.Model.BookSearch> Grid = bookService.SearchBook(booksearch);
		return Json(Grid, JsonRequestBehavior.AllowGet);  //回傳json需要JsonRequestBehavior.AllowGet以免危險
	}

	/*---------------------INSERT---------------------*/

	public ActionResult InsertBook()
	{
		return View();
	}
	[HttpPost]
	public void InsertBook(Book_Maintain_Ajax.Model.BookInsert insertdata)
	{
		int InsertID=bookService.InsertBook(insertdata); //test用
	}
	/*---------------------BookDetail---------------------*/


	public ActionResult BookDetail(string id)
	{
		IfIdExist(id);
		return View();
	}
	[HttpPost]
	public JsonResult BookDetail()
	{
		Book_Maintain_Ajax.Model.BookUpdate bookdetail= bookService.GetBookDetail(nowID);
		return Json(bookdetail);
	}
	/*---------------------LENDRECORD---------------------*/

	public ActionResult LendRecord(string id)
	{
		IfIdExist(id);
		return View();
	}
	[HttpPost]
	public JsonResult LendRecord()
	{
		List< Book_Maintain_Ajax.Model.BookRecord>  bookRecord= bookService.GetLendRecord(nowID);
		return Json(bookRecord, JsonRequestBehavior.AllowGet);
	}

	/*---------------------UPDATE---------------------*/

	public ActionResult UpdateBook(string id)
	{
		IfIdExist(id);
		return View();
	}

	public JsonResult GetUpdateData()
	{
		Book_Maintain_Ajax.Model.BookUpdate bookupdate= bookService.GetUpdateBook(nowID);
		return Json(bookupdate, JsonRequestBehavior.AllowGet);
	}
	[HttpPost()]
	public JsonResult UpdateBook(Book_Maintain_Ajax.Model.BookUpdate bookUpdate, string IniBookStatus, string LaterBookStatus)
	{
		//借閱人借閱狀態關係
		if ((bookUpdate.BookStatusId == "B"|| bookUpdate.BookStatusId=="C")&&(bookUpdate.BookKeeperId == ""||bookUpdate.BookKeeperId == null ))
		{
			return Json("此借閱狀態,借閱人不能為空");
		}
		else
		{
				//insert 借閱紀錄 
				if ((IniBookStatus == "A" || IniBookStatus == "U") && (LaterBookStatus == "B" || LaterBookStatus == "C"))
				{
					Book_Maintain_Ajax.Model.LendRecordInsert lendRecordInsert = new Book_Maintain_Ajax.Model.LendRecordInsert();
					lendRecordInsert.BookKeeperId = bookUpdate.BookKeeperId;
					InsertLendRecord(lendRecordInsert);
				}
				//update 書本資料
				bookService.UpdateBook(nowID, bookUpdate);
			return Json("編輯成功");
		}
	}
	
	[HttpPost()]
	public JsonResult UpdateBookDel(string Status)
	{
		return DeleteBook(nowID.ToString());
	}

	/*---------------------INSERT　TO BOOK_LEND_RECORD---------------------*/

	[HttpPost()]
	public void InsertLendRecord(Book_Maintain_Ajax.Model.LendRecordInsert insertdata)
	{
		insertdata.BookID = nowID;
		bookService.InsertLendRecord(insertdata);
	}
	/*---------------------DELETE---------------------*/

	[HttpPost()]
	public JsonResult DeleteBook(string BookId)
	{
		return Json(bookService.DecideDelete(BookId));
	}

	
	}
}