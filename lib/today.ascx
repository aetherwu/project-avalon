<%@ Control Language="C#" AutoEventWireup="true" CodeFile="today.ascx.cs" Inherits="Avalon.Web._today" %>
	<posts>
		<post type="today">
		<asp:Repeater id="postToday" OnItemDataBound="postList_ItemDataBound" runat="server"><ItemTemplate>
			<date address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %>">TODAY</date>
			<asp:Repeater id="postInDay" runat="server"><ItemTemplate><clip>
				<time><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:HH:mm:ss}") %></time>
				<text><%# Eval("Content") %></text>
			</clip>
			</ItemTemplate></asp:Repeater>
		
		</ItemTemplate></asp:Repeater>
		</post>
	</posts>