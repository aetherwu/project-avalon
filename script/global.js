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

	/*
	$(".text").each(function(){
		$(this).oneclick(function(){
			$(this).html("<textarea class='textarea' style='background:transparent;border:none;width:"+$(this).width()+"px;height:"+$(this).height()+"px'>"+$(this).html()+"</textarea>").removeClass("text");
		})
	})
	//*/
	
	reSizeImg();
})