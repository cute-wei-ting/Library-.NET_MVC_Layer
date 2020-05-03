







///要改
function val()
{
	$("#BookKeeperId").required = true;
}



$("#SearchDel").click( function (e){
	e.preventDefault();
	var bookStatusId = $("#BookStatusId").val();

	// 書本借閱中，不可刪除
	if (bookStatusId === "B" || bookStatusId === "C") {
		alert("借閱中，不能刪除");
		return;
	}
	else {
		if (confirm("是否刪除")) { $("#SearchFormDel").submit();}
	}
	
});







