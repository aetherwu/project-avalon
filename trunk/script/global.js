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

var saveDelete = function(logtime){
	$.post(
		"/api",
		{
			"m": "delete",
			"time": logtime
		},
		function(msg){
			if (msg==1) {
				return true;
			} else {
				alert(msg);
			}
		}
	);
}

var saveNew = function(nowtime, content){
	content = content.replace(/\n/g,"<br />");
	$.post(
		"/api",
		{
			"m": "post",
			"time": nowtime,
			"clip": content
		},
		function(msg){
			if (msg!=0)
				alert(msg);
		}
	);
}
var saveUpdate = function(logtime,content){
	content = content.replace(/\n/g,"<br />");
	$.post(
		"/api",
		{
			"m": "update",
			"time": logtime,
			"clip": content
		},
		function(msg){
			if (msg!=1)
				alert(msg);
		}
	);
}

bindDelete = function() {
	$(".time").append("<a href='javascript://' class='deleteBtn'>删除</a>");
	$(".deleteBtn").click(function(){
		var logtime = $(this).parent().next().attr("id").replace(/\//g,"-");
		if (confirm("确认删除？")) {
			saveDelete(logtime);
			$(this).parent().fadeOut().next().fadeOut();
		}
	});
}

$(function(){

	$.get("/openid?m=check",function(e){
		if(e==1){
			bindDelete();
		}
	});

});