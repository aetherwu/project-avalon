<%@ Page Language="C#" CodeFile="view.aspx.cs" Inherits="Avalon.Web._view" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/view.xsl?update=13" type="text/xsl"?>
<avalon>
	<include:posts id="posts" runat="server" />
	<include:comments id="comments" runat="server" />
	<relative/>
	<!-- #Include File="lib/navigation.xml" -->
	<!-- #Include File="lib/about.xml" -->
</avalon>