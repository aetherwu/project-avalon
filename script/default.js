var switchIng = function(){
	$(".ing").removeClass("needLogin").addClass("chickToWrite").dblclick(function(){
		$(this).removeClass("chickToWrite");
	});
}
var bindLogin = function(){
	$(".needLogin").click(function(){
		window.location="/openid?m=login&opid="+ document.domain;
	});
}

$(function(){
	$("#archives").change(function(){
		window.location=$(this).val();
	});
})