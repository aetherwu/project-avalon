<%@ Page Language="C#" CodeFile="view.aspx.cs" Inherits="Avalon.Web._view" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/view.xsl" type="text/xsl"?>
<avalon>
	<include:posts id="clips" runat="server" />
	<include:comments id="comments" runat="server" />
	<relative/>
	<!-- #Include File="lib/navigation.xml" -->
	<!-- #Include File="lib/about.xml" -->
</avalon>