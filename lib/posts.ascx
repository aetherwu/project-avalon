<%@ Control Language="C#" AutoEventWireup="true" CodeFile="posts.ascx.cs" Inherits="Avalon.Web._posts" %>
	<posts>
		<asp:Repeater id="postList" OnItemDataBound="postList_ItemDataBound" runat="server"><ItemTemplate><post>
			<date address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %>"><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:D}") %></date>
			<asp:Repeater id="postInDay" runat="server"><ItemTemplate><clip>
				<time><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:HH:mm:ss}") %></time>
				<text><%# Eval("Content") %></text>
			</clip>
			</ItemTemplate></asp:Repeater>
		</post>
		</ItemTemplate></asp:Repeater>
	</posts>