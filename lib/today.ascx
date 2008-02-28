<%@ Control Language="C#" AutoEventWireup="true" CodeFile="clips.ascx.cs" Inherits="Avalon.Web._clips" %>
		        <post>
			<asp:Repeater id="clipList" OnItemDataBound="clipList_ItemDataBound" runat="server"><ItemTemplate>
				<date address="<%# DataBinder.Eval(Container.DataItem,"PostTime","{0:yyyy\\/MM\\/dd}") %>"><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:D}") %></date>
			<asp:Repeater id="clipInDay" runat="server"><ItemTemplate>	<clip>
					<time><%# DataBinder.Eval(Container.DataItem,"PostTime","{0:HH:mm:ss}") %></time>
					<source><%# Eval("SourceType") %></source>
					<site><%# Eval("SourceLink") %></site>
					<owner><%# Eval("SourceName") %></owner>
					<link><%# Eval("Link") %></link>
					<text><%# Eval("Content") %></text>
				</clip>
			</ItemTemplate></asp:Repeater></ItemTemplate></asp:Repeater></post>
		</posts>