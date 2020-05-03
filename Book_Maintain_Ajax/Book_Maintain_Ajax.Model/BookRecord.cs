using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Book_Maintain_Ajax.Model
{
	public class BookRecord
	{
		[DisplayName("借閱日期")]
		public string LendDate { get; set; }
		[DisplayName("借閱人員編號")]
		public string BookKeeperId { get; set; }
		[DisplayName("英文姓名")]
		public string UserEname { get; set; }
		[DisplayName("中文姓名")]
		public string UserCname { get; set; }
	}

}
