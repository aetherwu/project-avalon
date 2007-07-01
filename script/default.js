var switchIng = function(){

	$("#formLogin").remove();
	$("#ing").append("<form action='/api' method='post' id='formWrite'><textarea name='clip' id='clip'></textarea><input type='hidden' name='m' value='new' /><a href='javascript://' class='cannel'>整段删除</a></form>");

	$(".needLogin").unbind("click").addClass("chickToWrite");
	$(".cannel, .chickToWrite").click(function(){
		$("#formWrite, .chickToWrite").toggle();
	});

	$("#formWrite").submit(function(){
		var t = "　　"+$("#clip").val();
		$.post(
			"/api",
			{
				"m":"new",
				"clip":t
			},
			function(msg){
				$("<div class='text'>"+t+"</div><div class='time'>刚才</div>").insertAfter("#ing");
				$("#clip").val("");
				$("#formWrite, .chickToWrite").toggle();
			}
		);
		return false;
	});
}
var bindLogin = function(){
	$(".needLogin").click(function(){
		$("#formLogin")[0].submit();
	});
}

$(function(){
	$("#archives").change(function(){
		window.location=$(this).val();
	});
})