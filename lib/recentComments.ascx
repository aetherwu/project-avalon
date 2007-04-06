<%@ Control Language="C#" AutoEventWireup="true" CodeFile="recentComments.ascx.cs" Inherits="Avalon.Web.recentComments" %>
		<recentComments sortType='<txt:clr id="postType" runat="server"></txt:clr>'>
			<asp:Repeater id="recentComment" runat="server"><ItemTemplate><summary guest="<%# Eval("Author") %>" logTime="<%# DataBinder.Eval(Container.DataItem,"LogTime","{0:yyyy\\/MM\\/dd}") %>" ><%# Eval("Content") %></summary>
			</ItemTemplate></asp:Repeater>
		</recentComments>