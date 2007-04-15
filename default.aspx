<%@ Page Language="C#" CodeFile="default.aspx.cs" Inherits="Avalon.Web._default" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/default.xsl" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<include:posts id="posts" runat="server" />
	<relative>
		<include:list id="recentPosts" Name="���д��" runat="server" />
		<include:cmt id="recentComments" Name="���·��" runat="server" />
		<include:arv id="archives" Name="���·��" runat="server" />
	</relative>
	<!-- #Include File="lib/about.xml" -->
</avalon>