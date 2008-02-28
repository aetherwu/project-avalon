<%@ Page Language="C#" CodeFile="person.aspx.cs" Inherits="Avalon.Web._person" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/default.xsl" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<person><txt:clr id="persona" runat="server"></txt:clr></person>
	<my>
		<include:clips id="clips" runat="server" />
	</my>
	<live>
		<include:clips id="live" runat="server" />
	</live>
	<include:cmt id="recentComments" runat="server" />
	<!-- #Include File="lib/about.xml" -->
</avalon>