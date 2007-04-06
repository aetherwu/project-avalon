<%@ Page Language="C#" CodeFile="rss.aspx.cs" Inherits="Avalon.Web._rss" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<rss version="2.0" 
	xmlns:content="http://purl.org/rss/1.0/modules/content/"
	xmlns:wfw="http://wellformedweb.org/CommentAPI/"
	xmlns:dc="http://purl.org/dc/elements/1.1/"
>
<channel>
	<title>Aether - 在世即是理想乡</title>
	<link>http://woooh.com/</link>
	<description>what you remember happened in the past, and only what you believe might happen in the future. free your mind.</description>
	<generator>http://code.google.com/p/blogif/</generator>
	<language>zh-cn</language>

		<asp:Repeater id="postList" OnItemDataBound="postList_ItemDataBound" runat="server"><ItemTemplate><item>
			<title><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:D}") %> - Aether</title>
			<link>http://woooh.com/<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %></link>
			<pubDate><%# Eval("PostTime") %></pubDate>
			<guid isPermaLink="true">http://woooh.com/<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %></guid>
			<content:encoded>
			<![CDATA[ 
				<asp:Repeater id="postInDay" runat="server"><ItemTemplate>
				<br/>
				<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:HH:mm:ss}") %>
				<br/>
				<br/>
				<%# Eval("Content") %>
				<br/>
				<br/>
				</ItemTemplate></asp:Repeater>
				<br/>
				<br/>
				============================================<br/>
				你可能正在通过URL重写订阅到我的blog，以前的地址将在月内失效。<br/>
				请更换我的RSS订阅地址到：http://rss.woooh.com/<br/>
				带来些麻烦，我非常抱歉。
			]]>
			</content:encoded>
		</item>
		</ItemTemplate></asp:Repeater>

	</channel>
</rss>