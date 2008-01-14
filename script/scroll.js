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
			$(target+" .box:last").slideDown();
			idle = true;
		});
	});
}
//*/