using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Book_Maintain_Ajax.Model
{
	public class BookSearch
	{
		[DisplayName("書ID")]
		public int BookID { get; set; }
		[DisplayName("書名")]
		public string BookName { get; set; }
		[DisplayName("圖書類別")]
		public string BookClassId { get; set; }
		[DisplayName("借閱人")]
		public string BookKeeperId { get; set; }
		[DisplayName("借閱狀態")]
		public string BookStatusId { get; set; }
		[DisplayName("購書日期")]
		public string BoughtDate { get; set; }
	}

}
