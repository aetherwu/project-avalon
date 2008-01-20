<%@ Page Language="C#" CodeFile="person.aspx.cs" Inherits="Avalon.Web._person" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/default.xsl" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<my>
		<person><txt:clr id="persona" runat="server"></txt:clr></person>
		<include:today id="clips_today" runat="server" />
		<include:posts id="clips" runat="server" />
	</my>
	<friends>
		<include:today id="clips_today_f" runat="server" />
		<include:posts id="clips_f" runat="server" />
	</friends>
	<!-- #Include File="lib/about.xml" -->
</avalon>