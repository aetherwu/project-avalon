<%@ Page Language="C#" CodeFile="ing.aspx.cs" Inherits="Avalon.Web._ing" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Strict//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
	<head>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
		<meta http-equiv="Content-Language" content="zh-cn" />
		<title>Post a new cilp now</title>
	<style type="text/css">
	#ing {margin:20px;}
	#post {width:510px;margin:0 auto;}
	#logout {float:right;}
	textarea {width:500px;height:180px;background:#fafafa;border:1px solid #ccc;padding:3px 5px;line-height:160%;font-size:12px;}
	</style>
	</head>
<body>
<div id="ing" runat="server">
	<form action="/openid" method="post" id="logout">
		<input type="hidden" name="m" value="logout" />
		<input type="submit" name="submit" value=" 退出 " />
	</form>
	<form action="/api" method="post" id="post"><textarea name="clip"></textarea><input type="hidden" name="m" value="new" /><input type="submit" value=" 写好了 " /></form>
</div>
</body>
</html>