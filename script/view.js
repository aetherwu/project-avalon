$(function(){
	$("input.submit").click(function(){
		var guest = $("#guest").val();
		var home = $("#home").val();
		var message = $("#message").val();
		var day =  $("#day").val();
		
		if (guest.length>40 || home.length>100)
			return false

		if (guest.length>0 && message.length>0)
		{
			$("input, textarea").attr("disabled","true");
			$.post(
				"/api",
				{
					"guest":guest,
					"home":home,
					"message":message,
					"day":day,
					"m":"say"
				},
				function(msg){
					if (home.length>0)
						guest = "<a href="+home+">"+guest+"<\/a>";
					$("<div class='box comment commentNew'><div class='inner'><div class='caption'><span>just now<\/span><i>+<\/i>"+guest+"<\/div><div class='contain'>"+message+"<\/div><\/div><\/div>").insertBefore(".commentGuild:last");
					$("input, textarea").attr("disabled","");
					$("#message").val();
					$(".commentPost ul").fadeIn();
				}
			);
		}

		return false;
	})
})
