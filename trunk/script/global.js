$(function(){
	if(!document.all){
		$(".text").each(function(e){
			this.innerHTML = this.textContent;
		})
	}

	reSizeImg();
})

function reSizeImg(){
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

babel_ing_prefix="";
babel_ing_color_prefix = "#999";
babel_ing_color_time = "#999";