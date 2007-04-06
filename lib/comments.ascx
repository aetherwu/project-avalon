<%@ Control Language="C#" AutoEventWireup="true" CodeFile="comments.ascx.cs" Inherits="Avalon.Web.comments" %>
	<comments>
	<asp:Repeater id="commentList" runat="server"><ItemTemplate>	<comment>
			<author><%# Eval("Author") %></author>
			<home><%# Eval("Homepage") %></home>
			<postTime><%# Eval("postTime") %></postTime>
			<text><![CDATA[ <%# Eval("Content") %> ]]></text>
		</comment>
	</ItemTemplate></asp:Repeater>
	</comments>	