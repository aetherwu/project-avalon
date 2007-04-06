<%@ Control Language="C#" AutoEventWireup="true" CodeFile="refers.ascx.cs" Inherits="Avalon.Web.refers" %>
	<refers>
		<asp:Repeater id="referList" runat="server"><ItemTemplate><refer count="<%# Eval("Count") %>"><![CDATA[<%# Eval("UrlRefer") %>]]></refer>
		</ItemTemplate></asp:Repeater>
	</refers>