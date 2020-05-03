using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Book_Maintain_Ajax.Model
{
	public class BookInsert
	{
		[DisplayName("書名")]
		public string BookName { get; set; }

		[DisplayName("作者")]
		public string BookAuthor { get; set; }

		[DisplayName("出版商")]
		public string BookPublisher { get; set; }

		[DisplayName("內容簡介")]
		public string Note { get; set; }

		[DisplayName("購書日期")]
		public DateTime BoughtDate { get; set; }

		[DisplayName("圖書類別")]
		public string BookClass { get; set; }
	}
}
