<%@ Page Language="C#" CodeFile="page.aspx.cs" Inherits="Avalon.Web._page" %>
<% Response.ContentType = "text/xml";%><?xml version="1.0" encoding="UTF-8" ?>
<include:posts id="posts" runat="server" />