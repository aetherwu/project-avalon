var reSizeImg = function(){
	var Allimg=document.getElementsByTagName("img");
	for (var i in Allimg) {
		drawImage(Allimg[i]);
	}
}
var drawImage = function(ImgD){ 
	var image=new Image(); 
	image.src=ImgD.src; 
	if(image.width>0 && image.height>0){ 
		flag=true; 
		if(image.width>=450){ 
			ImgD.width=450; 
			ImgD.height=(image.height*450)/image.width; 
		}else{ 
			ImgD.width=image.width; 
			ImgD.height=image.height; 
		}  
	} 
}

jQuery.cookie = function (name, value, options) {
    if (typeof value != "undefined") {
        options = options || {};
        var expires = "";
        if (options.expires &&
            (typeof options.expires == "number" ||
            options.expires.toGMTString)) {
            var date;
            if (typeof options.expires == "number") {
                date = new Date;
                date.setTime(date.getTime() + options.expires * 24 * 60 * 60 * 1000);
            } else {
                date = options.expires;
            }
            expires = "; expires=" + date.toGMTString();
        }
        var path = options.path ? "; path=" + options.path : "";
        var domain = options.domain ? "; domain=" + options.domain : "";
        var secure = options.secure ? "; secure" : "";
        document.cookie = [name, "=", encodeURIComponent(value), expires, path, domain, secure].join("");
    } else {
        var cookieValue = null;
        if (document.cookie && document.cookie != "") {
            var cookies = document.cookie.split(";");
            for (var i = 0; i < cookies.length; i++) {
                var cookie = jQuery.trim(cookies[i]);
                if (cookie.substring(0, name.length + 1) == name + "=") {
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }
}

$(function(){

	//*
	$(".text").each(function(){
		$(this).dblclick(function(){
			$(this).html("<textarea class='textarea' style='background:transparent;border:none;width:"+$(this).width()+"px;height:"+$(this).height()+"px'>"+$(this).html()+"</textarea>").removeClass("text");
		})
	})
	//*/
	
	reSizeImg();

	//bind blogosphere event
	var log_s = $(".blogosphere .contain ul:lt(4)");
	var log_m = $(".blogosphere .contain ul:gt(4)");
	var log_b = $(".blogosphere .more");
	log_s.fadeIn();
	log_b.toggle(
		function(){
			log_m.fadeIn("show",function(){
				log_b.html("收起")
			});
		},
		function(){
			log_m.fadeOut("show",function(){
				log_b.html("查看全部")
			});
		}
	);
})