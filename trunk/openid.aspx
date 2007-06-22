<%@ Page Language="C#" CodeFile="login.aspx.cs" Inherits="Avalon.Web._login" %>
<form action="/login" method="post">
	<input type="text" name="opid" value="@openid.cn" id="opid" runat="server" />
	<input type="hidden" name="m" value="login" id="m" runat="server" />
	<input type="submit" name="submit" value=" µÇÂ¼ " id="submit" runat="server"  />
</form>