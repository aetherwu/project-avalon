﻿jQuery.cookie = function (name, value, options) {
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
//*//
var saveAuto = function(){

	//save
	var text = $("textarea");
	var ready = false;
	text.each(function(){
		var o = $(this);
		if (o.val()!="")
		{
			var clip = o.val();
			var datetime = o.parent().attr("id");
			var mothod;

			//如果时间为空，那么设置datetime为当前时间
			//写回id中备用
			if (typeof datetime == "undefined" || datetime=="") {
				var now = new Date();
				var date = now.getFullYear() +"/"+ (parseInt(now.getMonth())+1) +"/"+ now.getDate();
				var time = now.getHours() +":"+ now.getMinutes() +":"+ now.getSeconds();
				datetime = date +" "+ time;
				o.parent().attr("id",datetime);
				o.parent().prev().html(time);
				mothod = "new";
			}

			//状态监视
			var cookiename = datetime.replace(" ","_");
			var cache = $.cookie(cookiename);
			var status = $.cookie(cookiename +"_s");
			if (cache == null || cache=="") {
				//如果未曾保存过缓存，创建并写入当前的
				$.cookie(cookiename,clip);
				ready=true;
				$.cookie(cookiename ,clip);
				$.cookie(cookiename +"_s",1);
			} else {
				//如果已经保存过缓存
				if (clip==cache){
					//如果和保存的文本内容一致
					//检查/创建/递增计数器
					if (status == null || status == 0) {
						$.cookie(cookiename +"_s",1);
					} else {
						$.cookie(cookiename +"_s",parseInt(status)+1);
					}
					if (status>5) {
						o.parent().html( clip.replace(/\n/g,"<br />") ).fadeIn().bindEditor();
						$.cookie(cookiename ,"");
						$.cookie(cookiename +"_s",0);
					}
				}else{
					//保存当前数据，清除当前计数器
					ready=true;
					$.cookie(cookiename ,clip);
					$.cookie(cookiename +"_s",1);
				}
			}

			//如果存在更新
			if (ready) {
				if (mothod=="new")	{
					//找不到日期，时间为刚才的计算值
					saveNew( datetime.replace(/\//g,"-") , clip);
				} else {
					//提供正确的时间格式
					saveUpdate( datetime.replace(/\//g,"-") , clip);
				}
			}

		}
	});
	
	//repeater
	var self = arguments.callee;
	setTimeout(self,5000);
	/*
	NOTE TODO:
	分段式储存，把新增的字缓存在Cookie or flash里面防止丢失，这样可以适当延长储存时间，减轻消耗；
	同时也保证了所有数据不会丢失。
	*/
}
//*/

jQuery.fn.bindEditor = function() {
	$(this).dblclick(function(){
		var ihtml = $(this).html();
			ihtml = ihtml.replace(/<br>/g,"\n");
			ihtml = ihtml.replace(/<BR>/g,"\n");
		$(this).html("<textarea class='textarea' style='height:"+$(this).height()+"px'>"+ihtml+"</textarea>").unbind("dblclick");
	});
	$(this).keyup(function(e){
		var itext = $(this).find("textarea")[0];
		if( e.keyCode==13 || e.keyCode==8 || e.keyCode==46){
			itext.style.posHeight = itext.scrollHeight ;
			//$("input.key").val(parseInt(itext.style.height)-25 +"-"+ itext.scrollHeight)
			if (itext.scrollHeight-25!=0) {
				if ( parseInt(itext.style.height)-25 < itext.scrollHeight ) {
					itext.style.height = itext.scrollHeight+'px';
				} else {
					itext.style.height = (itext.scrollHeight-25 ) +'px';				
				}
			}
		}
	});
}

$(function(){
		
	//bind editor mode
	if (owner) {
		$(".text").bindEditor();
		saveAuto();
	}

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

});