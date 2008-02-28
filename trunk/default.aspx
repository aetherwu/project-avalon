<%@ Page Language="C#" CodeFile="default.aspx.cs" Inherits="Avalon.Web._default" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/default.xsl" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<relative>
		<include:cmt id="recentComments" runat="server" />
		<include:arv id="archives" runat="server" />
	<!-- #Include File="lib/blogosphere.xml" -->
	</relative>
	<!-- #Include File="lib/about.xml" -->
</avalon>