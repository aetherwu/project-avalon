<%@ Control Language="C#" AutoEventWireup="true" CodeFile="archives.ascx.cs" Inherits="Avalon.Web.archives" %>
		<archives>
			<asp:Repeater id="monthList" runat="server"><ItemTemplate><month address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM}") %>"><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyyÄê MÔÂ}") %></month>
			</ItemTemplate></asp:Repeater>
		</archives>