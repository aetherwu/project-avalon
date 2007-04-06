<%@ Control Language="C#" AutoEventWireup="true" CodeFile="recentPosts.ascx.cs" Inherits="Avalon.Web.recentPosts" %>
		<recentPosts sortType='<txt:clr id="postType" runat="server"></txt:clr>'>
			<asp:Repeater id="recentList" runat="server"><ItemTemplate><summary postTime="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:d}") %>" address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %>"><%# Eval("Content") %></summary>
			</ItemTemplate></asp:Repeater>
		</recentPosts>