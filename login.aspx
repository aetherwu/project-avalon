<%@ Page Language="C#" CodeFile="login.aspx.cs" Inherits="Avalon.Web._login" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
		<meta http-equiv="Content-Language" content="zh-cn" />
		<title>Login</title>
	<style type="text/css">
	form {line-height:200%;font-size:24px;font-family:"Times New Roman";margin:80px 200px;}
	</style>
	</head>
<body>
<div id="ing" runat="server">
<form action="/openid" method="post">
	<asp:label id="status" runat="server">Login:</asp:label> <br />
	<input type="hidden" name="m" value="login" id="m" />
	<input type="text" name="opid" value="woooh.com" />
	<input type="submit" name="submit" value=" µÇÂ¼ " />
</form>
</div>
</body>
</html>