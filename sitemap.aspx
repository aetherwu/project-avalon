<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sitemap.aspx.cs" Inherits="Avalon.Web._sitmap" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8"?>
<urlset
	xmlns="http://www.google.com/schemas/sitemap/0.84"
	xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance"
	xsi:schemaLocation="http://www.google.com/schemas/sitemap/0.84
	http://www.google.com/schemas/sitemap/0.84/sitemap.xsd">
	<url>
		<loc>http://woooh.com/</loc>
		<changefreq>hourly</changefreq>
		<priority>0.8</priority>
	</url>
	<asp:Repeater id="monthList" runat="server"><ItemTemplate><url>
		<loc>http://woooh.com/<%# DataBinder.Eval(Container.DataItem,"Month","{0:yyyy\\/MM}") %></loc>
		<changefreq>never</changefreq>
	</url>
	</ItemTemplate></asp:Repeater>
	<asp:Repeater id="clipList" runat="server"><ItemTemplate><url>
		<loc>http://woooh.com/<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %></loc>
		<changefreq>never</changefreq>
	</url>
	</ItemTemplate></asp:Repeater>
</urlset> 