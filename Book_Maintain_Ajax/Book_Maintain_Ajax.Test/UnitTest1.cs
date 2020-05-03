using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
//TestDeleteBook.playlist 測試一般刪除
//TestDeleteLendOutBook.playlist　測試已借出後,不可刪除
namespace Book_Maintain_Ajax.Test
{
	[TestInitialize]
	[TestClass]
	public class UnitTest1
	{
		//Arrange
		private static int InsertId = 0;
		Book_Maintain_Ajax.Dao.BookDao bookDao = new Dao.BookDao();
		private static Book_Maintain_Ajax.Model.BookInsert bookInsert = new Model.BookInsert
		{
			BookName = "hello world",
			BookAuthor = "Marz",
			BookPublisher = "南一",
			Note = "112233",
			BoughtDate = DateTime.Parse("2019/03/15"),
			BookClass = "BK"
		};
		private static Book_Maintain_Ajax.Model.BookUpdate bookUpdate = new Model.BookUpdate
		{
			BookName = "hello world",
			BookAuthor = "Marz",
			BookPublisher = "南一",
			Note = "112233",
			BoughtDate = "2019/03/15",
			BookClassId = "BK",
			BookStatusId = "B",
			BookKeeperId = "0001"
		};
		[TestMethod]
		public void TestInsertBook()
		{
			//Act
			InsertId = bookDao.InsertBook(bookInsert);
			System.Diagnostics.Debug.WriteLine("TestInsert:" + InsertId);
			//Assert
			Assert.AreNotEqual(0, InsertId);
			System.Diagnostics.Debug.WriteLine("************TestInsertBook SUCCESS*************");
		}

		[TestMethod]
		public void TestGetBook()
		{
			//Act
			Book_Maintain_Ajax.Model.BookUpdate bookUpdate = bookDao.GetUpdateBook(InsertId);
			System.Diagnostics.Debug.WriteLine("TestGetBook:" + InsertId);
			//Assert
			Assert.AreEqual(bookInsert.BookName, bookUpdate.BookName);
			Assert.AreEqual(bookInsert.BookAuthor, bookUpdate.BookAuthor);
			Assert.AreEqual(bookInsert.BookPublisher, bookUpdate.BookPublisher);
			Assert.AreEqual(bookInsert.Note, bookUpdate.Note);
			Assert.AreEqual(bookInsert.BoughtDate.ToString("yyyy/MM/dd"), bookUpdate.BoughtDate);
			Assert.AreEqual(bookInsert.BookClass, bookUpdate.BookClassId);
			System.Diagnostics.Debug.WriteLine("************TestGetBook SUCCESS*************");

		}

		[TestMethod]
		public void TestDeleteBook()
		{
			//Act
			System.Diagnostics.Debug.WriteLine("TestDelete:" + InsertId);
			string IfDelete=bookDao.DecideDelete(Convert.ToString(InsertId));
			Book_Maintain_Ajax.Model.BookUpdate bookUpdate = bookDao.GetUpdateBook(InsertId);


			//Assert
			Assert.AreEqual("刪除成功", IfDelete);
			Assert.AreEqual(null, bookUpdate.BookName);
			Assert.AreEqual(null, bookUpdate.BookAuthor);
			Assert.AreEqual(null, bookUpdate.BookPublisher);
			Assert.AreEqual(null, bookUpdate.Note);
			Assert.AreEqual(null, bookUpdate.BoughtDate);
			Assert.AreEqual(null, bookUpdate.BookClassId);
			System.Diagnostics.Debug.WriteLine("************TestDeleteBook SUCCESS*************");

		}
		[TestMethod]
		public void TestUpdateBook()
		{
			//Act
			bookDao.UpdateBook(InsertId, bookUpdate);
			Book_Maintain_Ajax.Model.BookUpdate bookUpdateBack = bookDao.GetUpdateBook(InsertId);
			System.Diagnostics.Debug.WriteLine("TestUpdateBook:" + InsertId);
			//Assert
			Assert.AreEqual(bookUpdate.BookName, bookUpdateBack.BookName);
			Assert.AreEqual(bookUpdate.BookAuthor, bookUpdateBack.BookAuthor);
			Assert.AreEqual(bookUpdate.BookPublisher, bookUpdateBack.BookPublisher);
			Assert.AreEqual(bookUpdate.Note, bookUpdateBack.Note);
			Assert.AreEqual(bookUpdate.BoughtDate, bookUpdateBack.BoughtDate);
			Assert.AreEqual(bookUpdate.BookClassId, bookUpdateBack.BookClassId);
			Assert.AreEqual(bookUpdate.BookStatusId, bookUpdateBack.BookStatusId);
			Assert.AreEqual(bookUpdate.BookKeeperId, bookUpdateBack.BookKeeperId);
			System.Diagnostics.Debug.WriteLine("************TestUpdateBook SUCCESS*************");
		}

		[TestMethod]
		public void TestLendDeleteBook()
		{
			//Act
			System.Diagnostics.Debug.WriteLine("TestDelete:" + InsertId);
			string IfDelete = bookDao.DecideDelete(Convert.ToString(InsertId));
			Book_Maintain_Ajax.Model.BookUpdate bookUpdate = bookDao.GetUpdateBook(InsertId);

			//Assert
			Assert.AreEqual("已借出不可刪除", IfDelete);
			Assert.AreNotEqual(null, bookUpdate.BookName);
			Assert.AreNotEqual(null, bookUpdate.BookAuthor);
			Assert.AreNotEqual(null, bookUpdate.BookPublisher);
			Assert.AreNotEqual(null, bookUpdate.Note);
			Assert.AreNotEqual(null, bookUpdate.BoughtDate);
			Assert.AreNotEqual(null, bookUpdate.BookClassId);
			System.Diagnostics.Debug.WriteLine("************TestLendDeleteBook SUCCESS*************");
		}

		[TestMethod]
		public void Clean()
		{
			//Arrange
			Book_Maintain_Ajax.Model.BookUpdate bookUpdateClean = new Model.BookUpdate
			{
				BookName = "hello world",
				BookAuthor = "Marz",
				BookPublisher = "南一",
				Note = "112233",
				BoughtDate = "2019/03/15",
				BookClassId = "BK",
				BookStatusId = "A",
				BookKeeperId = ""
			};
			//Act
			//bookDao.UpdateBook(InsertId, bookUpdate);
			bookDao.UpdateBook(InsertId, bookUpdateClean);
			string IfDelete = bookDao.DecideDelete(Convert.ToString(InsertId));
			System.Diagnostics.Debug.WriteLine("TestClean:" + InsertId);
			System.Diagnostics.Debug.WriteLine("************TestClean SUCCESS*************");
			//Alert
			Assert.AreEqual("刪除成功", IfDelete);
		}
	}
}
