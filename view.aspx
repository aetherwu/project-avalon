<%@ Page Language="C#" CodeFile="view.aspx.cs" Inherits="Avalon.Web._view" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/view.xsl" type="text/xsl"?>
<avalon>
	<person><txt:clr id="persona" runat="server"></txt:clr></person>
	<my>
		<include:clips id="clips" runat="server" />
	</my>
	<live>
		<include:clips id="live" runat="server" />
	</live>
	<include:comments id="comments" runat="server" />
	<!-- #Include File="lib/navigation.xml" -->
	<!-- #Include File="lib/about.xml" -->
</avalon>