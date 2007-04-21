<%@ Page Language="C#" CodeFile="default.aspx.cs" Inherits="Avalon.Web._default" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/default.xsl?update=13" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<include:posts id="posts" runat="server" />
	<relative>
		<include:list id="recentPosts" runat="server" />
		<include:cmt id="recentComments" runat="server" />
		<include:arv id="archives" runat="server" />
	<!-- #Include File="lib/links.xml" -->
	</relative>
	<!-- #Include File="lib/about.xml" -->
</avalon>