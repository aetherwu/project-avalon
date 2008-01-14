<%@ Page Language="C#" CodeFile="person.aspx.cs" Inherits="Avalon.Web._person" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<?xml-stylesheet href="/styles/default.xsl" type="text/xsl"?>
<avalon>
	<!-- #Include File="lib/navigation.xml" -->
	<my>
		<include:posts id="clips" runat="server" />
	</my>
	<friends>
		<include:posts id="friendsClips" runat="server" />
	</friends>
	<relative>
		<include:cmt id="recentComments" runat="server" />
		<include:arv id="archives" runat="server" />
	<!-- #Include File="lib/blogosphere.xml" -->
	</relative>
	<!-- #Include File="lib/about.xml" -->
</avalon>