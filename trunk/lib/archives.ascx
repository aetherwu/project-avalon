<%@ Control Language="C#" AutoEventWireup="true" CodeFile="archives.ascx.cs" Inherits="Avalon.Web.archives" %>
		<archives>
			<asp:Repeater id="monthList" runat="server"><ItemTemplate><month address="<%# DataBinder.Eval(Container.DataItem,"Month","{0:yyyy\\/MM}") %>" count="<%# Eval("Count") %>"><%# DataBinder.Eval(Container.DataItem,"Month","{0:yyyy�� M��}") %></month>
			</ItemTemplate></asp:Repeater>
	</archives>