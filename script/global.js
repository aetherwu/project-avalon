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