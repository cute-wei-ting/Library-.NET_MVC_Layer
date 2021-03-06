﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace Book_Maintain_Ajax.Model
{
	public class LendRecordInsert
	{
		[DisplayName("書ID")]
		public int BookID { get; set; }
		[DisplayName("借閱人")]
		public string BookKeeperId { get; set; }
		[DisplayName("借閱日期")]
		public string LendDate { get; set; }
		[DisplayName("建立日期")]
		public string CreDate { get; set; }
		[DisplayName("建立使用者")]
		public string CreUsr { get; set; }
		[DisplayName("修改日期")]
		public string ModDate { get; set; }
		[DisplayName("修改使用者")]
		public string ModUsr { get; set; }
	}

}
