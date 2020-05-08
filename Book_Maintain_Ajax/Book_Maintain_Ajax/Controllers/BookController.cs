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
	public void InsertBook(Model.BookInsert insertdata)
	{
		int InsertID=bookService.InsertBook(insertdata); //test用
	}
	/*---------------------BookDetail---------------------*/


	public ActionResult BookDetail(string id)
	{
		return View();
	}
	public JsonResult ShowBookDetail(string id)
	{
		if (bookService.IsIdExist(id))
		{
			Model.BookUpdate bookdetail = bookService.GetBookDetail(Convert.ToInt32(id));
			return Json(bookdetail, JsonRequestBehavior.AllowGet);
		}
		else return Json(null, JsonRequestBehavior.AllowGet); 
	}
	/*---------------------LENDRECORD---------------------*/

	public ActionResult LendRecord(string id)
	{
		return View();
	}
	public JsonResult ShowLendRecord(string id)
	{
		if (bookService.IsIdExist(id))
		{
			List<Model.BookRecord> bookRecord = bookService.GetLendRecord(Convert.ToInt32(id));
			return Json(bookRecord, JsonRequestBehavior.AllowGet);
		}
		else return Json(null, JsonRequestBehavior.AllowGet);
	}

		///*---------------------UPDATE---------------------*/

	public ActionResult UpdateBook(string id)
	{
		return View();
	}

	public JsonResult GetUpdateData(string id)
	{
		Model.BookUpdate bookupdate = bookService.GetUpdateBook(Convert.ToInt32(id));

		return Json(bookupdate, JsonRequestBehavior.AllowGet);
	}
		[HttpPost()]
		public JsonResult UpdateBook(Model.BookUpdate bookUpdate, string IniBookStatus, string LaterBookStatus)
		{
			//借閱人借閱狀態關係
			if ((bookUpdate.BookStatusId == "B" || bookUpdate.BookStatusId == "C") && (bookUpdate.BookKeeperId == "" || bookUpdate.BookKeeperId == null))
			{
				return Json("此借閱狀態,借閱人不能為空");
			}
			else
			{
				//insert 借閱紀錄 
				if ((IniBookStatus == "A" || IniBookStatus == "U") && (LaterBookStatus == "B" || LaterBookStatus == "C"))
				{
					Model.LendRecordInsert lendRecordInsert = new Model.LendRecordInsert();
					lendRecordInsert.BookKeeperId = bookUpdate.BookKeeperId;
					bookService.InsertLendRecord(lendRecordInsert);
				}
				//update 書本資料
				bookService.UpdateBook(bookUpdate);
				return Json("編輯成功");
			}
		}
		///*---------------------DELETE---------------------*/

		[HttpPost()]
		public JsonResult DeleteBook(string BookId)
		{
			return Json(bookService.DecideDelete(BookId));
		}


	}
}