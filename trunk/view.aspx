<%@ Page Language="C#" CodeFile="view.aspx.cs" Inherits="Avalon.Web._view" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/view.xsl" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<include:posts id="posts" runat="server" />
	<include:comments id="comments" runat="server" />
	<include:refers id="refers" runat="server" />
	<relative>
		<include:list id="recentPosts" Name="×î½üÐ´µÄ" runat="server" />
	</relative>
	<!-- #Include File="lib/about.xml" -->
</avalon>