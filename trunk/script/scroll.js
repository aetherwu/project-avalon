//*
// @code from http://ma.la/
// @author ma.la <timpo@ma.la>
var idle=true;
var after;
var watchScroll = function(){
	//try{
		if (document.documentElement && document.documentElement.scrollTop) {
			var sc = document.documentElement.scrollTop;
			var wh = window.innerHeight ? window.innerHeight : document.documentElement.clientHeight;
			var total = (document.documentElement.scrollHeight - wh);
		} else if (document.body) {
			var sc = document.body.scrollTop;
			var wh = window.innerHeight ? window.innerHeight : document.body.clientHeight;
			var total = (document.body.scrollHeight - wh);
		}
		var remain = total - sc;
		if(remain < 300 && remain!=0){
			requestMore();
		}
	//}catch(e){}
	var self = arguments.callee;
	setTimeout(self,300);
};
// rewrite as jquery mode
var requestMore = function(){
	if (idle)
	{
		after = $($(".post:last .date").html()).attr("href").replace("http://woooh.com","").substring(1,12);
		tranform("/more?after="+after,"/styles/posts.xsl",".content");
		idle = false;
	}
}
// @code form http://blog.csdn.net/cubit/archive/2006/07/27/987049.aspx
// @author 冰河の泥鱼 2006/07/27
// @editor Aether 2007/04/24
var tranform =function (xmlurl,xslurl,target) {
	$.get(xmlurl,function(m){
		$.get(xslurl,function(s){
			var xml = m;
			var xsl = s;
			var html;
			if(document.all)
			{
				html = xml.documentElement.transformNode(xsl);
			}
			else if(document.documentElement)
			{
				var xsltProcessor = new XSLTProcessor();
					xsltProcessor.importStylesheet(xsl);
				var oResultFragment = xsltProcessor.transformToFragment(xml,document);
					html = oResultFragment;
			}
			$(target).append(html);
			idle = true;
		});
	});
}
//*/

//smooth scorll
$(function(){
	if (location.toString().length>20)
		watchScroll();
})