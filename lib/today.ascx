<%@ Control Language="C#" AutoEventWireup="true" CodeFile="today.ascx.cs" Inherits="Avalon.Web._today" %>
	<posts>
		<post type="today">
		<asp:Repeater id="clipToday" OnItemDataBound="clipList_ItemDataBound" runat="server"><ItemTemplate>
			<date address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %>">TODAY</date>
			<asp:Repeater id="clipInDay" runat="server"><ItemTemplate><clip>
				<time><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:HH:mm:ss}") %></time>
				<source><%# Eval("SourceType") %></source>
				<owner><%# Eval("SourceOwner") %></owner>
				<site><%# Eval("SourceLink") %></site>
				<link><%# Eval("Link") %></link>
				<text><%# Eval("Content") %></text>
			</clip>
			</ItemTemplate></asp:Repeater>
		
		</ItemTemplate></asp:Repeater>
		</post>
	</posts>