$(function(){

	/*
	$(".text").each(function(){
		$(this).oneclick(function(){
			$(this).html("<textarea class='textarea' style='background:transparent;border:none;width:"+$(this).width()+"px;height:"+$(this).height()+"px'>"+$(this).html()+"</textarea>").removeClass("text");
		})
	})
	//*/

	/*
	// @code from http://ma.la/
	// @author ma.la <timpo@ma.la>
	var watch_scroll = function(){
		try{
			var sc = document.body.scrollTop;
			var wh = window.innerHeight ? window.innerHeight : document.body.clientHeight;
			var total = (document.body.scrollHeight - wh);
			var remain = total - sc;
			if(remain < 500 && Enable == 1){
				requestMore()
			}
		}catch(e){
		}
		var self = arguments.callee;
		setTimeout(self,100);
	};
	//*/

	reSizeImg();
})

var currentPage = 0;
var requestMore = function(){
	
}

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