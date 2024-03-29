<%@ Control Language="C#" AutoEventWireup="true" CodeFile="clips.ascx.cs" Inherits="Avalon.Web._clips" %><posts>
			<asp:Repeater id="clipList" OnItemDataBound="clipList_ItemDataBound" runat="server"><ItemTemplate><post>
				<date address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %>"><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:D}") %></date>
					<differ><%# Eval("PostDiffer") %></differ>
			<asp:Repeater id="clipInDay" runat="server"><ItemTemplate>	<clip>
					<time><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:HH:mm:ss}") %></time>
					<source><%# Eval("SourceType") %></source>
					<owner><%# Eval("SourceName") %></owner>
					<site><%# Eval("SourceLink") %></site>
					<link><%# Eval("Link") %></link>
					<text><%# Eval("Content") %></text>
				</clip>
			</ItemTemplate></asp:Repeater></post>
			</ItemTemplate></asp:Repeater>
		</posts>